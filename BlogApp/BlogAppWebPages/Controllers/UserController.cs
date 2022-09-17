using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogAppWebPages.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;

        public UserController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync("api/Users");
            var userList = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Users.Responses.GetUsersReponse>(await resp.Content.ReadAsStringAsync());
            var userResponse = mapper.Map<BlogAppAPI.Contracts.Users.Responses.GetUsersReponse, ViewModels.UserViewModels.GetUserResponse>(userList);
            return View(userResponse.Users);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Users/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Users.Responses.UserView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Users.Responses.UserView, ViewModels.UserViewModels.PutUserRequest>(item);
            return View(itemView);            
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ViewModels.UserViewModels.PutUserRequest itemView)
        {
            try
            {
                if (id == null) return NotFound();
                var putUserRequest = mapper.Map<ViewModels.UserViewModels.PutUserRequest, BlogAppAPI.Contracts.Users.Requests.PutUserRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PutAsJsonAsync($"api/Users/{id}", putUserRequest);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "User");
                else
                    return View(itemView); // show error
            }
            catch
            {
                return View(itemView);
            }
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Users/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Users.Responses.UserView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Users.Responses.UserView, ViewModels.UserViewModels.UserView>(item);
            return View(itemView);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ViewModels.UserViewModels.UserView itemView)
        {
            try
            {
                if (id == null) return NotFound();
                var client = Clients.BlogAppAPIClient.getInstance();
                HttpResponseMessage resp = await client.DeleteAsync($"api/Users/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(itemView);
            }
        }
    }
}
