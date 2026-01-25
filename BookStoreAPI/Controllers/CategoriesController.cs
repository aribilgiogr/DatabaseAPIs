using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService service) : ControllerBase
    {
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get() => await service.GetAsync();

        // GET api/<CategoriesController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var author = await service.GetAsync(id);
            if (author is null) return NotFound();
            return Ok(author);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category newCategory)
        {
            await service.InsertAsync(newCategory);
            return CreatedAtAction(nameof(Get), newCategory.Id);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Category updatedCategory)
        {
            var author = await service.GetAsync(id);
            if (author is null) return NotFound();
            updatedCategory.Id = author.Id;
            await service.ReplaceAsync(id, updatedCategory);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
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
