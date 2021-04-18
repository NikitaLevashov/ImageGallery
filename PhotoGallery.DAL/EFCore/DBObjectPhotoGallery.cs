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
           
                PhotoDAL image1 = new PhotoDAL  {  Title= "Bitle1", Author="Author1", Format="jpg", Path="/img/image1.jpg"};
                PhotoDAL image2 = new PhotoDAL  {  Title = "Bitle2", Author = "Author2", Format = "jpg", Path = "/img/image2.jpg" };
                PhotoDAL image3 = new PhotoDAL  {  Title = "Title3", Author = "Author3", Format = "jpg", Path = "/img/image3.jpg" };
                PhotoDAL image4 = new PhotoDAL  {  Title = "Title4", Author = "Author4", Format = "jpg", Path = "/img/image4.jpg" };
                PhotoDAL image5 = new PhotoDAL  {  Title = "Title5", Author = "Author5", Format = "jpg", Path = "/img/image5.jpg" };
                PhotoDAL image6 = new PhotoDAL  {  Title = "Title6", Author = "Author6", Format = "jpg", Path = "/img/image6.jpg" };
                PhotoDAL image7 = new PhotoDAL  {  Title = "Title7", Author = "Author7", Format = "jpg", Path = "/img/image7.jpg" };
                PhotoDAL image8 = new PhotoDAL  {  Title = "Citle8", Author = "Author8", Format = "jpg", Path = "/img/image8.jpg" };
                PhotoDAL image9 = new PhotoDAL  {  Title = "Citle9", Author = "Author9", Format = "jpg", Path = "/img/image9.jpg" };
                PhotoDAL image10 = new PhotoDAL {  Title = "Citle10", Author = "Author10", Format = "jpg", Path = "/img/image10.jpg" };
                PhotoDAL image11 = new PhotoDAL {  Title = "Citle11", Author = "Author11", Format = "jpg", Path = "/img/image11.jpg" };
                PhotoDAL image12 = new PhotoDAL {  Title = "Title12", Author = "Author12", Format = "jpg", Path = "/img/image12.jpg" };
                PhotoDAL image13 = new PhotoDAL {  Title = "Titblle13", Author = "Author13", Format = "jpg", Path = "/img/image13.jpg" };
                PhotoDAL image14 = new PhotoDAL {  Title = "Titblble14", Author = "Author14", Format = "jpg", Path = "/img/image14.jpg" };
                PhotoDAL image15 = new PhotoDAL {  Title = "Title15", Author = "Author15", Format = "jpg", Path = "/img/image15.jpg" };
                PhotoDAL image16 = new PhotoDAL {  Title = "Toole16", Author = "Author16", Format = "jpg", Path = "/img/image16.jpg" };
                PhotoDAL image17 = new PhotoDAL {  Title = "Tooe17", Author = "Author17", Format = "jpg", Path = "/img/image17.jpg" };
                PhotoDAL image18 = new PhotoDAL {  Title = "Toile18", Author = "Author18", Format = "jpg", Path = "/img/image18.jpg" };

                db.Photos.AddRange(image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18);
                
                GenreDAL genre1 = new GenreDAL { Name = "Animals", Description = "Description1" };
                GenreDAL genre2 = new GenreDAL { Name = "Forest", Description = "Description2" };
                GenreDAL genre3 = new GenreDAL { Name = "Mountains", Description = "Description3" };
                GenreDAL genre4 = new GenreDAL { Name = "Space", Description = "Description4" };

                db.Genres.AddRange(genre1,genre2,genre3,genre4);

                genre1.Photos.AddRange(new List<PhotoDAL>() { image5, image6, image7, image8, image9, image10, image11, image12, image13, image14});
                genre2.Photos.AddRange(new List<PhotoDAL>() { image1, image2, image3, image4, image5, image6, image7, image8, image11, image15 });
                genre3.Photos.AddRange(new List<PhotoDAL>() { image9, image10, image11, image12, image13});
                genre4.Photos.AddRange(new List<PhotoDAL>() { image16, image17, image18});
            
                db.SaveChanges();
        }
    }
}
