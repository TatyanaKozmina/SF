using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogAppWebPages.Controllers
{
    public class TagController : Controller
    {
        private readonly IMapper mapper;

        public TagController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: TagController
        public async Task<IActionResult> Index()
        {
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync("api/Tags");
            var tagList = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Tags.Responses.GetTagResponse>(await resp.Content.ReadAsStringAsync());
            var tagResponse = mapper.Map<BlogAppAPI.Contracts.Tags.Responses.GetTagResponse, ViewModels.TagViewModels.GetTagResponse>(tagList);
            return View(tagResponse.Tags);
        }

        // GET: TagController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Tags/{id}");
            var tag = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Tags.Responses.TagView>(await resp.Content.ReadAsStringAsync());
            var tagView = mapper.Map<BlogAppAPI.Contracts.Tags.Responses.TagView, ViewModels.TagViewModels.TagView>(tag);
            return View(tagView);
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModels.TagViewModels.AddTagRequest itemView)
        {
            try
            {
                var request = mapper.Map<ViewModels.TagViewModels.AddTagRequest, BlogAppAPI.Contracts.Tags.Requests.AddTagRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PostAsJsonAsync($"api/Tags", request);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Tag");
                else
                    return View(itemView); // show error
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Tags/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Tags.Responses.TagView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Tags.Responses.TagView, ViewModels.TagViewModels.TagView>(item);

            return View(itemView);
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ViewModels.TagViewModels.TagView itemView)
        {
            try
            {
                if (id == null) return NotFound();
                var request = mapper.Map<ViewModels.TagViewModels.TagView, BlogAppAPI.Contracts.Tags.Requests.PutTagRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PutAsJsonAsync($"api/Tags/{id}", request);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Tag");
                else
                    return View(itemView); // show error
            }
            catch
            {
                return View(itemView);
            }
        }

        // GET: TagController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Tags/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Tags.Responses.TagView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Tags.Responses.TagView, ViewModels.TagViewModels.TagView>(item);

            return View(itemView);
        }

        // POST: TagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ViewModels.TagViewModels.TagView itemView)
        {
            try
            {
                if (id == null) return NotFound();
                var client = Clients.BlogAppAPIClient.getInstance();
                HttpResponseMessage resp = await client.DeleteAsync($"api/Tags/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(itemView);
            }
        }
    }
}
