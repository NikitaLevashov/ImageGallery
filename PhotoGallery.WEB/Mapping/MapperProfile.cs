using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.WEB
{
    public class MapperProfile
    {
        public static IEnumerable<PhotoViewModel> MapToIEnumerablePLPhotos(IEnumerable<PhotoBLL> photosDAL)
        {
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoBLL, PhotoViewModel>());
            var mapper = new Mapper(configMapper);

            var photosViewModel = mapper.Map<IEnumerable<PhotoBLL>, IEnumerable<PhotoViewModel>>(photosDAL);

            return photosViewModel;
        }

        public static IEnumerable<GenreViewModel> MapToIEnumerablePLGenres(IEnumerable<GenreBLL> photosBLL)
        {
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreBLL, GenreViewModel>());
            var mapper = new Mapper(configMapper);

            var genresViewModel = mapper.Map<IEnumerable<GenreBLL>, IEnumerable<GenreViewModel>>(photosBLL);

            return genresViewModel;
        }
        public static PhotoBLL MapToBLLPhoto(PhotoViewModel photoPL)
        {
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoViewModel, PhotoBLL>());
            var mapper = new Mapper(configMapper);

            var genreModel = mapper.Map<PhotoViewModel, PhotoBLL>(photoPL);

            return genreModel;
        }
    }
}
