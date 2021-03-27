using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly GalleryDBContext _context;

        public ImageController(IWebHostEnvironment hostEnvironment, GalleryDBContext context)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhotoDAL imageModel, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                //string extension = Path.GetExtension(imageModel.ImageFile.FileName);

                //imageModel.Title = fileName + extension;
                //imageModel.Path = $"/img/{fileName}";
                //imageModel.Format = extension;
                                             
                //string path = Path.Combine(wwwRootPath + "/img/", fileName);

                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await imageModel.ImageFile.CopyToAsync(fileStream);
                //}

                //if (selectedGenres != null)
                //{
                //    //получаем выбранные курсы
                //    foreach (var c in _context.Genres.Where(co => selectedGenres.Contains(co.Id)))
                //    {
                //        imageModel.Genres.Add(c);
                //    }
                //}

                //_context.Entry(newPhoto).State = EntityState.Modified;
               




                //imageModel.Genres.Add(_context.Genres.Where(genre => genre.Id == 1).First());
                //_context.Add(imageModel);

                //await _context.SaveChangesAsync();
                //return View();
            }
            return View(imageModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var imageModel = await _context.Photos.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", imageModel.Title);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
           
            _context.Photos.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}