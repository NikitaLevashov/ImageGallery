using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAllPhotoRepository<PhotoDAL> AllPhotos { get; }
        IAllPhotoToGenreRepository<PhotoDAL> AllPhotosToGenre { get; }
        IFiveLastPhotoToGenreRepository<PhotoDAL> FiveLastPhotoToGenre { get; }
    }
}
