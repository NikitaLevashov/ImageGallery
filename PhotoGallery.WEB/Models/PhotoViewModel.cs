using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.WEB.Models
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Please enter author")]
        public string Author { get; set; }

        public string Format { get; set; }

        public string Path { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public ICollection<GenreViewModel> Genres { get; set; }

    }
}
