using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.EFCore;
using System.Linq;

namespace PhotoGallery.DAL.Repository
{
    public class PhotoRepository : IAllPhotoToGenreRepository, IFiveLastPhotoToGenreRepository, IAllPhotoRepository
    {
        public IEnumerable<PhotoDAL> GetAllPhoto()
        {
            using (GalleryDBContext db = new GalleryDBContext())
            {
                var allPhotos = db.Photos.ToList();

                return allPhotos;
                
            }

        }
        public IEnumerable<PhotoDAL> GetAllFotoToGenry(string genre)
        {
            using (GalleryDBContext db = new GalleryDBContext())
            {
                var genrePhoto = db.Genres.Include(c => c.Photos).ToList();

                foreach (var c in genrePhoto)
                {
                    if(c.Name==genre)
                    {
                        foreach (PhotoDAL s in c.Photos)
                        {
                            yield return s;
                        }
                    }
                   
                }
            }
           
        }

        public IEnumerable<PhotoDAL> GetFiveLastPhotoToGenre(string genre)
        {
            var genreFhoto = GetAllFotoToGenry(genre);
            var fiveLastPhotoToGenre = genreFhoto.OrderBy(p=>p.Id).Reverse().Take(5);

            return fiveLastPhotoToGenre;

        }
    }
}
