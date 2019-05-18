namespace Domain.FileCrypt
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FileCryptDownloadHistory
    {
        public long FileCryptDownloadHistoryId { get; set; }

        public long FileCryptId { get; set; }

        public string FileName { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public long ModifiedBy { get; set; }
    }
}