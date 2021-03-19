using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.WEB.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAllPhotoToGenreRepository _allPhotoToGenre;

        private readonly IFiveLastPhotoToGenreRepository _fiveLastPhotoToGenre;
        public HomeController(ILogger<HomeController> logger, IAllPhotoToGenreRepository allPhotoToGenreRepository, IFiveLastPhotoToGenreRepository fiveLastFhotoToGenreRepository)
        {
            _logger = logger;
            _allPhotoToGenre = allPhotoToGenreRepository;
            _fiveLastPhotoToGenre = fiveLastFhotoToGenreRepository;
        }

        public IActionResult Index()
        {
            var item = _fiveLastPhotoToGenre.GetFiveLastPhotoToGenre("Forest").ToList();
            ViewBag.Photo = item;

            return View();
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
