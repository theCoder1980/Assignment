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
       
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
 
        private readonly PhotoDbContext _photoDbContext;
        #endregion

        public HomeController(
            ILogger<HomeController> logger,PhotoDbContext photoDbContext)
        {
            
            _logger = logger;
          
        
            _photoDbContext = photoDbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(int page =1,int pageSize=5)
        {
     
         
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
