using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;   
        }
        //Add API EndPoint!


        // Add "Post" New Book To DB!
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        //Show "Get"All Books!
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        //Show "Get" one Book by Id!
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var BookById = _booksService.GetBookById(id);
            return Ok(BookById);
        }


        //Update "PUT" An Existing Book!
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _booksService.updatebookById(id, book);
            return Ok(updatedBook);
        }


        //Delete an Existing Book !
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeletebookById(int id)
        {
            _booksService.DeleteBookbyId(id);
            return Ok();
        }





    }
}
