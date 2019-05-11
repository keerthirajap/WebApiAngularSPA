namespace WebAppMVC.Models
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}