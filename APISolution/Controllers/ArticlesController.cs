using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;

        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            return _articleBLL.GetArticleWithCategory();
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public ArticleDTO Get(int id)
        {
            return _articleBLL.GetArticleById(id);
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public IActionResult Post(ArticleCreateDTO article)
        {
            _articleBLL.Insert(article);
            // Assuming Insert method returns successfully without throwing an exception
            return Ok(new { message = "Article created successfully" });
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ArticleUpdateDTO article)
        {
            var result = _articleBLL.GetArticleById(id);
            if (result == null)
            {
                return NotFound();
            }
            _articleBLL.Update(article);
            return Ok($"Data Article ID: {id} berhasil diupdate");
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _articleBLL.GetArticleById(id);
            if (result == null)
            {
                return NotFound();
            }
            _articleBLL.Delete(id);
            return Ok($"Data Article ID: {id} berhasil dihapus");   
        }
    }
}
