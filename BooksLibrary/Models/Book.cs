using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BooksLibrary.Enums;

namespace BooksLibrary.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public BookType Type { get; set; }
        public BookState BookState { get; set; }
    }
}