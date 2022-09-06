using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepo repo;
        private IMapper mapper;

        public UserController(IUserRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = new GetUsersReponse
            {
                Users = mapper.Map<List<User>, List<UserView>>(await repo.Get())
            };

            return StatusCode(200, resp);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resp = mapper.Map<User, UserView>(await repo.Get(id));
            return StatusCode(200, resp);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserRequest value)
        {
            var user = mapper.Map<User>(value);
            await repo.Create(user);
            return StatusCode(200, "Пользователь добавлен");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutUserRequest value)
        {
            var user = mapper.Map<User>(value);
            user.Id = id;
            await repo.Update(user);
            return StatusCode(200, "Пользователь изменён");
        }

        // PUT api/<UserController>/5/модератор
        //[HttpPut("{id,rolename}")]
        [HttpPut()]
        public async Task<IActionResult> GrantRole(Guid id, string roleName)
        {
            await repo.GrantRole(id, roleName);
            return StatusCode(200, "Роль добавлена");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return StatusCode(200, "Пользователь удалён");
        }
    }
}
