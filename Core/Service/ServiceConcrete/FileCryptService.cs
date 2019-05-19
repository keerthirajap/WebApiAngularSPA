namespace ServiceConcrete
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using Domain.User;
    using Domain.User.Role;
    using RepositoryInterface;
    using ServiceInterface;
    using System.IO;
    using Domain.FileCrypt;
    using Cinchoo.PGP;
    using System.Reflection;
    using CrossCutting.ConfigCache;

    public class FileCryptService : IFileCryptService
    {
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
            };
        }

        public async Task<bool> UploadFileAndEncrypt(FileCrypt fileCrypt, Stream stream)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var memoryStream = new MemoryStream();
            var memoryStreamEncrypted = new MemoryStream();

            string path = System.IO.Path.GetDirectoryName(asm.Location);
            string pGPPrivateKeyFileFullPath = path + @"\" + GlobalAppConfigurations.Instance.GetValue("PGPPrivateKeyFileFullPath").ToString();
            string pGPPublicKeyFileFullPath = path + @"\" + GlobalAppConfigurations.Instance.GetValue("PGPPublicKeyFileFullPath").ToString();
            string pGPKeyPassword = GlobalAppConfigurations.Instance.GetValue("PGPKeyPassword").ToString();

            // Write File from stream to Byte
            await stream.CopyToAsync(memoryStream);
            byte[] fileInByte = memoryStream.ToArray();

            // Save Encrytped File byte to File
            using (var fileStream = new FileStream(fileCrypt.EncryptedFileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var memoryStreamToFile = new MemoryStream(fileInByte))
            {
                byte[] bytes = new byte[memoryStreamToFile.Length];
                await memoryStreamToFile.ReadAsync(bytes, 0, (int)memoryStreamToFile.Length);
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            };

            using (ChoPGPEncryptDecrypt pgp = new ChoPGPEncryptDecrypt())
            {
                try
                {
                    pgp.EncryptAndSign(stream, memoryStreamEncrypted,
                                                     pGPPublicKeyFileFullPath, pGPPrivateKeyFileFullPath, pGPKeyPassword, true, true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            byte[] encryptedFileByte = memoryStreamEncrypted.ToArray();

            // Save Encrytped File byte to File
            using (var fileStream = new FileStream(fileCrypt.EncryptedFileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var memoryStreamToFile = new MemoryStream(encryptedFileByte))
            {
                byte[] bytes = new byte[memoryStreamToFile.Length];
                await memoryStreamToFile.ReadAsync(bytes, 0, (int)memoryStreamToFile.Length);
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            };

            return true;
        }
    }
}