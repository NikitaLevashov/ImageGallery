﻿using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.WEB.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PhotoViewModel> Photos { get; set; } = new List<PhotoViewModel>();
    }
}
