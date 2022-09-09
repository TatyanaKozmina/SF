using AutoMapper;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Account.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AccountController : ControllerBase
    {
        private readonly IUserRepo repo;

        public AccountController(IUserRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var user = await repo.GetByEmailPassword(login.Email, login.Password);
            if (user != null)
            {
                await Authenticate(user);

                return StatusCode(200, "Login successfull");
            }
            return BadRequest();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            }

            ClaimsIdentity id = new ClaimsIdentity(claims, "BlogAppAPICookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
