using AutoMapper;
using BlogAppWebPages.ViewModels.UserAccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlogAppWebPages.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IMapper mapper;

        public UserAccountController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest itemView)
        {
            try
            {
                var request = mapper.Map<LoginRequest, BlogAppAPI.Contracts.Account.Request.LoginRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PostAsJsonAsync($"api/Account", request);
                if (response.IsSuccessStatusCode)
                {
                    var user = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Users.Responses.UserRoles>(await response.Content.ReadAsStringAsync());
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View(itemView); // show error
            }
            catch
            {
                return View(itemView);
            }
        }

        private async Task Authenticate(BlogAppAPI.Contracts.Users.Responses.UserRoles user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email),
                                           new Claim(ClaimsIdentity.DefaultNameClaimType, 
                                                     string.Format("{0} {1}", user.FirstName, user.LastName))};           

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            }

            ClaimsIdentity id = new ClaimsIdentity(claims, "BlogAppWebPages", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest itemView)
        {
            if (ModelState.IsValid)
            {
                var addUserRequest = mapper.Map<RegisterRequest, BlogAppAPI.Contracts.Users.Requests.AddUserRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PostAsJsonAsync($"api/User", addUserRequest);
                if (response.IsSuccessStatusCode)
                {
                    var loginRequest = mapper.Map<RegisterRequest, LoginRequest>(itemView);
                    return await Login(loginRequest);
                }                    
                else
                    return View(itemView); // show error                
            }
            return View(itemView);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
