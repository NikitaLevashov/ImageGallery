using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPhotos<PhotoDAL> Photos { get; }
        IPhotos<PhotoDAL> PhotosByGenre { get; }
        IPhotos<PhotoDAL> FiveLastPhotosByGenre { get; }
    }
}
