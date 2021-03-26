using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.intrerfaces
{
    public interface IPhotoService
    {
        public IEnumerable<PhotoBLL> GetAllFotoToGenry(string genre);
        public IEnumerable<PhotoBLL> GetAllPhoto();
        public IEnumerable<PhotoBLL> GetFiveLastPhotoToGenre(string genre);
        
    }
}
