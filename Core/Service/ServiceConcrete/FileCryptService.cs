namespace ServiceConcrete
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    using Domain.User;
    using Domain.User.Role;
    using RepositoryInterface;
    using ServiceInterface;
    using Domain.FileCrypt;
    using Cinchoo.PGP;
    using CrossCutting.ConfigCache;

    public class FileCryptService : IFileCryptService
    {
        private readonly IFileCryptRepository _fileCryptRepository;

        public FileCryptService(IFileCryptRepository fileCryptRepository)
        {
            this._fileCryptRepository = fileCryptRepository;
        }

        public async Task<byte[]> CopyStreamToByteBuffer(Stream stream)
        {
            var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }

        public async Task WriteBufferToFile(byte[] buffer, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var memoryStream = new MemoryStream(buffer))
            {
                byte[] bytes = new byte[memoryStream.Length];
                await memoryStream.ReadAsync(bytes, 0, (int)memoryStream.Length);
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        public async Task<bool> UploadFileAndEncryptAsync(FileCrypt fileCrypt, Stream stream)
        {
            fileCrypt.FileCryptId = await this._fileCryptRepository.SaveFileDetailsForEncryptionAsync(fileCrypt);
            Assembly asm = Assembly.GetExecutingAssembly();
            var memoryStream = new MemoryStream();
            var memoryStreamEncrypted = new MemoryStream();
            string tempFilePath = "";

            fileCrypt.EncryptedFileName = "FileEncrypt_" + fileCrypt.FileCryptId.ToString();
            fileCrypt.EncryptedFileFullPath = fileCrypt.EncryptedFilePath + fileCrypt.EncryptedFileName + fileCrypt.EncryptedFileExtension;
            tempFilePath = fileCrypt.EncryptedFilePath + fileCrypt.EncryptedFileName + ".temp";
            string path = System.IO.Path.GetDirectoryName(asm.Location);
            string privateKeyFileFullPath = path + @"\" + GlobalAppConfigurations.Instance.GetValue("PGPPrivateKeyFileFullPath").ToString();
            string publicKeyFileFullPath = path + @"\" + GlobalAppConfigurations.Instance.GetValue("PGPPublicKeyFileFullPath").ToString();
            string pgpKeyPassword = GlobalAppConfigurations.Instance.GetValue("PGPKeyPassword").ToString();

            // Write File from stream to Byte
            await stream.CopyToAsync(memoryStream);
            byte[] fileInByte = memoryStream.ToArray();

            // Save Encrytped File byte to File
            using (var fileStream = new FileStream(tempFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var memoryStreamToFile = new MemoryStream(fileInByte))
            {
                byte[] bytes = new byte[memoryStreamToFile.Length];
                await memoryStreamToFile.ReadAsync(bytes, 0, (int)memoryStreamToFile.Length);
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }

            using (ChoPGPEncryptDecrypt pgp = new ChoPGPEncryptDecrypt())
            {
                try
                {
                    await pgp.EncryptFileAsync(tempFilePath,
                                       fileCrypt.EncryptedFileFullPath,
                                       publicKeyFileFullPath,
                                       true, true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }

            bool isUpdateSuccess = await this._fileCryptRepository.UpdateFileDetailsAfterEncryptionAsync(fileCrypt);

            return isUpdateSuccess;
        }

        public async Task<List<FileCrypt>> GetEncryptedFilesDetailsAsync()
        {
            return await this._fileCryptRepository.GetEncryptedFilesDetailsAsync();
        }

        public async Task<FileCrypt> GetEncryptedFileDetailsAsync(long fileCryptId)
        {
            return await this._fileCryptRepository.GetEncryptedFileDetailsAsync(fileCryptId);
        }

        public async Task<(FileCrypt fileDetails, MemoryStream memoryStream)> DecryptAndDownloadFileAsync(long fileCryptId)
        {
            MemoryStream memoryStream = new MemoryStream();

            FileCrypt fileCrypt = await this._fileCryptRepository.GetEncryptedFileDetailsAsync(fileCryptId);

            await this._fileCryptRepository.SaveFileDecryptionHistoryAsync(fileCrypt);

            using (var stream = new FileStream(fileCrypt.EncryptedFileFullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;

            return (fileCrypt, memoryStream);
        }

        public async Task<bool> DeleteEncryptedFileAsync(FileCrypt fileCrypt)
        {
            if (File.Exists(fileCrypt.EncryptedFileFullPath))
            {
                File.Delete(fileCrypt.EncryptedFileFullPath);
            }

            bool isDbUpdateSuccess = await this._fileCryptRepository.DeleteEncryptedFileAsync(fileCrypt);

            return isDbUpdateSuccess;
        }
    }
}