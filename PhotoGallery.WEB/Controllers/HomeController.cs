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
            _photoService = photoService ?? throw new ArgumentNullException("HomeController, PhotoService Error");
        }

        public IActionResult Index()
        {
            var result = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetFiveLastPhotosByGenre());

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

        public ActionResult PhotoSearch(string name)
        {
            var allbooks = _photoService.GetPhotos().Where(a => a.Title.Contains(name)).ToList();
            return PartialView(allbooks);
        }
    }
}
