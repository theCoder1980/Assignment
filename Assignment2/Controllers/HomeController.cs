using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;

using Microsoft.AspNetCore.Authorization;
using Assignment2.Services;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        #region private variables
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IOchestraApi _ochestraApi;
        #endregion

        public HomeController(IHttpClientFactory httpClientFactory,
            ILogger<HomeController> logger, IConfiguration configuration,IOchestraApi ochestraApi)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
            _ochestraApi = ochestraApi;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var APIUrl = _configuration.GetValue<string>("ExternalAPIUrl");
            _logger.LogInformation("External API Url:{0}",APIUrl);
            var jsonObjects = await client.GetStringAsync(APIUrl);
            _logger.LogInformation("jsonObjects, {0}", jsonObjects);

            var photos = _ochestraApi.AddPhotosToDb(jsonObjects);
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
