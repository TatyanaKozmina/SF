using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Articles.Requests;
using BlogAppAPI.Contracts.Articles.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepo repo;
        private readonly IMapper mapper;

        public ArticleController(IArticleRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = new GetArticlesResponse
            {
                Articles = mapper.Map<List<Article>, List<ArticleView>>(await repo.Get())
            };

            return StatusCode(200, resp);
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resp = new GetArticlesResponse
            {
                Articles = mapper.Map<List<Article>, List<ArticleView>>(await repo.Get(id))
            };

            return StatusCode(200, resp);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddArticleRequest value)
        {
            var item = mapper.Map<AddArticleRequest, Article>(value);
            await repo.Create(item);
            return StatusCode(200, "Article created");
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutArticleRequest value)
        {
            var item = mapper.Map<PutArticleRequest, Article>(value);
            item.Id = id;
            await repo.Update(item);
            return StatusCode(200, "Article modified");
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return StatusCode(200, "Article deleted");
        }
    }
}
