using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.BLL.Mapping;
using PhotoGallery.BLL.Models;
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
        public IEnumerable<PhotoBLL> GetPhotosByGenre(string genre)
        {
            return MapperProfile.MapToIEnumerableBLLPhotos(Database.PhotosByGenre.GetPhotosByGenre(genre));
        }

        public IEnumerable<PhotoBLL> GetPhotos()
        {
            return MapperProfile.MapToIEnumerableBLLPhotos(Database.Photos.GetPhotos());
        }

        public IEnumerable<PhotoBLL> GetFiveLastPhotosByGenre()
        {
            return MapperProfile.MapToIEnumerableBLLPhotos(Database.FiveLastPhotosByGenre.GetFiveLastPhotosByGenre());
        }
    }
}
