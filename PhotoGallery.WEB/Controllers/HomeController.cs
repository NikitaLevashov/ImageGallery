using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.BLL.Filters;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.WEB.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoService _photoService;

        public HomeController(IPhotoService  photoService)
        {
            _photoService = photoService ?? throw new ArgumentNullException("HomeController, PhotoService Error");
        }

        [SetNumbersPhotoFilter]
        public IActionResult Index(int numbersOfPhoto)
       {
            var result = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetAllFiveLastPhotosByGenre(numbersOfPhoto));

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
               
        public IActionResult PhotoSearch()
        {
            return View();
        }
       
        public JsonResult AutoComplete(string prefix)
        {
            List<PhotoViewModel> photoList = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos()).ToList();

            var photos =  (from photo in photoList
                          where photo.Title.StartsWith(prefix) 
                          select new
                          {
                              image = photo.Path,
                              label = photo.Title,
                              val = photo.Id

                          }).ToList();

            return Json(photos);
        }

        [HttpPost]
        public ActionResult PhotoSearch(PhotoViewModel photo)
        {
            List<PhotoViewModel> photoList = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos()).ToList();

            foreach(var item in photoList)
            {
                if(photo.Title==item.Title)
                {
                    ViewBag.Message = item.Path;
                    return View();
                }
            }

            return NotFound();
        }

        public ActionResult Chat()
        {
            return View();
        }

    }
  
}
