using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGallery.DAL.Interfaces
{
    public interface IGenres<T> where T : class
    {
        IEnumerable<T> GetGenres();
    }
}
