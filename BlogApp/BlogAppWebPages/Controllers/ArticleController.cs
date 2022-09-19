using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogAppWebPages.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IMapper mapper;

        public ArticleController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: ArticleController
        public async Task<IActionResult> Index()
        {
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync("api/Articles");
            var articlesList = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Articles.Responses.GetArticlesResponse>(await resp.Content.ReadAsStringAsync());
            var articleResponse = mapper.Map<BlogAppAPI.Contracts.Articles.Responses.GetArticlesResponse, ViewModels.ArticleViewModels.GetArticleResponse>(articlesList);
            var articles = articleResponse.Articles;
            return View(articles);
        }

        // GET: ArticleController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Articles/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Articles.Responses.ArticleView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Articles.Responses.ArticleView, ViewModels.ArticleViewModels.ArticleView>(item);

            return View(itemView);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModels.ArticleViewModels.AddArticleRequest itemView)
        {
            try
            {
                var request = mapper.Map<ViewModels.ArticleViewModels.AddArticleRequest, BlogAppAPI.Contracts.Articles.Requests.AddArticleRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PostAsJsonAsync($"api/Articles", request);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Article");
                else
                    return View(itemView); // show error
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Articles/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Articles.Responses.ArticleView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Articles.Responses.ArticleView, ViewModels.ArticleViewModels.PutArticleRequest>(item);
            return View(itemView);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ViewModels.ArticleViewModels.PutArticleRequest itemView)
        {
            try
            {
                if (id == null) return NotFound();
                var putUserRequest = mapper.Map<ViewModels.ArticleViewModels.PutArticleRequest, BlogAppAPI.Contracts.Articles.Requests.PutArticleRequest>(itemView);
                var client = Clients.BlogAppAPIClient.getInstance();
                using HttpResponseMessage response = await client.PutAsJsonAsync($"api/Articles/{id}", putUserRequest);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Article");
                else
                    return View(itemView); // show error
            }
            catch
            {
                return View(itemView);
            }
        }

        // GET: ArticlesController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();
            var client = Clients.BlogAppAPIClient.getInstance();
            HttpResponseMessage resp = await client.GetAsync($"api/Articles/{id}");
            var item = JsonConvert.DeserializeObject<BlogAppAPI.Contracts.Articles.Responses.ArticleView>(await resp.Content.ReadAsStringAsync());
            var itemView = mapper.Map<BlogAppAPI.Contracts.Articles.Responses.ArticleView, ViewModels.ArticleViewModels.ArticleView>(item);
            return View(itemView);
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ViewModels.ArticleViewModels.ArticleView itemView)
        {
            try
            {
                if (id == null) return NotFound();
                var client = Clients.BlogAppAPIClient.getInstance();
                HttpResponseMessage resp = await client.DeleteAsync($"api/Articles/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(itemView);
            }
        }
    }
}
