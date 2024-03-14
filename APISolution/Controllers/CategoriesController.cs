using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;

        public CategoriesController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return _categoryBLL.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return _categoryBLL.GetById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post(CategoryCreateDTO category)
        {
            _categoryBLL.Insert(category);
            // Assuming Insert method returns successfully without throwing an exception
            return Ok(new { message = "Category created successfully" });
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryUpdateDTO category)
        {
            var result = _categoryBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            _categoryBLL.Update(category);
            return Ok($"Data Category ID: {id} berhasil diupdate");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            _categoryBLL.Delete(id);
            return Ok($"Data Category ID: {id} berhasil didelete");
        }
    }
}
