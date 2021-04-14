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
    public class PhotoRepository : IPhotos<PhotoDAL> 
    {
        GalleryDBContext  _galleryDBContext;

        public PhotoRepository(GalleryDBContext galleryDBContext)
        {
            _galleryDBContext = galleryDBContext ?? throw new ArgumentNullException("PhotoRepository Error");

        }
            
        public IEnumerable<PhotoDAL> GetPhotos()
        {
           var allPhotos = _galleryDBContext.Photos.ToList();
           return allPhotos;
           
        }
        public IEnumerable<PhotoDAL> GetPhotosForEachGenre(string genre)
        {
            var genrePhoto = _galleryDBContext.Genres.Include(c => c.Photos).Where(p => p.Name == genre).SelectMany(d=>d.Photos);
            var photos = genrePhoto.ToList();

            return photos;
        }

        public IEnumerable<PhotoDAL> GetAllFiveLastPhotoByGenre()
        {
            List <PhotoDAL> photosByGenre = null;  
            List <PhotoDAL> photosByAllGenres = new List <PhotoDAL>();

            foreach (var item in _galleryDBContext.Genres)
            {
                photosByGenre = GetPhotosForEachGenre(item.Name).OrderByDescending(p => p.Id).Take(5).ToList();
                photosByAllGenres.AddRange(photosByGenre);
            }

            return photosByAllGenres;
        }

        public void AddPhoto(PhotoDAL photo)
        {
            _galleryDBContext.Photos.Add(photo);
            _galleryDBContext.SaveChanges();
        }

        public void Update(PhotoDAL photo)
        {
            _galleryDBContext.Photos.Update(photo);
            _galleryDBContext.SaveChanges();
        }

        public void Delete(PhotoDAL photo)
        {
            _galleryDBContext.Photos.AsNoTracking();
            _galleryDBContext.Photos.Remove(photo);
            _galleryDBContext.SaveChanges();
        }

    }
}
