using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.WEB.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class GalleryController : Controller
    {

        private readonly IPhotoService _photoService;
        public GalleryController(IPhotoService photoService)
        {
            _photoService = photoService ?? throw new ArgumentNullException();
        }
      
        public IActionResult PhotoViewToGenre(string genre)
        {
            IEnumerable<PhotoViewModel> listPhotoToGenre;

            if (genre != null)
            {
                listPhotoToGenre = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotosByGenre(genre).ToList());
            }
            else
            {
                listPhotoToGenre = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos().ToList());
            }
           
            return View(listPhotoToGenre);
        }
    }
}