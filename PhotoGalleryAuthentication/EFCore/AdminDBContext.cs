using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoGalleryAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGalleryAuthentication.EFCore
{
    public class AdminDBContext : IdentityDbContext<User>
    {
        public AdminDBContext(DbContextOptions<AdminDBContext> options)
          : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
