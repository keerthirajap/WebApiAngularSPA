namespace BindingModel.V1._0.FileCrypt
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FileCryptBindingModel
    {
        public long FileCryptId { get; set; }

        public string FileName { get; set; }

        public string EncryptedFileName { get; set; }

        public string EncryptedFilePath { get; set; }

        public string EncryptedFileFullPath { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public long ModifiedBy { get; set; }
    }
}