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
        private readonly IPhotoRepository _photoRepository;
        
        public OchestraApi(ILogger<OchestraApi> logger,IPhotoRepository photoRepository)
        {
            _logger = logger;
            _photoRepository = photoRepository;
            
        }
        private readonly IList<Photo> _photos;
        /// <summary>
        /// Add photos to database
        /// https://jsonplaceholder.typicode.com/photos
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public bool AddPhotosToDb(string photos)
        {
            var status = false;
            try {
               
                var Photos = JsonConvert.DeserializeObject<List<Photo>>(photos);
                if(Photos.Count <= 0)
                    _logger.LogInformation("Photo json object return 0 count:{0}", Photos);

                Photos.ForEach(item => _photoRepository.AddPhoto(item));

                _photoRepository.Save();
                status = true;

            }
            catch(Exception ex)
            {
                status = false;
                _logger.LogCritical("Convert json objects and insert into database table error occured.{0}", ex);
            }

            return status;
        }

        public IEnumerable<Photo> GetPhotos()
        {
            return _photoRepository.GetPhotos();
        }

        

    }
}
