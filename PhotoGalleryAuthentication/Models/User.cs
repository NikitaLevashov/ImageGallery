using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace PhotoGalleryAuthentication.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
