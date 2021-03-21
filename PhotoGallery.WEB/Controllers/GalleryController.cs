using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class GalleryController : Controller
    {

        private readonly IAllPhotoToGenreRepository _allPhotoToGenre;
        private readonly IAllPhotoRepository _allPhoto;
        public GalleryController(IAllPhotoToGenreRepository allPhotoToGenre, IAllPhotoRepository allPhoto)
        {
            _allPhoto = allPhoto;
            _allPhotoToGenre = allPhotoToGenre;
        }
      
        public IActionResult PhotoViewToGenre(string genre)
        {
            IEnumerable<PhotoDAL> listPhotoToGenre;

            if (genre!=null)
            {
                listPhotoToGenre = _allPhotoToGenre.GetAllFotoToGenry(genre).ToList();
            }
            else
            {
                listPhotoToGenre = _allPhoto.GetAllPhoto().ToList();
            }
           
            return View(listPhotoToGenre);
        }
    }
}