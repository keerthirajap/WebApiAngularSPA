namespace Domain.FileCrypt
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FileCrypt
    {
        public long FileCryptId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string FileFullPath { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public long ModifiedBy { get; set; }
    }
}