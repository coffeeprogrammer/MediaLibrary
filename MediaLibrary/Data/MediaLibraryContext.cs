using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediaLibrary.Models;

namespace MediaLibrary.Data
{
    public class MediaLibraryContext : DbContext
    {
        public MediaLibraryContext (DbContextOptions<MediaLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<MediaLibrary.Models.Movie> Movie { get; set; }
    }
}
