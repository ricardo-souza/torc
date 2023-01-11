using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using Torc.API.Services;

namespace Torc.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetBooksAsync();

            if (books == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "Books not found");
            }

            return StatusCode(StatusCodes.Status200OK, books);
        }
    }
}
