﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.interfaces
{
    public interface IPhotos<T> where T: class
    {
        IEnumerable<T> GetPhotos();
        IEnumerable<T> GetPhotosByGenre(string genre);
        IEnumerable<T> GetFiveLastPhotosByGenre();
        void AddPhoto(T photo);
        void Save(T photo);
        void Update(T photo);
        void Delete(T photo);

    }
}