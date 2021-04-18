using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.BLL.Mapping;
using PhotoGallery.BLL.Models;
using PhotoGallery.BLL.Filters;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.PhotoService
{
    public class PhotoService : IPhotoService
    {
        IUnitOfWork Database { get; set; }

        public PhotoService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public IEnumerable<PhotoBLL> GetPhotosForEachGenre(string genre)
        {
            return MapperProfilePhoto.MapToIEnumerableBLLPhotos(Database.PhotosByGenre.GetPhotosForEachGenre(genre));
        }

        public IEnumerable<PhotoBLL> GetPhotos()
        {
            return MapperProfilePhoto.MapToIEnumerableBLLPhotos(Database.Photos.GetPhotos());
        }

        [SetNumbersPhotoFilter]
        public IEnumerable<PhotoBLL> GetAllFiveLastPhotosByGenre(int numbersOfPhoto)
        {
            return MapperProfilePhoto.MapToIEnumerableBLLPhotos(Database.FiveLastPhotosByGenre.GetAllFiveLastPhotoByGenre(numbersOfPhoto));
        }

        public IEnumerable<GenreBLL> GetGenres()
        {
            return MapperProfileGenre.MapToIEnumerableBLLGenres(Database.Genres.GetGenres());
        }

        public void AddPhoto(PhotoBLL photo)
        {
            Database.AddPhoto(MapperProfilePhoto.MapToDALPhoto(photo));
        }

        public void Update(PhotoBLL photo)
        {
            Database.Update(MapperProfilePhoto.MapToDALPhoto(photo));
        }

        public void Delete(PhotoBLL photo)
        {
            Database.Delete(MapperProfilePhoto.MapToDALPhoto(photo));
        }
    }
}
