using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_repo_PRS.Models.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test_repo_PRS.Models;

namespace Test_repo_PRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Esignature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Savedata(ModelFormTOR modelform)
        {
            string filesig = modelform.Esignature;
            string uniquefile = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = modelform.Username + "_" + uniquefile + ".png";
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "image", fileName); //image คือ พาทRoot ของ image โดยเซฟเป็นชื่อ filename
            System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(modelform.Esignature.Replace("data:image/png;base64,", string.Empty)));

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
