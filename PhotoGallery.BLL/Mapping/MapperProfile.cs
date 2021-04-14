using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.Mapping
{
    public class MapperProfile
    {
        public static IEnumerable<PhotoBLL> MapToIEnumerableBLLPhotos(IEnumerable<PhotoDAL> photosDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<PhotoDAL, PhotoBLL>());
            var mapper = new Mapper(configMapper);

            var photosBLL = mapper.Map<IEnumerable<PhotoDAL>, IEnumerable<PhotoBLL>>(photosDAL);

            return photosBLL;
        }

        public static IEnumerable<GenreBLL> MapToIEnumerableBLLGenres(IEnumerable<GenreDAL> photosDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<GenreDAL, GenreBLL>());
            var mapper = new Mapper(configMapper);

            var genreModel = mapper.Map<IEnumerable<GenreDAL>, IEnumerable<GenreBLL>>(photosDAL);
           
            return genreModel;
        }

        public static IEnumerable<GenreDAL> MapToIEnumerableDALGenres(IEnumerable<GenreBLL> photosDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<GenreBLL, GenreDAL>());
            var mapper = new Mapper(configMapper);

            var genreModel = mapper.Map<IEnumerable<GenreBLL>, IEnumerable<GenreDAL>>(photosDAL);

            return genreModel;
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
                Genres = new List<GenreDAL>() ?? throw new NullReferenceException()
            };

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
