using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoGallery.DAL.EFCore
{
    public class GalleryDBContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<PhotoDAL> Photos { get; set; }
        public DbSet<GenreDAL> Genres  { get; set; }
       
        public GalleryDBContext(DbContextOptions<GalleryDBContext> options) : base(options)
        {
        }

        public GalleryDBContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
