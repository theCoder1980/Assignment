using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Assignment2.Services
{
    /// <summary>
    /// Ochestra API
    /// </summary>
    public class OchestraApi : IOchestraApi
    {
        private readonly ILogger _logger;
        public OchestraApi(ILogger<OchestraApi> logger)
        {
            _logger = logger;
        }
        private readonly IList<Photo> _photos;
        /// <summary>
        /// Add photos to database
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public Task<bool> AddPhotosToDb(string photos)
        {
            try {
                var user = JsonConvert.DeserializeObject<List<Photo>>(photos);
            }
            catch(Exception ex)
            {
                _logger.LogCritical("Convert json objects and insert into database table error occured.{0}", ex);
            }

            return null;
        }
    }
}
