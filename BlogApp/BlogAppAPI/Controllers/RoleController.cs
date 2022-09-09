using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Roles.Requests;
using BlogAppAPI.Contracts.Roles.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepo repo;
        private readonly IMapper mapper;
        public RoleController(IRoleRepo rolerepo, IMapper map)
        {
            repo = rolerepo;
            mapper = map;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = new GetRolesResponse
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
            return StatusCode(200, "Role created");
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutRoleRequest value)
        {
            var item = mapper.Map<Role>(value);
            item.Id = id;
            await repo.Update(item);
            return StatusCode(200, "Role changed");
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await repo.Delete(name);
            return StatusCode(200, "Role deleted");
        }
    }
}