using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.WEB.Mapping;
using PhotoGallery.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.WEB
{
    public class MapperProfilePhoto
    {
        public static IEnumerable<PhotoViewModel> MapToIEnumerablePLPhotos(IEnumerable<PhotoBLL> photosDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<PhotoBLL, PhotoViewModel>());
            var mapper = new Mapper(configMapper);

            var photosViewModel = mapper.Map<IEnumerable<PhotoBLL>, IEnumerable<PhotoViewModel>>(photosDAL);

            return photosViewModel;
        }

        public static PhotoBLL MapToBLLPhoto(PhotoViewModel photoPL)
        {
            var photoBL = new PhotoBLL
            {
                Id = photoPL.Id,
                Title = photoPL?.Title ?? "not installed",
                Path = photoPL?.Path ?? "not installed",
                Format = photoPL?.Format ?? "not installed",
                Author = photoPL?.Author ?? "not installed",
                ImageFile = photoPL?.ImageFile ?? null,
            };

            photoBL.Genres.AddRange(MapperProfileGenre.MapToIEnumerableBLGenres(photoPL.Genres));

            return photoBL;
        }
    }
}
