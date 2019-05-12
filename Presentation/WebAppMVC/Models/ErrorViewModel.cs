namespace WebAppMVC.Models
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}