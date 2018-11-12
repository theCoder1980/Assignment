using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Entities;

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
        /// Get Photos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Photo> GetPhotos()
        {
            return _photoDbContext.Photos.OrderBy(p => p.title.ToList());
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
