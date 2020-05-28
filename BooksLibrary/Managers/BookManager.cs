using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BooksLibrary.Enums;
using BooksLibrary.Models;

namespace BooksLibrary.Managers
{
    public class BookManager
    {
        public List<Book> books;
        public List<Book> typeBooks;
        public string SelectedType { get; set; }
        public BookManager()
        {
            books = new List<Book>
            {
                new Book{BookId = Guid.NewGuid(), Name = "Superman", Type = BookType.Fantasy, BookState = BookState.Active},
                new Book{BookId = Guid.NewGuid(), Name = "HowToKillMyWife", Type = BookType.Drama, BookState = BookState.NonActive},
                new Book{BookId = Guid.NewGuid(), Name = "Hercules", Type = BookType.Legend, BookState = BookState.Read},
                new Book{BookId = Guid.NewGuid(), Name = "Batman", Type = BookType.Fantasy, BookState = BookState.NonActive}
            };
            typeBooks = books;
            SelectedType = "All";
        }

        public void AddBook(string bookName, string bookType, string bookState)
        {
            Book book = new Book
            {
                BookId = Guid.NewGuid(),
                Name = bookName,
                Type = (BookType)Enum.Parse(typeof(BookType), bookType),
                BookState = (BookState) Enum.Parse(typeof(BookState), bookState)
            };
            books.Add(book);
        }

        public void RemoveBook(string id)
        {
            Guid bookId = Guid.Parse(id);
            Book book = books.FirstOrDefault(b => b.BookId == bookId);
            books.Remove(book);
            typeBooks.Remove(book);
        }

        public void ChangeType(string type)
        {
            SelectedType = type;
            typeBooks = new List<Book>();
            if (type == "All")
            {
                typeBooks = books;
                return;
            }

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Type.ToString() == type)
                {
                    typeBooks.Add(books[i]);
                }
            }
        }

        public void ChangeState(string id, string state)
        {
            Guid bookId = Guid.Parse(id);
            books.FirstOrDefault(b => b.BookId == bookId).BookState = (BookState)Enum.Parse(typeof(BookState), state);
            typeBooks.FirstOrDefault(b => b.BookId == bookId).BookState = (BookState)Enum.Parse(typeof(BookState), state);
        }
    }
}