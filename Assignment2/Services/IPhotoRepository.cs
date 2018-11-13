using Assignment2.Entities;
using Assignment2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    /// <summary>
    /// Photo repository interface
    /// </summary>
    public interface IPhotoRepository
    {
        /// <summary>
        /// Get list of the photos from db
        /// </summary>
        /// <returns>List of photo</returns>
        IEnumerable<Photo> GetPhotos(PhotoFilterParams photoFilterParams);
        /// <summary>
        /// Add new photo into db
        /// </summary>
        /// <param name="photo">photo object</param>
        void AddPhoto(Photo photo);
        /// <summary>
        /// Save context
        /// </summary>
        /// <returns></returns>
        bool Save();
        /// <summary>
        /// Check if record exists
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool PhotoExists(int Id);
       
    }
}
