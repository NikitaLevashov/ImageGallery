using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.BLL.Mapping
{
    public class MapperProfileGenre
    {

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
    }
}
