namespace WebAppMVC.Areas.FileCrypto.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("FileCrypt")]
    [Authorize(Roles = "Admin")]
    public class FileCryptController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}