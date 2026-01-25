using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IAuthorService service) : ControllerBase
    {
        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IEnumerable<Author>> Get() => await service.GetAsync();

        // GET api/<AuthorsController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var author = await service.GetAsync(id);
            if (author is null) return NotFound();
            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author newAuthor)
        {
            await service.InsertAsync(newAuthor);
            return CreatedAtAction(nameof(Get), newAuthor.Id);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Author updatedAuthor)
        {
            var author = await service.GetAsync(id);
            if (author is null) return NotFound();
            updatedAuthor.Id = author.Id;
            await service.ReplaceAsync(id, updatedAuthor);
            return NoContent();
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var author = await service.GetAsync(id);
            if (author is null) return NotFound();
            await service.DeleteAsync(id);
            return NoContent();
        }
    }
}
