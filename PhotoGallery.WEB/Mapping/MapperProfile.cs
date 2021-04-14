﻿using AutoMapper;
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
            var configMapper = new MapperConfiguration(config => config.CreateMap<PhotoBLL, PhotoViewModel>());
            var mapper = new Mapper(configMapper);

            var photosViewModel = mapper.Map<IEnumerable<PhotoBLL>, IEnumerable<PhotoViewModel>>(photosDAL);

            return photosViewModel;
        }

        public static IEnumerable<GenreViewModel> MapToIEnumerablePLGenres(IEnumerable<GenreBLL> photosBLL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<GenreBLL, GenreViewModel>());
            var mapper = new Mapper(configMapper);

            var genresViewModel = mapper.Map<IEnumerable<GenreBLL>, IEnumerable<GenreViewModel>>(photosBLL);

            return genresViewModel;
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
                Genres = new List<GenreBLL>()?? throw new NullReferenceException()
            };

            return photoBL;
        }
    }
}
