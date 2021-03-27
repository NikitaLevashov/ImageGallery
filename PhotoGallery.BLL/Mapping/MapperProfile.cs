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
    }
}
