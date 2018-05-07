﻿using Domain.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook.Factory
{
    public interface IBookFactory
    {
        Book Create(string title,string description,DateTime publishOn,string author);
    }
}