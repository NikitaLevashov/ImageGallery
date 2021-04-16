using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IPhotos<T> where T: class
    {
        IEnumerable<T> GetPhotos();
        IEnumerable<T> GetPhotosForEachGenre(string genre);
        IEnumerable<T> GetAllFiveLastPhotoByGenre(int _numbersPhoto);
        void AddPhoto(T photo);
        void Update(T photo);
        void Delete(T photo);
    }
}
