using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.intrerfaces
{
    public interface IPhotoService
    {
        public IEnumerable<PhotoBLL> GetPhotosForEachGenre(string genre);
        public IEnumerable<PhotoBLL> GetPhotos();
        public IEnumerable<PhotoBLL> GetAllFiveLastPhotosByGenre();
        public IEnumerable<GenreBLL> GetGenres();
        void AddPhoto(PhotoBLL photo);
        void Update(PhotoBLL photo);
        void Delete(PhotoBLL photo);
    }
}
