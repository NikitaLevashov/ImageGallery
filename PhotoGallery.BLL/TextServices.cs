using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.BLL.Models;

namespace PhotoGallery.BLL
{
    class TextServices
    {
        //private readonly 
        //private readonly IWebHostEnvironment _hostEnvironment;
        //public TextServices(IWebHostEnvironment hostEnvironment)
        //{
        //    _hostEnvironment = hostEnvironment;
        //}
        //public async Task WriteToFile(PhotoBLL imageModel)
        //{
        //    string wwwRootPath = _hostEnvironment.WebRootPath;
        //    string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
        //    string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            
        //    string path = Path.Combine(wwwRootPath + "/img/", fileName);

        //    using (var fileStream = new FileStream(path, FileMode.Create))
        //    {
        //        await imageModel.ImageFile.CopyToAsync(fileStream);
        //    }
        //}
    }
}
