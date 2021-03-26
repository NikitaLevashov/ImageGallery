using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.WEB.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoService _photoService;
        public HomeController(IPhotoService  photoService)
        {
            _photoService = photoService ?? throw new ArgumentNullException();
        }

        public IActionResult Index()
        {
            var listPhotoToForest = ClassMapping.MapToIEnumerablePLPhotos(_photoService.GetFiveLastPhotoToGenre("Forest").ToList());
            var listPhotoToAnimal = ClassMapping.MapToIEnumerablePLPhotos(_photoService.GetFiveLastPhotoToGenre("Animals").ToList());
            var listPhotoToMountain = ClassMapping.MapToIEnumerablePLPhotos(_photoService.GetFiveLastPhotoToGenre("Mountains").ToList());
            var listPhotoToSpace = ClassMapping.MapToIEnumerablePLPhotos(_photoService.GetFiveLastPhotoToGenre("Space").ToList());

            var result = listPhotoToForest.Union(listPhotoToAnimal).Union(listPhotoToMountain).Union(listPhotoToSpace).ToList();

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
    }
}
