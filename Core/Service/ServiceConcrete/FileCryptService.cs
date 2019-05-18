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
    }
}