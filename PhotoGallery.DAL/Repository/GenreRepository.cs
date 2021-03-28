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
        public IEnumerable<GenreDAL> GetGenres()
        {
            using (GalleryDBContext db = new GalleryDBContext())
            {
                var allGenre = db.Genres.ToList();
                return allGenre;
            }

        }
    }
}
