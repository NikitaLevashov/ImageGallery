using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PhotoGallery.DAL.Models
{
    public class PhotoDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public List<GenreDAL> Genres { get; set; }

        public PhotoDAL()
        {
            Genres = new List<GenreDAL>();
        }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
