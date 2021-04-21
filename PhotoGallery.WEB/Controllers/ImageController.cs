using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.BLL.Intrerfaces;
using PhotoGallery.WEB.Mapping;
using PhotoGallery.WEB.Models;

namespace PhotoGallery.WEB.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IPhotoService _photoService;
        private readonly IPhotoCreation _photoCreation;

        public ImageController(IWebHostEnvironment hostEnvironment, IPhotoService photoService, IPhotoCreation file)
        {
            _photoService=photoService ?? throw new ArgumentNullException("ImageController, PhotoService Error");
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException("ImageController, PhotoService Error");
            _photoCreation = file ?? throw new ArgumentNullException("ImageController, PhotoService Error");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var photos = MapperProfilePhoto.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
                   
            return View(photos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = _photoService.GetGenres().ToList();
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhotoViewModel imageModel, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                var imageCreate = _photoCreation.CreatePhoto(MapperProfilePhoto.MapToBLLPhoto(imageModel), selectedGenres);
                                           
                string path = Path.Combine(_hostEnvironment.WebRootPath + "/img/", imageCreate.Title);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageCreate.ImageFile.CopyToAsync(fileStream);
                }

                _photoService.AddPhoto(imageCreate);
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Genres = _photoService.GetGenres();

            if (id != null)
            {
                var photos = MapperProfilePhoto.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
                var photo = photos.FirstOrDefault(c => c.Id == id);
                if (photo != null)
                    return View(photo);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PhotoViewModel photo, int[] selectedGenres)
        {
            
            if (selectedGenres != null)
            {
                photo.Genres = new List<GenreViewModel>();

                var genres = MapperProfileGenre.MapToIEnumerablePLGenres(_photoService.GetGenres());
                foreach (var c in genres.Where(genre => selectedGenres.Contains(genre.Id)))
                {
                    photo.Genres.Add(c);
                }
            }

            var photoUpdate = _photoService.GetPhotos().Where(s => s.Id == photo.Id).FirstOrDefault();
            photo.Path = photoUpdate.Path;
            photo.Format = photoUpdate.Format;

            _photoService.Update(MapperProfilePhoto.MapToBLLPhoto(photo));
                    
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                var photos = MapperProfilePhoto.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
                PhotoViewModel photo = photos.FirstOrDefault(p => p.Id == id);

                if (photo != null)
                    return View(photo);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var photos = MapperProfilePhoto.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
                var photo = photos.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                {
                    _photoService.Delete(MapperProfilePhoto.MapToBLLPhoto(photo));

                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var photos = MapperProfilePhoto.MapToIEnumerablePLPhotos(_photoService.GetPhotos());

                var photo = photos.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                    return View(photo);
            }
            return NotFound();
        }
    }
}