using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Entities
{
    /// <summary>
    /// Book Object class with the defined behavior
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The unique Id of the book
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// The name of the book
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
    }
