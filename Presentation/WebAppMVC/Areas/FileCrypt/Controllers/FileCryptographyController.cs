namespace WebAppMVC.Areas.FileCrypto.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using BindingModel.V1._0.User;
    using Domain.FileCrypt;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ServiceInterface;
    using WebAppMVC.Infrastructure.Extensions;

    [Area("FileCrypt")]
    [Authorize(Roles = "Admin")]
    public class FileCryptController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFileCryptService _fileCryptService;

        public FileCryptController(IHostingEnvironment hostingEnvironment, IFileCryptService fileCryptService)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._fileCryptService = fileCryptService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadUploadFilesPartialView()
        {
            return await Task.Run(() => this.PartialView("_uploadFilesToEncrypt"));
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles(List<IFormFile> filesForUpload)
        {
            UserBindingModel loggediInUserDetails = new UserBindingModel();
            loggediInUserDetails = this.User.GetLoggedInUserDetails();

            var uploadFilepath = Path.Combine(_hostingEnvironment.WebRootPath, @"EncryptedFiles\");

            foreach (var fileToEncrypt in filesForUpload)
            {
                FileCrypt fileCrypt = new FileCrypt();
                fileCrypt.FileName = fileToEncrypt.FileName;
                fileCrypt.FileBytes = await this._fileCryptService.CopyStreamToByteBuffer(fileToEncrypt.OpenReadStream());
                fileCrypt.EncryptedFileName = Guid.NewGuid().ToString();
                fileCrypt.EncryptedFilePath = uploadFilepath;
                fileCrypt.CreatedBy = loggediInUserDetails.UserId;
                fileCrypt.ModifiedBy = loggediInUserDetails.UserId;

                await this._fileCryptService.WriteBufferToFile(fileCrypt.FileBytes, fileCrypt.EncryptedFilePath + fileCrypt.EncryptedFileName);
            }

            return Ok();
        }
    }
}