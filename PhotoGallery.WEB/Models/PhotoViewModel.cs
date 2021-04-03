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

        [Required(ErrorMessage = "Укажите заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Не указан автор")]
        public string Author { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }

        //public PhotoViewModel()
        //{
        //    Genres = new List<GenreViewModel>();
        //}
        [Required(ErrorMessage = "Не загружено фото")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Укажите жанр")]
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

    }
}
