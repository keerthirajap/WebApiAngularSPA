namespace WebAppMVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebAppMVC.Models;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return this.View("AccessDenied");
        }

        [AllowAnonymous]
        public IActionResult GetSampleGridPostDataView()
        {
            List<SampleModel> sampleModels = new List<SampleModel>();
            sampleModels.Add(new SampleModel
            {
                SampleData1 = "1SampleData1",
                SampleData2 = "1SampleData2",
                SampleData3 = "1SampleData3"
            });

            sampleModels.Add(new SampleModel
            {
                SampleData1 = "2SampleData1",
                SampleData2 = "2SampleData2",
                SampleData3 = "2SampleData3"
            });

            return this.View("SampleGridPostData", sampleModels);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostSampleGridData(List<SampleModel> sampleModels)
        {
            return this.Ok();
        }
    }
}