using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Entities;
using Assignment2.Helpers;

namespace Assignment2.Services
{
    /// <summary>
    /// Photo Repository
    /// </summary>
    public class PhotoRepository : IPhotoRepository
    {

        private readonly PhotoDbContext _photoDbContext;
        /// <summary>
        /// Photo repo constructor for dependency injection
        /// </summary>
        public PhotoRepository(PhotoDbContext photoDbContext)
        {
            _photoDbContext = photoDbContext;
        }
        /// <summary>
        /// Add photo object
        /// </summary>
        /// <param name="photo"></param>
        public void AddPhoto(Photo photo)
        {
           
            _photoDbContext.Photos.Add(photo);
            
        }
       /// <summary>
       /// Get photos by filtering with paging data
       /// </summary>
       /// <param name="photoFilterParams">filter parameters</param>
       /// <returns></returns>
        public IEnumerable<Photo> GetPhotos(PhotoFilterParams photoFilterParams)
        {
            return _photoDbContext.Photos.OrderBy(p => p.id).
                  ThenBy(p => p.albumId).
                  Skip(photoFilterParams.PageSize * (photoFilterParams.PageNumber - 1)).
                  Take(photoFilterParams.PageSize).
                  ToList();
                  
        }

        public bool PhotoExists(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return (_photoDbContext.SaveChanges() >= 0);
        }
    }
}
