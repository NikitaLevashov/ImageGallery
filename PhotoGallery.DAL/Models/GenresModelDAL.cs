using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.Models
{
    public class GenresModelDAL
    {
        public PhotoDAL Photo;
        public GenreDAL[] GenresDAL { get; set; }
    }
}
