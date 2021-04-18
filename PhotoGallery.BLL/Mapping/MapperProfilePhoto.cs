using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.Mapping
{
    public class MapperProfilePhoto
    {
        public static IEnumerable<PhotoBLL> MapToIEnumerableBLLPhotos(IEnumerable<PhotoDAL> photosDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<PhotoDAL, PhotoBLL>());
            var mapper = new Mapper(configMapper);

            var photosBLL = mapper.Map<IEnumerable<PhotoDAL>, IEnumerable<PhotoBLL>>(photosDAL);

            return photosBLL;
        }


        public static PhotoDAL MapToDALPhoto(PhotoBLL photoBL)
        {
            var photoDAL = new PhotoDAL
            {
                Id = photoBL.Id,
                Title = photoBL?.Title ?? "not installed",
                Path = photoBL?.Path ?? "not installed",
                Format = photoBL?.Format ?? "not installed",
                Author = photoBL?.Author ?? "not installed",
                ImageFile = photoBL?.ImageFile ?? null,
            };

            //photoDAL.Genres.AddRange(MapperProfileGenre.MapToIEnumerableDALGenres(photoBL.Genres));

            return photoDAL;
        }

        public static PhotoBLL MapToBLLPhoto(PhotoDAL photoBL)
        {
            var photoDAL = new PhotoBLL
            {
                Id = photoBL.Id,
                Title = photoBL?.Title ?? "not installed",
                Path = photoBL?.Path ?? "not installed",
                Format = photoBL?.Format ?? "not installed",
                Author = photoBL?.Author ?? "not installed",
                ImageFile = photoBL?.ImageFile ?? throw new NullReferenceException(),
                Genres = new List<GenreBLL>() ?? throw new NullReferenceException()
            };

            return photoDAL;
        }
    }
}
