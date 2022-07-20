using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.Data;
using SchoolJournal.Models;

namespace SchoolJournal.Controllers
{
    public class StreamController : Controller
    {
        private readonly SchoolJournalContext _context;

        public StreamController(SchoolJournalContext context)
        {
            _context = context;
        }

        // GET: Stream
        public async Task<IActionResult> Index()
        {
              return _context.Stream != null ? 
                          View(await _context.Stream.ToListAsync()) :
                          Problem("Entity set 'SchoolJournalContext.Stream'  is null.");
        }

        // GET: Stream/Details/5
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

        // GET: Stream/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stream/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Started,CurrentClass,IsCompleted")] Models.Stream stream)
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

        // GET: Stream/Edit/5
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

        // POST: Stream/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Started,CurrentClass,IsCompleted")] Models.Stream stream)
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

        // GET: Stream/Delete/5
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

        // POST: Stream/Delete/5
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
    }
}
