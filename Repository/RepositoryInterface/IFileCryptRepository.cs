namespace RepositoryInterface
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac.Extras.DynamicProxy;
    using CrossCutting.Logging;
    using Domain.FileCrypt;
    using Domain.User;
    using Domain.User.Role;
    using Insight.Database;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
    [Intercept(typeof(RepositoryInterfaceLogInterceptor))]
    public interface IFileCryptRepository
    {
        [Sql("[dbo].[P_SaveFileDetailsForEncryption]")]
        Task<long> SaveFileDetailsForEncryptionAsync(FileCrypt fileCrypt);

        [Sql("[dbo].[P_UpdateFileDetailsAfterEncryption]")]
        Task<bool> UpdateFileDetailsAfterEncryptionAsync(FileCrypt fileCrypt);

        [Sql("SELECT * FROM [dbo].[FileCrypt] WHERE IsActive = 1 ")]
        Task<List<FileCrypt>> GetEncryptedFilesDetailsAsync();

        [Sql("SELECT * FROM [dbo].[FileCrypt] WHERE IsActive = 1 AND FileCryptId = @fileCryptId")]
        Task<FileCrypt> GetEncryptedFileDetailsAsync(long fileCryptId);
    }
}