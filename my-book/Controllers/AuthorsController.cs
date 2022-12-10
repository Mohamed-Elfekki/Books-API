using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Models;
using my_book.Data.Services;
using my_book.Data.ViewModels;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // Add "Post" New Author To DB!
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-book-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
           var response = _authorsService.GetAuthorWithBooks(id);
            return Ok(response);
        }
    }
}
