using my_book.Data.Models;
using my_book.Data.ViewModels;
using my_book.Exceptions;
using my_books.Data;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace my_book.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;

        }


        //We create a VM For Taking A speciefic props From main Model which user need it
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartWithNumber(publisher.Name)) throw new PublisherNameException("Starts with Number",
                publisher.Name);

            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher GetPublisherById(int id)=> _context.Publishers.FirstOrDefault(n=>n.Id==id);


        public PublisherWithBooksAndAuthorVM GetPublisherData (int publisherId)
        {
            var _publisherData = _context.Publishers.Where(x => x.Id == publisherId)
                .Select(x => new PublisherWithBooksAndAuthorVM()
                {
                    Name=x.Name,
                    BookAuthors = x.Books.Select(n=> new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(x =>x.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);

            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The Publisher with id {id} Doesn't Exist!");
            }
        
        }

        private bool StringStartWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
