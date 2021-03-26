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
        public IEnumerable<PhotoBLL> GetAllFotoToGenry(string genre)
        {
            return ClassMapping.MapToIEnumerableBLLPhotos(Database.AllPhotosToGenre.GetAllFotoToGenry(genre));
        }

        public IEnumerable<PhotoBLL> GetAllPhoto()
        {
            return ClassMapping.MapToIEnumerableBLLPhotos(Database.AllPhotos.GetAllPhoto());
        }

        public IEnumerable<PhotoBLL> GetFiveLastPhotoToGenre(string genre)
        {
            return ClassMapping.MapToIEnumerableBLLPhotos(Database.FiveLastPhotoToGenre.GetFiveLastPhotoToGenre(genre));
        }
    }
}
