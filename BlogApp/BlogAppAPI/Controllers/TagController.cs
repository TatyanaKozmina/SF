using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Tags;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    
    public class TagController : ControllerBase
    {
        private readonly ITagRepo repo;
        private readonly IMapper mapper;

        public TagController(ITagRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: api/<TagController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = await repo.Get();
            return StatusCode(200, resp);
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resp = await repo.Get(id);
            return StatusCode(200, resp);
        }

        // POST api/<TagController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTagRequest value)
        {
            var item = mapper.Map<AddTagRequest, Tag>(value);
            await repo.Create(item);
            return StatusCode(200, "Tag created");
        }

        // PUT api/<TagController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PutTagRequest value)
        {
            var item = mapper.Map<PutTagRequest, Tag>(value);
            await repo.Update(item, new BlogApp.Data.Queries.UpdateTagQuery(value.NewText));
            return StatusCode(200, "Tag modified");
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{text}")]
        public async Task<IActionResult> Delete(string text)
        {
            await repo.Delete(text);
            return StatusCode(200, "Tag deleted");
        }
    }
}
