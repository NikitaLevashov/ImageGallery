using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoGallery.BLL.Models
{
    public class PhotoBLL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<GenreBLL> Genres { get; set; } = new List<GenreBLL>();

    }
}
