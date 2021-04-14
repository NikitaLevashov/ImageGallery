using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.Interfaces;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoGallery.DAL.Repository
{
    public class GenreRepository : IGenres<GenreDAL>
    {
        GalleryDBContext _galleryDBContext;

        public GenreRepository(GalleryDBContext galleryDBContext)
        {
            _galleryDBContext = galleryDBContext;

        }
        public IEnumerable<GenreDAL> GetGenres()
        {
            var allGenre = _galleryDBContext.Genres.ToList();
            return allGenre;
        }
    }
}
