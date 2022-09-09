using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Comments.Requests;
using BlogAppAPI.Contracts.Comments.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo repo;
        private readonly IMapper mapper;

        public CommentController(ICommentRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = new GetCommentResponse
            {
                Comments = mapper.Map<List<Comment>, List<CommentView>>(await repo.Get())
            };

            return StatusCode(200, resp);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "администратор")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resp = mapper.Map<Comment, CommentView>(await repo.Get(id));
            return StatusCode(200, resp);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCommentRequest value)
        {
            var item = mapper.Map<AddCommentRequest, Comment>(value);
            await repo.Create(item);
            return StatusCode(200, "Comment created");
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutCommentRequest value)
        {
            var item = mapper.Map<PutCommentRequest, Comment>(value);
            item.Id = id;
            await repo.Update(item);
            return StatusCode(200, "Comment modified");
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return StatusCode(200, "Comment deleted");
        }
    }
}
