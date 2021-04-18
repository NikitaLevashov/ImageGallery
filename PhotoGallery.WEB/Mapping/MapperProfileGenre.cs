using AutoMapper;
using PhotoGallery.BLL.Models;
using PhotoGallery.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.WEB.Mapping
{
    public class MapperProfileGenre
    {
        public static IEnumerable<GenreBLL> MapToIEnumerableBLGenres(IEnumerable<GenreViewModel> photosPL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<GenreViewModel, GenreBLL>());
            var mapper = new Mapper(configMapper);

            var genresViewModel = mapper.Map<IEnumerable<GenreViewModel>, IEnumerable<GenreBLL>>(photosPL);

            return genresViewModel;
        }

        public static IEnumerable<GenreViewModel> MapToIEnumerablePLGenres(IEnumerable<GenreBLL> photosBLL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<GenreBLL, GenreViewModel>());
            var mapper = new Mapper(configMapper);

            var genresViewModel = mapper.Map<IEnumerable<GenreBLL>, IEnumerable<GenreViewModel>>(photosBLL);

            return genresViewModel;
        }
    }
}
