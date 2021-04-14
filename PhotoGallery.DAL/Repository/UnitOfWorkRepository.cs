using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Interfaces;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PhotoGallery.DAL.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
       
        private GalleryDBContext _database;
        private PhotoRepository _photoRepository;
        private GenreRepository _genreRepository;

        public UnitOfWorkRepository(GalleryDBContext database)
        {
            _database = database ?? throw new ArgumentNullException("UnitWorkRepository Error");
        }
        public IPhotos<PhotoDAL> Photos
        {
            get
            {
                if (_photoRepository==null)
                    _photoRepository = new PhotoRepository(_database);
                return _photoRepository;
            }
        }

        public IGenres<GenreDAL> Genres
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(_database);
                return _genreRepository;
            }
        }
        public IPhotos<PhotoDAL> PhotosByGenre
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository(_database);
                return _photoRepository;
            }
        }
        
        public IPhotos<PhotoDAL> FiveLastPhotosByGenre
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository(_database);
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

        public void AddPhoto(PhotoDAL photo)
        {
            _database.Photos.Add(photo);
            _database.SaveChanges();
        }

        public void Update(PhotoDAL photo)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=itacademyphotogallerydb;Trusted_Connection=True;MultipleActiveResultSets=true;";
            using (GalleryDBContext context = new GalleryDBContext(connectionString))
            {
                context.Photos.Update(photo);
                context.SaveChanges();
            }
        }

        public void Delete(PhotoDAL photo)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=itacademyphotogallerydb;Trusted_Connection=True;MultipleActiveResultSets=true;";
            using (GalleryDBContext context = new GalleryDBContext(connectionString))
            {
                context.Photos.Remove(photo);
                context.SaveChanges();
            }
          
        }

    }
}
