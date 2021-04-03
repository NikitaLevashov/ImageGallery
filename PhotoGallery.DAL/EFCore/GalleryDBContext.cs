﻿using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoGallery.DAL.EFCore
{
    public class GalleryDBContext : DbContext
    {

        public DbSet<PhotoDAL> Photos { get; set; }
        public DbSet<GenreDAL> Genres  { get; set; }
        public DbSet<AdminDAL> Admins { get; set; }

        //public GalleryDBContext(DbContextOptions<GalleryDBContext> options)
        //: base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=itacademyphotogallerydb;Trusted_Connection=True;");
        }

    }
}
