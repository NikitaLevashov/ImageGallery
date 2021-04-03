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
            //var configMapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<PhotoViewModel, PhotoBLL>()
            //        .ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.Genres))
            //        .ForMember(res => res.Format, opt => opt.MapFrom(dto => dto.Format))
            //        .ForMember(res => res.Author, opt => opt.MapFrom(dto => dto.Author))
            //        .ForMember(res => res.Id, opt => opt.MapFrom(dto => dto.Id))
            //        .ForMember(res => res.Title, opt => opt.MapFrom(dto => dto.Title))
            //        .ForMember(res => res.Path, opt => opt.MapFrom(dto => dto.Path));

            //    cfg.CreateMap<GenreViewModel, GenreBLL>();
            //});

            ////var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoViewModel, PhotoBLL>());
            //var mapper = new Mapper(configMapper);

            //var genreModel = mapper.Map<PhotoViewModel, PhotoBLL>(photoPL);



            //return genreModel;

            var photoBL = new PhotoBLL
            {
                Id = photoPL.Id,
                Title = photoPL.Title,
                Path = photoPL.Path,
                Format = photoPL.Format,
                Author = photoPL.Author,
                ImageFile = photoPL.ImageFile,
                Genres = new List<GenreBLL>(),
            };

            return photoBL;
            
        }
    }
}
