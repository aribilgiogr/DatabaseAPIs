using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBooksService service) : ControllerBase
    {
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get() => await service.GetAsync();

        // GET api/<BooksController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var book = await service.GetAsync(id);
            if (book is null) return NotFound();
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book newBook)
        {
            await service.InsertAsync(newBook);
            return CreatedAtAction(nameof(Get), newBook.Id);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Book updatedBook)
        {
            var book = await service.GetAsync(id);
            if (book is null) return NotFound();
            updatedBook.Id = book.Id;
            await service.ReplaceAsync(id, updatedBook);
            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await service.GetAsync(id);
            if (book is null) return NotFound();
            await service.DeleteAsync(id);
            return NoContent();
        }
    }
}
