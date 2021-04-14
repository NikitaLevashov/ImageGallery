using PhotoGallery.DAL.Interfaces;
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
        IGenres<GenreDAL> Genres { get; }
        void AddPhoto(PhotoDAL photo);
        void Update(PhotoDAL photo);
        void Delete(PhotoDAL photo);



    }
}
