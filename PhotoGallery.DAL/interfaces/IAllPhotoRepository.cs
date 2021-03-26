using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IAllPhotoRepository<T> where T : class
    {
        IEnumerable<T> GetAllPhoto();
    }
}
