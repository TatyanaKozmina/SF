using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogAppWebPages.Controllers
{
    public class RoleController : Controller
    {
        private readonly IMapper mapper;

        public RoleController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: RoleController
        public async Task<IActionResult> Index()
        {
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync("api/Roles");
            var rolesList = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Roles.Responses.GetRolesResponse>(await resp.Content.ReadAsStringAsync());
            var rolesResponse = mapper.Map<BlogAppAPI.Contracts.Roles.Responses.GetRolesResponse, ViewModels.RoleViewModels.GetRolesResponse>(rolesList);
            var roles = rolesResponse.Roles;
            return View(roles);
        }

        // GET: RoleController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Roles/{id}");
            var role = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Roles.Responses.RoleView>(await resp.Content.ReadAsStringAsync());
            var roleView = mapper.Map<BlogAppAPI.Contracts.Roles.Responses.RoleView, ViewModels.RoleViewModels.RoleView>(role);

            return View(roleView);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModels.RoleViewModels.AddRoleRequest roleView)
        {
            try
            {
                var addRoleRequest = mapper.Map<ViewModels.RoleViewModels.AddRoleRequest, BlogAppAPI.Contracts.Roles.Requests.AddRoleRequest>(roleView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PostAsJsonAsync($"api/Roles", addRoleRequest);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Role");
                else
                    return View(roleView); // show error
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Roles/{id}");
            var role = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Roles.Responses.RoleView>(await resp.Content.ReadAsStringAsync());
            var roleView = mapper.Map<BlogAppAPI.Contracts.Roles.Responses.RoleView, ViewModels.RoleViewModels.RoleView>(role);

            return View(roleView);
        }

        // PUT: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ViewModels.RoleViewModels.RoleView roleView)
        {
            try
            {
                if (id == null) return NotFound();
                var putRoleRequest = mapper.Map<ViewModels.RoleViewModels.RoleView, BlogAppAPI.Contracts.Roles.Requests.PutRoleRequest>(roleView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PutAsJsonAsync($"api/Roles/{id}", putRoleRequest);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Role");
                else
                    return View(roleView); // show error
            }
            catch
            {
                return View(roleView);
            }
        }

        // GET: RoleController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Roles/{id}");
            var role = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Roles.Responses.RoleView>(await resp.Content.ReadAsStringAsync());
            var roleView = mapper.Map<BlogAppAPI.Contracts.Roles.Responses.RoleView, ViewModels.RoleViewModels.RoleView>(role);

            return View(roleView);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ViewModels.RoleViewModels.RoleView roleView)
        {
            try
            {
                if (id == null) return NotFound();
                var client = Clients.BlogAppAPIClient.getInstance();
                HttpResponseMessage resp = await client.DeleteAsync($"api/Roles/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(roleView);
            }
        }
    }
}
