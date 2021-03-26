using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IFiveLastPhotoToGenreRepository <T> where T : class
    {
        public IEnumerable<T> GetFiveLastPhotoToGenre(string genre);

    }
}
