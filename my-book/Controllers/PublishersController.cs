using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Models;
using my_book.Data.Services;
using my_book.Data.ViewModels;
using my_book.Exceptions;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        // Add "Post" New Publisher To DB!
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, publisher name: {ex.PublisherName}");
            }
            catch (System.Exception ex)
            {
                return  BadRequest(ex.Message);
              
            }


        }


        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            throw new System.Exception("This is an exception that will handled by middleware");
            var _response = _publishersService.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }




        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {

                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (System.Exception  ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
