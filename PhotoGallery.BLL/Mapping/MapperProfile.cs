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
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDAL, PhotoBLL>());
            var mapper = new Mapper(configMapper);

            var photosBLL = mapper.Map<IEnumerable<PhotoDAL>, IEnumerable<PhotoBLL>>(photosDAL);

            return photosBLL;
        }

        public static IEnumerable<GenreBLL> MapToIEnumerableBLLGenres(IEnumerable<GenreDAL> photosDAL)
        {
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDAL, GenreBLL>());
            var mapper = new Mapper(configMapper);

            var genreModel = mapper.Map<IEnumerable<GenreDAL>, IEnumerable<GenreBLL>>(photosDAL);
           
            return genreModel;
        }
        public static PhotoDAL MapToDALPhoto(PhotoBLL photoDAL)
        {
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreBLL, GenreDAL>());
            var mapper = new Mapper(configMapper);

            var genreModel = mapper.Map<PhotoBLL,PhotoDAL>(photoDAL);
            
            return genreModel;
        }
    }
}
