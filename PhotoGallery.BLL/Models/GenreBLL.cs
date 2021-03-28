using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoGallery.BLL.Models
{
    public class GenreBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PhotoBLL> Photos { get; set; } = new List<PhotoBLL>();
    }
}
