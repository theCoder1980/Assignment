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
using Assignment2.Helpers;
using AutoMapper;
using Assignment2.Data;
using PagedList.Core;
using Microsoft.EntityFrameworkCore;
using Assignment2.Entities;

namespace Assignment2.Controllers
{
    /// <summary>
    /// The main landing page controller
    /// </summary>
    public class HomeController : Controller
    {
        #region private variables
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IOchestraApi _ochestraApi;
        private readonly PhotoDbContext _photoDbContext;
        #endregion

        public HomeController(IHttpClientFactory httpClientFactory,
            ILogger<HomeController> logger, IConfiguration configuration,IOchestraApi ochestraApi,PhotoDbContext photoDbContext)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
            _ochestraApi = ochestraApi;
            _photoDbContext = photoDbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(int page =1,int pageSize=5)
        {
            //var photosEntities = _ochestraApi.GetPhotos(page,pageSize).ToList();
            //var model = Mapper.Map<IEnumerable<PhotoViewModel>>(photosEntities).ToList();
            //if (model.Count <= 0)
            //{
            //    var client = _httpClientFactory.CreateClient();
            //    var aPIUrl = _configuration.GetValue<string>("ExternalAPIUrl");
            //    _logger.LogInformation("External API Url:{0}", aPIUrl);
            //    var jsonObjects = await client.GetStringAsync(aPIUrl);
            //    _logger.LogInformation("jsonObjects, {0}", jsonObjects);
            //    //Check if data loaded and skip this action
            //    _ochestraApi.AddPhotosToDb(jsonObjects);
            //}
         
            PagedList<Photo> modelPaging = new PagedList<Photo>(_photoDbContext.Photos.AsNoTracking(), page, pageSize);

            return View("Index", modelPaging);
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize]
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
