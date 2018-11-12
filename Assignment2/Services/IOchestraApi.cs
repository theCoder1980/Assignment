using Assignment2.Entities;
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
        Task<bool> AddPhotosToDb(string photos); 
    }
}
