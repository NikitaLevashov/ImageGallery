using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.WEB
{
    public class ClassMapping
    {
        public static IEnumerable<PhotoViewModel> MapToIEnumerablePLPhotos(IEnumerable<PhotoBLL> photosDAL)
        {
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoBLL, PhotoViewModel>());
            var mapper = new Mapper(configMapper);

            var photosViewModel = mapper.Map<IEnumerable<PhotoBLL>, IEnumerable<PhotoViewModel>>(photosDAL);

            return photosViewModel;
        }
    }
}
