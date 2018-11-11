using Assignment2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Data
{
    /// <summary>
    /// The DB context that map to the database instance.
    /// 
    /// </summary>
    public class BookDbContext : DbContext
    {
        /// <summary>
        /// Initialize the instance of the dbcontext by passing in the dbcontext option
        /// </summary>
        /// <param name="options"></param>
        public BookDbContext(DbContextOptions options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Books
        /// </summary>
        public DbSet<Book> Books { get; set; }
    }
}

