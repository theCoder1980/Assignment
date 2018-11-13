using Assignment2.Entities;
using Assignment2.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public interface IOchestraApi
    {
        /// <summary>
        /// Add photos
        /// </summary>
        /// <returns></returns>
        bool AddPhotosToDb(string photos);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         IEnumerable<Photo> GetPhotos(int page , int pageSize);
    }
}
