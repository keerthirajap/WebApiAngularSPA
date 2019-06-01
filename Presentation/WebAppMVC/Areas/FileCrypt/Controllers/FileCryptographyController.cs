namespace WebAppMVC.Areas.FileCrypto.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModel.V1._0.FileCrypt;
    using BindingModel.V1._0.User;
    using CrossCutting.ConfigCache;
    using Domain.FileCrypt;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ServiceInterface;
    using WebAppMVC.Infrastructure.Extensions;
    using CrossCutting.Extension;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.SignalR;
    using WebAppMVC.Infrastructure.SignalRHubs;

    [Area("FileCrypt")]
    [Authorize]
    public class FileCryptController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHubContext<AnonymousHub> _anonymousHubContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IFileCryptService _fileCryptService;

        public FileCryptController(IMapper mapper,
                                   IHostingEnvironment hostingEnvironment,
                                   IHubContext<AnonymousHub> anonymousHubContext,
                                   IHttpContextAccessor httpContextAccessor,
                                   IFileCryptService fileCryptService
                                   )
        {
            this._mapper = mapper;
            this._hostingEnvironment = hostingEnvironment;
            this._anonymousHubContext = anonymousHubContext;
            this._httpContextAccessor = httpContextAccessor;

            this._fileCryptService = fileCryptService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => this.View());
        }

        [HttpGet]
        public async Task<IActionResult> LoadUploadFilesPartialView()
        {
            return await Task.Run(() => this.PartialView("_uploadFilesToEncrypt"));
        }

        [HttpGet]
        public async Task<IActionResult> GetEncryptedFilesDetailsAsync()
        {
            List<FileCryptBindingModel> filesCryptBindingModel = new List<FileCryptBindingModel>();
            List<FileCrypt> filesCrypt = new List<FileCrypt>();

            filesCrypt = await this._fileCryptService.GetEncryptedFilesDetailsAsync();

            filesCryptBindingModel = this._mapper.Map<List<FileCryptBindingModel>>(filesCrypt);

            return await Task.Run(() => this.PartialView("_getEncryptedFileDetails", filesCryptBindingModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetEncryptedFileDetailsAsync(long fileCryptId)
        {
            FileCrypt fileCrypt = new FileCrypt();
            fileCrypt = await this._fileCryptService.GetEncryptedFileDetailsAsync(fileCryptId);

            List<FileCryptBindingModel> filesCryptBindingModel = new List<FileCryptBindingModel>();
            List<FileCrypt> filesCrypt = new List<FileCrypt>();

            filesCrypt = await this._fileCryptService.GetEncryptedFilesDetailsAsync();

            filesCryptBindingModel = this._mapper.Map<List<FileCryptBindingModel>>(filesCrypt);

            return await Task.Run(() => this.PartialView("_getEncryptedFileDetailsAsync", filesCryptBindingModel));
        }

        [HttpGet]
        public async Task<IActionResult> DecryptAndDownloadFileAsync(long fileCryptId)
        {
            var decryptedFileDetails = await this._fileCryptService.DecryptAndDownloadFileAsync(fileCryptId);

            return this.File(decryptedFileDetails.memoryStream,
                             MimeTypeMap.GetMimeTypeByWindowsRegistry(decryptedFileDetails.fileDetails.EncryptedFileFullPath),
                             decryptedFileDetails.fileDetails.FileName);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles(List<IFormFile> filesForUpload)
        {
            string signalRConnectionId = this._httpContextAccessor.HttpContext.Request?.Headers["SignalRConnectionId"];
            int percentCompleted = 20;

            dynamic ajaxReturn = new JObject();
            UserBindingModel loggedInUserDetails = new UserBindingModel();
            loggedInUserDetails = this.User.GetLoggedInUserDetails();

            if (signalRConnectionId != null)
            {
                percentCompleted = percentCompleted + 10;
                await this._anonymousHubContext.Clients
                            .Client(signalRConnectionId)
                            .SendAsync("progressBarUpdate", percentCompleted);
            }

            var uploadFilepath = Path.Combine(this._hostingEnvironment.WebRootPath, @"EncryptedFiles\");

            if (signalRConnectionId != null)
            {
                percentCompleted = percentCompleted + 10;

                await this._anonymousHubContext.Clients
                            .Client(signalRConnectionId)
                            .SendAsync("progressBarUpdate", percentCompleted);
            }

            int count = 1;
            foreach (var fileToEncrypt in filesForUpload)
            {
                int percentOfFiles = (int)Math.Round(((double)count / (double)filesForUpload.Count) * 50);
                int percentCompletedForEncryption = percentCompleted + percentOfFiles;
                count++;

                FileCrypt fileCrypt = new FileCrypt();
                fileCrypt.FileName = fileToEncrypt.FileName;
                fileCrypt.EncryptedFilePath = uploadFilepath;
                fileCrypt.EncryptedFileExtension = GlobalAppConfigurations.Instance.GetValue("PGPEncrypedFileExtension").ToString();

                fileCrypt.CreatedBy = loggedInUserDetails.UserId;
                fileCrypt.ModifiedBy = loggedInUserDetails.UserId;

                await this._fileCryptService.UploadFileAndEncryptAsync(fileCrypt, fileToEncrypt.OpenReadStream());

                if (signalRConnectionId != null)
                {
                    await this._anonymousHubContext.Clients
                                .Client(signalRConnectionId)
                                .SendAsync("progressBarUpdate", percentCompletedForEncryption);
                }
            }

            ajaxReturn.Status = "Success";
            ajaxReturn.GetGoodJobVerb = "Good Work";
            ajaxReturn.Message = "File uploaded successfully" +
                " ";

            if (signalRConnectionId != null)
            {
                await this._anonymousHubContext.Clients
                            .Client(signalRConnectionId)
                            .SendAsync("progressBarUpdate", 100);
            }

            return this.Json(ajaxReturn);
        }

        [Authorize(Policy = "SuperUser-Admin-Manager")]
        [HttpGet]
        public async Task<IActionResult> DeleteEncryptedFilesAsync(long fileCryptId)
        {
            dynamic ajaxReturn = new JObject();
            UserBindingModel loggedInUserDetails = new UserBindingModel();
            loggedInUserDetails = this.User.GetLoggedInUserDetails();
            FileCrypt fileCrypt = new FileCrypt();

            fileCrypt.ModifiedBy = loggedInUserDetails.UserId;
            fileCrypt = await this._fileCryptService.GetEncryptedFileDetailsAsync(fileCryptId);

            bool isFileDeletionSuccess = await this._fileCryptService.DeleteEncryptedFileAsync(fileCrypt);

            if (isFileDeletionSuccess)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.GetGoodJobVerb = "Good Work";
                ajaxReturn.Message = fileCrypt.FileName + " - file delete sucessfully" +
                                    "";
            }
            else
            {
                ajaxReturn.Status = "Error";
                ajaxReturn.Message = "Error occured while deleting file - " + fileCrypt.FileName +
                                    "";
            }

            return this.Json(ajaxReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetEncryptedFileDownloadHistoryAsync(long fileCryptId)
        {
            List<FileCryptBindingModel> filesCryptBindingModel = new List<FileCryptBindingModel>();
            List<FileCrypt> filesCrypt = new List<FileCrypt>();
            FileCrypt fileCrypt = new FileCrypt();

            fileCrypt.FileCryptId = fileCryptId;
            filesCrypt = await this._fileCryptService.GetEncryptedFileDownloadHistoryAsync(fileCrypt);

            filesCryptBindingModel = this._mapper.Map<List<FileCryptBindingModel>>(filesCrypt);

            return await Task.Run(() => this.PartialView("_getEncryptedFileDownloadHistory", filesCryptBindingModel));
        }
    }
}