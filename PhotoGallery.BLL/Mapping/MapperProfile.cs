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
        public static PhotoDAL MapToDALPhoto(PhotoBLL photoBL)
        {
            //var configMapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<PhotoBLL, PhotoDAL>()
            //        .ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.Genres))
            //        .ForMember(res => res.Format, opt => opt.MapFrom(dto => dto.Format))
            //        .ForMember(res => res.Author, opt => opt.MapFrom(dto => dto.Author))
            //        .ForMember(res => res.Id, opt => opt.MapFrom(dto => dto.Id))
            //        .ForMember(res => res.Title, opt => opt.MapFrom(dto => dto.Title))
            //        .ForMember(res => res.Path, opt => opt.MapFrom(dto => dto.Path));


            //    cfg.CreateMap<GenreBLL, GenreDAL>();
            //});

            ////var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreBLL, GenreDAL>());
            //var mapper = new Mapper(configMapper);



            //var genreModel = mapper.Map<PhotoBLL,PhotoDAL>(photoDAL);

            //return genreModel;

            var photoDAL = new PhotoDAL
            {
                Id = photoBL.Id,
                Title = photoBL.Title,
                Path = photoBL.Path,
                Format = photoBL.Format,
                Author = photoBL.Author,
                ImageFile = photoBL.ImageFile,
                Genres = new List<GenreDAL>(),
            };

            return photoDAL;
        }
    }
}
