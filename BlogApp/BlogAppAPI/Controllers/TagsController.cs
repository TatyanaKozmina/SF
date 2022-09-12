using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Tags.Requests;
using BlogAppAPI.Contracts.Tags.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TagsController : ControllerBase
    {
        private readonly ITagRepo repo;
        private readonly IMapper mapper;

        public TagsController(ITagRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: api/<TagsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = new GetTagResponse
            {
                Tags = mapper.Map<List<Tag>, List<TagView>>(await repo.Get())
            };

            return StatusCode(200, resp);
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resp = await repo.Get(id);
            return StatusCode(200, resp);
        }

        // POST api/<TagsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTagRequest value)
        {
            var item = mapper.Map<Tag>(value);
            await repo.Create(item);
            return StatusCode(200, "Tag created");
        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutTagRequest value)
        {
            var item = mapper.Map<Tag>(value);
            item.Id = id;
            await repo.Update(item);
            return StatusCode(200, "Tag modified");
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return StatusCode(200, "Tag deleted");
        }
    }
}
