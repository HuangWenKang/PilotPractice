using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Article;
using Domain.Book;
using Domain.Courses;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<Course> Courses { get; set; }        

        void Save();
    }
}
