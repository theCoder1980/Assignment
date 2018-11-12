using Assignment2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Data
{
    /// <summary>
    /// Photo Db Context
    /// </summary>
    public class PhotoDbContext : DbContext
    {
        /// <summary>
        /// Initialize the instance of the dbcontext by passing in the dbcontext option
        /// </summary>
        /// <param name="options"></param>
        public PhotoDbContext(DbContextOptions options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Photos
        /// </summary>
        public DbSet<Photo> Photos { get; set; }
    }
}
