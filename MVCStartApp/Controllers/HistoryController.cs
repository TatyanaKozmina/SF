using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models;
using MVCStartApp.Models.DB;

namespace MVCStartApp.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryRepository _repo;

        public HistoryController(IHistoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var historyRecords = await _repo.GetHistory();
            return View(historyRecords);
        }
    }
}