using Microsoft.EntityFrameworkCore;
using PhotoGallery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.EFCore
{
    public class DBObjectPhotoGallery
    {
        public static void Initial(GalleryDBContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
           
                // создание и добавление моделей
                PhotoDAL image1 = new PhotoDAL { /*Id = 1,*/ Title= "Bitle1", Author="Author1", Format="jpg", Path="/img/image1.jpg"};
                PhotoDAL image2 = new PhotoDAL { /*Id = 2,*/ Title = "Bitle2", Author = "Author2", Format = "jpg", Path = "/img/image2.jpg" };
                PhotoDAL image3 = new PhotoDAL { /*Id = 3,*/ Title = "Title3", Author = "Author3", Format = "jpg", Path = "/img/image3.jpg" };
                PhotoDAL image4 = new PhotoDAL { /*Id = 4,*/ Title = "Title4", Author = "Author4", Format = "jpg", Path = "/img/image4.jpg" };
                PhotoDAL image5 = new PhotoDAL { /*Id = 5,*/ Title = "Title5", Author = "Author5", Format = "jpg", Path = "/img/image5.jpg" };
                PhotoDAL image6 = new PhotoDAL { /*Id = 6,*/ Title = "Title6", Author = "Author6", Format = "jpg", Path = "/img/image6.jpg" };
                PhotoDAL image7 = new PhotoDAL { /*Id = 7,*/ Title = "Title7", Author = "Author7", Format = "jpg", Path = "/img/image7.jpg" };
                PhotoDAL image8 = new PhotoDAL { /*Id = 8,*/ Title = "Citle8", Author = "Author8", Format = "jpg", Path = "/img/image8.jpg" };
                PhotoDAL image9 = new PhotoDAL { /*Id = 9,*/ Title = "Citle9", Author = "Author9", Format = "jpg", Path = "/img/image9.jpg" };
                PhotoDAL image10 = new PhotoDAL { /*Id = 10,*/ Title = "Citle10", Author = "Author10", Format = "jpg", Path = "/img/image10.jpg" };
                PhotoDAL image11 = new PhotoDAL { /*Id = 11,*/ Title = "Citle11", Author = "Author11", Format = "jpg", Path = "/img/image11.jpg" };
                PhotoDAL image12 = new PhotoDAL { /*Id = 12,*/ Title = "Title12", Author = "Author12", Format = "jpg", Path = "/img/image12.jpg" };
                PhotoDAL image13 = new PhotoDAL { /*Id = 13,*/ Title = "Titblle13", Author = "Author13", Format = "jpg", Path = "/img/image13.jpg" };
                PhotoDAL image14 = new PhotoDAL { /*Id = 14,*/ Title = "Titblble14", Author = "Author14", Format = "jpg", Path = "/img/image14.jpg" };
                PhotoDAL image15 = new PhotoDAL { /*Id = 15,*/ Title = "Title15", Author = "Author15", Format = "jpg", Path = "/img/image15.jpg" };
                PhotoDAL image16 = new PhotoDAL {/* Id = 16,*/ Title = "Toole16", Author = "Author16", Format = "jpg", Path = "/img/image16.jpg" };
                PhotoDAL image17 = new PhotoDAL { /*Id = 17,*/ Title = "Tooe17", Author = "Author17", Format = "jpg", Path = "/img/image17.jpg" };
                PhotoDAL image18 = new PhotoDAL { /*Id = 18,*/ Title = "Toile18", Author = "Author18", Format = "jpg", Path = "/img/image18.jpg" };

                db.Photos.AddRange(image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18);
                
                GenreDAL genre1 = new GenreDAL { /*Id = 1,*/ Name = "Animals", Description = "Description1" };
                GenreDAL genre2 = new GenreDAL { /*Id = 2,*/ Name = "Forest", Description = "Description2" };
                GenreDAL genre3 = new GenreDAL { /*Id = 3,*/ Name = "Mountains", Description = "Description3" };
                GenreDAL genre4 = new GenreDAL { /*Id = 4,*/ Name = "Space", Description = "Description4" };

                db.Genres.AddRange(genre1,genre2,genre3,genre4);

                genre1.Photos.AddRange(new List<PhotoDAL>() { image5, image6, image7, image8, image9, image10, image11, image12, image13, image14});
                genre2.Photos.AddRange(new List<PhotoDAL>() { image1, image2, image3, image4, image5, image6, image7, image8, image11, image15 });
                genre3.Photos.AddRange(new List<PhotoDAL>() { image9, image10, image11, image12, image13});
                genre4.Photos.AddRange(new List<PhotoDAL>() { image16, image17, image18});

                //AdminDAL admin1 = new AdminDAL { Email = "1213dd@mail.ru", Password = "123" };
                //AdminDAL admin2 = new AdminDAL { Email = "1263dd@tut.by", Password = "12454" };
                //AdminDAL admin3 = new AdminDAL { Email = "12453dd@gmail.com", Password = "12334" };
                //AdminDAL admin4 = new AdminDAL { Email = "1213dd@mail.ru", Password = "1233434" };
                //AdminDAL admin5 = new AdminDAL { Email = "12gfdd@yandex.ru", Password = "1234343" };
                //AdminDAL admin6 = new AdminDAL { Email = "12ggdd@outlook.com", Password = "12343434" };

                db.SaveChanges();
            //}
        }
    }
}
