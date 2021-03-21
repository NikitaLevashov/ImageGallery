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
        private readonly IAllPhotoToGenreRepository _allPhotoToGenre;

        private readonly IFiveLastPhotoToGenreRepository _fiveLastPhotoToGenre;
        public HomeController(IAllPhotoToGenreRepository allPhotoToGenreRepository, IFiveLastPhotoToGenreRepository fiveLastFhotoToGenreRepository)
        {
            _allPhotoToGenre = allPhotoToGenreRepository;
            _fiveLastPhotoToGenre = fiveLastFhotoToGenreRepository;
        }

        public IActionResult Index()
        {
            var listPhotoToForest = _fiveLastPhotoToGenre.GetFiveLastPhotoToGenre("Forest").ToList();
            var listPhotoToAnimal = _fiveLastPhotoToGenre.GetFiveLastPhotoToGenre("Animals").ToList();
            var listPhotoToMountain = _fiveLastPhotoToGenre.GetFiveLastPhotoToGenre("Mountains").ToList();
            var listPhotoToSpace = _fiveLastPhotoToGenre.GetFiveLastPhotoToGenre("Space").ToList();

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
