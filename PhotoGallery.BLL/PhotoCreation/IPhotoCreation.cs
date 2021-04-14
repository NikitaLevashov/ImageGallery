using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.BLL.PathService
{
    public interface IPhotoCreation
    {
        public PhotoBLL CreatePhoto(PhotoBLL imageModelBL, int[] selectedGenres);
        //public void AddPhotoFileSysteam(PhotoBLL imageModelBL);
    }
}
