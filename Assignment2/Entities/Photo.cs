using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Entities
{
    /// <summary>
    /// Photo entity object  model
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// The unique Id of the book
        /// </summary>
        [Key]
       
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(30)]
        public int albumId { get; set; }

       
        /// <summary>
        /// The title of the photo
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string title { get; set; }
        /// <summary>
        /// Url of the photo
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Url { get; set; }
        /// <summary>
        /// Thumbnail url of the photo
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string thumbnailUrl { get; set; }
    }
}
