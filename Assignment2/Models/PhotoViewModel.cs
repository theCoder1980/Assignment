using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public class PhotoViewModel
    {

        /// <summary>
        /// The unique Id of the book
        /// </summary>
     
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
       
        public int albumId { get; set; }


        /// <summary>
        /// The title of the photo
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string title { get; set; }
        /// <summary>
        /// Url of the photo
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string url { get; set; }
        /// <summary>
        /// Thumbnail url of the photo
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string thumbnailUrl { get; set; }
    }
}
