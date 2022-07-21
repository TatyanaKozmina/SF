using Microsoft.AspNetCore.Mvc;
using SchoolJournal.Data.Repos;

namespace SchoolJournal.Controllers
{
    public class StreamsController : Controller
    {
        private IStreamRepository _streamRepository;

        public StreamsController(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        // GET: Streams
        public async Task<IActionResult> Index()
        {
            return View(await _streamRepository.GetStreams());              
        }


        /*
        // GET: Streams/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Stream == null)
            {
                return NotFound();
            }

            var stream = await _context.Stream
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        // GET: Streams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Streams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Started,CurrentClass,IsCompleted")] Stream stream)
        {
            if (ModelState.IsValid)
            {
                stream.Id = Guid.NewGuid();
                _context.Add(stream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stream);
        }

        // GET: Streams/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Stream == null)
            {
                return NotFound();
            }

            var stream = await _context.Stream.FindAsync(id);
            if (stream == null)
            {
                return NotFound();
            }
            return View(stream);
        }

        // POST: Streams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Started,CurrentClass,IsCompleted")] Stream stream)
        {
            if (id != stream.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreamExists(stream.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stream);
        }

        // GET: Streams/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Stream == null)
            {
                return NotFound();
            }

            var stream = await _context.Stream
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        // POST: Streams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Stream == null)
            {
                return Problem("Entity set 'SchoolJournalContext.Stream'  is null.");
            }
            var stream = await _context.Stream.FindAsync(id);
            if (stream != null)
            {
                _context.Stream.Remove(stream);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreamExists(Guid id)
        {
          return (_context.Stream?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        */
    }
}
