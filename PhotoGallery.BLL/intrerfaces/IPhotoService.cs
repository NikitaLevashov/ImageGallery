using PhotoGallery.BLL.Models;
using System.Collections.Generic;

namespace PhotoGallery.BLL.intrerfaces
{
    public interface IPhotoService
    {
        public IEnumerable<PhotoBLL> GetPhotosForEachGenre(string genre);
        public IEnumerable<PhotoBLL> GetPhotos();
        public IEnumerable<PhotoBLL> GetAllFiveLastPhotosByGenre(int numbersPhoto);
        public IEnumerable<GenreBLL> GetGenres();
        void AddPhoto(PhotoBLL photo);
        void Update(PhotoBLL photo);
        void Delete(PhotoBLL photo);
    }
}
