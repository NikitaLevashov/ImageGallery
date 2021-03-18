using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.EFCore
{
    public class DBObjectPhotoGallery
    {
        public static void Initial()
        {
            using (GalleryDBContext db = new GalleryDBContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // создание и добавление моделей
                PhotoDAL image1 = new PhotoDAL { Id=1, Title="Title1", Author="Author1", Format="jpg", Path="~/img/image1.jpg"};
                PhotoDAL image2 = new PhotoDAL { Id = 2, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image2.jpg" };
                PhotoDAL image3 = new PhotoDAL { Id = 3, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image3.jpg" };
                PhotoDAL image4 = new PhotoDAL { Id = 4, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image4.jpg" };
                PhotoDAL image5 = new PhotoDAL { Id = 5, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image5.jpg" };
                PhotoDAL image6 = new PhotoDAL { Id = 6, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image6.jpg" };
                PhotoDAL image7 = new PhotoDAL { Id = 7, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image7.jpg" };
                PhotoDAL image8 = new PhotoDAL { Id = 8, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image8.jpg" };
                PhotoDAL image9 = new PhotoDAL { Id = 9, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image9.jpg" };
                PhotoDAL image10 = new PhotoDAL { Id = 10, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image10.jpg" };
                PhotoDAL image11 = new PhotoDAL { Id = 11, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image11.jpg" };
                PhotoDAL image12 = new PhotoDAL { Id = 12, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image12.jpg" };
                PhotoDAL image13 = new PhotoDAL { Id = 13, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image13.jpg" };
                PhotoDAL image14 = new PhotoDAL { Id = 14, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image14.jpg" };
                PhotoDAL image15 = new PhotoDAL { Id = 15, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image15.jpg" };
                PhotoDAL image16 = new PhotoDAL { Id = 16, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image16.jpg" };
                PhotoDAL image17 = new PhotoDAL { Id = 17, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image17.jpg" };
                PhotoDAL image18 = new PhotoDAL { Id = 18, Title = "Title1", Author = "Author1", Format = "jpg", Path = "~/img/image18.jpg" };

                db.Photos.AddRange(image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18);
                
                GenreDAL genre1 = new GenreDAL { Id = 1, Name = "Animals", Description = "Description1" };
                GenreDAL genre2 = new GenreDAL { Id = 2, Name = "Forest", Description = "Description2" };
                GenreDAL genre3 = new GenreDAL { Id = 3, Name = "Mountains", Description = "Description3" };
                GenreDAL genre4 = new GenreDAL { Id = 4, Name = "Spase", Description = "Description4" };
                
                db.Genres.AddRange(genre1,genre2,genre3,genre4);

                // добавляем к студентам курсы
                genre1.Photos.AddRange(new List<PhotoDAL>() { image5, image6, image7, image8, image9, image10, image11, image12, image13, image14});
                genre2.Photos.AddRange(new List<PhotoDAL>() { image1, image2, image3, image4, image5, image6, image7, image8, image11, image15 });
                genre3.Photos.AddRange(new List<PhotoDAL>() { image9, image10, image11, image12, image13});
                genre3.Photos.AddRange(new List<PhotoDAL>() { image16, image17, image18});
            
                db.SaveChanges();
            }
        }
    }
}
