using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Roles;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleRepo repo;
        private IMapper mapper;
        public RoleController(IRoleRepo rolerepo, IMapper map)
        {
            repo = rolerepo;
            mapper = map;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resp = new GetAuthorsReponse
            {
                Roles = mapper.Map<List<Role>, List<RoleView>>(await repo.GetAll())
            };

            return StatusCode(200, resp);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoleRequest value)
        {
            var item = mapper.Map<Role>(value);
            await repo.Create(item);
            return StatusCode(200, "Роль добавлена");
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutRoleRequest value)
        {
            var item = mapper.Map<Role>(value);
            item.Id = id;
            await repo.Update(item);
            return StatusCode(200, "Роль изменена");
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await repo.Delete(name);
            return StatusCode(200, "Роль удалена");
        }
    }
}
