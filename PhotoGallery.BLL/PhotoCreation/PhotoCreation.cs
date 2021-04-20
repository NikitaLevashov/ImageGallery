using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using PhotoGallery.BLL.Mapping;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.BLL.Intrerfaces;

namespace PhotoGallery.BLL.PathService
{
    public class PhotoCreation : IPhotoCreation
    {
        private readonly IPhotoService _photoService;

        public PhotoCreation(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public PhotoBLL CreatePhoto(PhotoBLL imageModelBL, int[] selectedGenres)
        {
            if (selectedGenres != null)
            {
                var genres = _photoService.GetGenres();
                foreach (var c in genres.Where(genre => selectedGenres.Contains(genre.Id)))
                {
                    imageModelBL.Genres.Add(c);
                }
            }

            string fileName = Path.GetFileNameWithoutExtension(imageModelBL.ImageFile.FileName);
            string extension = Path.GetExtension(imageModelBL.ImageFile.FileName);

            imageModelBL.Title = fileName + extension;
            imageModelBL.Path = $"/img/{fileName+ extension}";
            imageModelBL.Format = extension;

            return imageModelBL;
        }

        //public void AddPhotoFileSysteam(PhotoBLL imageModelBL)
        //{
        //    string wwwRootPath = _hostEnvironment.WebRootPath;
        //    string fileName = Path.GetFileNameWithoutExtension(imageModelBL.ImageFile.FileName);
        //    string path = Path.Combine(wwwRootPath + "/img/", fileName);

        //    using (var fileStream = new FileStream(path, FileMode.Create))
        //    {
        //        imageModelBL.ImageFile.CopyToAsync(fileStream);
        //    }

        //}
    }
}
