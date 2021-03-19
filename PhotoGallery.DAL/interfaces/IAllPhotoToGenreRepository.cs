using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IAllPhotoToGenreRepository
    {
        IEnumerable<PhotoDAL> GetAllFotoToGenry(string genre);
    }
}
