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
    
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepo repo;
        private readonly IMapper mapper;

        public ArticlesController(IArticleRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = new GetArticlesResponse
            {
                Articles = mapper.Map<List<Article>, List<ArticleView>>(await repo.Get())
            };

            return StatusCode(200, resp);
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resp = mapper.Map<Article, ArticleView>(await repo.Get(id));
            return StatusCode(200, resp);
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddArticleRequest value)
        {
            var item = mapper.Map<AddArticleRequest, Article>(value);
            await repo.Create(item);
            return StatusCode(200, "Article created");
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutArticleRequest value)
        {
            var item = mapper.Map<PutArticleRequest, Article>(value);
            item.Id = id;
            await repo.Update(item);
            return StatusCode(200, "Article modified");
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return StatusCode(200, "Article deleted");
        }
    }
}
