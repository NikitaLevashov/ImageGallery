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
                listPhotoToGenre = ClassMapping.MapToIEnumerablePLPhotos(_photoService.GetAllFotoToGenry(genre).ToList());
            }
            else
            {
                listPhotoToGenre = ClassMapping.MapToIEnumerablePLPhotos(_photoService.GetAllPhoto().ToList());
            }
           
            return View(listPhotoToGenre);
        }
    }
}