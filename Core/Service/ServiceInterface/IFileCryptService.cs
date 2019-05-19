namespace ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac.Extras.DynamicProxy;
    using CrossCutting.Logging;
    using Domain.FileCrypt;
    using Domain.User;
    using Domain.User.Role;

    [Intercept(typeof(ServiceClassLogInterceptor))]
    public interface IFileCryptService
    {
        Task<byte[]> CopyStreamToByteBuffer(Stream stream);

        Task WriteBufferToFile(byte[] buffer, string path);

        Task<bool> UploadFileAndEncryptAsync(FileCrypt fileCrypt, Stream stream);

        Task<List<FileCrypt>> GetEncryptedFilesDetailsAsync();

        Task<FileCrypt> GetEncryptedFileDetailsAsync(long fileCryptId);

        Task<(FileCrypt fileDetails, MemoryStream memoryStream)> DecryptAndDownloadFileAsync(long fileCryptId);

        Task<bool> DeleteEncryptedFileAsync(FileCrypt fileCrypt);
    }
}