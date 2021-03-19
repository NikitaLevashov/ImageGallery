using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IFiveLastPhotoToGenreRepository
    {
        public IEnumerable<PhotoDAL> GetFiveLastPhotoToGenre(string genre);

    }
}
