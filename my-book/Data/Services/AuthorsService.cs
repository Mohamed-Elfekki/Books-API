using my_book.Data.Models;
using my_book.Data.ViewModels;
using my_books.Data;
using System;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace my_book.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;

        }


        //We create a VM For Taking A speciefic props From main Model which user need it
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName=n.FullName,
                BookTitles = n.Book_Authors.Select(n=>n.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
