using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.interfaces;
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
        public UnitOfWorkRepository()
        {
            _database = new GalleryDBContext();
        }
        public IAllPhotoRepository<PhotoDAL> AllPhotos
        {
            get
            {
                if (_photoRepository==null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }
        public IAllPhotoToGenreRepository<PhotoDAL> AllPhotosToGenre
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }
        
        public IFiveLastPhotoToGenreRepository<PhotoDAL> FiveLastPhotoToGenre
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
    }
}
