using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.intrerfaces
{
    public interface IPhotoService
    {
        public IEnumerable<PhotoBLL> GetPhotosByGenre(string genre);
        public IEnumerable<PhotoBLL> GetPhotos();
        public IEnumerable<PhotoBLL> GetFiveLastPhotosByGenre();
        public IEnumerable<GenreBLL> GetGenres();
        void Save();
        void AddPhoto(PhotoBLL photo);
        void Update(PhotoBLL photo);
        void Delete(PhotoBLL photo);

    }
}
