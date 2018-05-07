using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishOn { get; set; }
        public string Author { get; set; }
    }
}
