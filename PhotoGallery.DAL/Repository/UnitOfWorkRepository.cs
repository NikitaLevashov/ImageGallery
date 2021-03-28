using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Interfaces;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private GalleryDBContext _database;
        private PhotoRepository _photoRepository;
        private GenreRepository _genreRepository;
        public UnitOfWorkRepository()
        {
            _database = new GalleryDBContext();
        }
        public IPhotos<PhotoDAL> Photos
        {
            get
            {
                if (_photoRepository==null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }

        public IGenres<GenreDAL> Genres
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository();
                return _genreRepository;
            }
        }
        public IPhotos<PhotoDAL> PhotosByGenre
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }
        
        public IPhotos<PhotoDAL> FiveLastPhotosByGenre
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _database.SaveChanges();
        }

        public void AddPhoto(PhotoDAL photo)
        {
            _database.Photos.Add(photo);
        }

       
        public void Update(PhotoDAL photo)
        {
            _database.Photos.Update(photo);
        }

        public void Delete(PhotoDAL photo)
        {
            _database.Photos.Remove(photo);
        }


        
    }
}
