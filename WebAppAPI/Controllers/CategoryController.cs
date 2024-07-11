﻿using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetAllCategory();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            await _categoryRepository.Add(category);
            return Content("Insert Success");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Category category)
        {
            var temp = await _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _categoryRepository.Update(category);
            return Content("Update Success");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var temp = await _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _categoryRepository.Delete(id);
            return Content("Delete Success");
        }
    }
}
