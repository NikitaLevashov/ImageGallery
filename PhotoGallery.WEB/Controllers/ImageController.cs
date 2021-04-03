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
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.Models;
using PhotoGallery.WEB.Models;

namespace PhotoGallery.WEB.Controllers
{
    
    //[Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly GalleryDBContext _context;
        IPhotoService _photoService;

        public ImageController(IWebHostEnvironment hostEnvironment, GalleryDBContext context, IPhotoService photoService)
        {
            _photoService=photoService;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        //[Route("getlogin")]
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var photos = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos());

            return View(photos);
            
        }

        //[Route("getlogin")]
        //[Authorize]
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
                if (selectedGenres != null)
                {
                    var genres = /*_context.Genres;*/
                    MapperProfile.MapToIEnumerablePLGenres(_photoService.GetGenres());
                    foreach (var c in genres.Where(genre => selectedGenres.Contains(genre.Id)))
                    {
                        imageModel.Genres.Add(c);
                    }
                }
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);

                imageModel.Title = fileName + extension;
                imageModel.Path = $"/img/{fileName}";
                imageModel.Format = extension;
                            
                string path = Path.Combine(wwwRootPath + "/img/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }

                var imageModelDAL = MapperProfile.MapToBLLPhoto(imageModel);

                //_context.Photos.Add(imageModel);
                //_context.SaveChanges();
                _photoService.AddPhoto(imageModelDAL);
                _photoService.Save();

                //_context.Photos.Add(imageModel);
                //_context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                var photos = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
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
                var photos = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
                PhotoViewModel photo = photos.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                {
                    _photoService.Delete(MapperProfile.MapToBLLPhoto(photo));
                    _photoService.Save();
                    //_context.Photos.Remove(photo);
                    //await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var photos = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos());

                var photo = photos.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                    return View(photo);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var photos = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
                var photo = photos.FirstOrDefault(c => c.Id == id);
                if (photo != null)
                    return View(photo);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PhotoViewModel photo)
        {
            _photoService.Update(MapperProfile.MapToBLLPhoto(photo));
            _photoService.Save();
       
            return RedirectToAction("Index");
        }
    }
}