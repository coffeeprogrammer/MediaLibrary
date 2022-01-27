using MediaLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaLibrary.Data
{
    public class MediaLibraryContext : IdentityDbContext
    {

        public MediaLibraryContext() : base() { }

        public MediaLibraryContext(DbContextOptions<MediaLibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
