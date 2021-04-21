using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Interfaces;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace PhotoGallery.DAL.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
       
        private GalleryDBContext _database;
        private PhotoRepository _photoRepository;
        private GenreRepository _genreRepository;
        private readonly IConfiguration _configuration;

        public UnitOfWorkRepository(GalleryDBContext database, IConfiguration configuration)
        {
            _database = database ?? throw new ArgumentNullException("UnitWorkRepository Error");
            _configuration = configuration;
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
            if(photo!=null)
            {
                var photoGenres = photo.Genres;
                var dataBaseGenres = _database.Genres;

                photo.Genres = null;

                foreach (var itemDataBase in dataBaseGenres)
                {
                    foreach (var itemPhotoGenres in photoGenres)
                    {
                        if (itemPhotoGenres.Id == itemDataBase.Id)
                        {
                            itemDataBase.Photos.AddRange(new List<PhotoDAL>() { photo });
                        }
                    }
                }
            }
           
            _database.Photos.AsNoTracking();
            _database.SaveChanges();
        }

        public void Update(PhotoDAL photo)
        {
            using (GalleryDBContext context = new GalleryDBContext(_configuration["Data:GalleryPhoto:ConnectionStrings"]))
            {
                context.Photos.Update(photo);
                context.SaveChanges();
            }

        }

        public void Delete(PhotoDAL photo)
        {
            using (GalleryDBContext context = new GalleryDBContext(_configuration["Data:GalleryPhoto:ConnectionStrings"]))
            {
                context.Photos.Remove(photo);
                context.SaveChanges();
            }
        }

    }
}
