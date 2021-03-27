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
        public IEnumerable<PhotoDAL> GetPhotos()
        {
            using (GalleryDBContext db = new GalleryDBContext())
            {
                var allPhotos = db.Photos.ToList();
                return allPhotos;
            }

        }
        public IEnumerable<PhotoDAL> GetPhotosByGenre(string genre)
        {
            using (GalleryDBContext db = new GalleryDBContext())
            {
                var genrePhoto = db.Genres.Include(c => c.Photos).Where(p => p.Name == genre).SelectMany(d=>d.Photos);
                var photos = genrePhoto.ToList();

                return photos;

                //var genrePhoto = db.Genres.Include(c => c.Photos).ToList();
                
                //foreach (var c in genrePhoto)
                //{
                //    if(c.Name==genre)
                //    {
                //        foreach (PhotoDAL s in c.Photos)
                //        {
                //            yield return s;
                //        }
                //    }
                   
                //}
            }
           
        }

        public IEnumerable<PhotoDAL> GetFiveLastPhotosByGenre()
        {
            List <PhotoDAL> photosByGenre = null;  
            List <PhotoDAL> photosByAllGenres = new List <PhotoDAL>();
            
            using (GalleryDBContext db = new GalleryDBContext())
            {
                foreach (var item in db.Genres)
                {
                    photosByGenre = GetPhotosByGenre(item.Name).OrderByDescending(p => p.Id).Take(5).ToList();
                    photosByAllGenres.AddRange(photosByGenre);
                }
            }

            return photosByAllGenres;
        }
    }
}
