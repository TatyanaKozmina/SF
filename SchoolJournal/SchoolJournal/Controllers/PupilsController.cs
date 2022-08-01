using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.Data.Repos;
using SchoolJournal.Models.DB;

namespace SchoolJournal.Controllers
{
    public class PupilsController : Controller
    {
        private IPupilRepository _pupilRepository;
        private IStreamRepository _streamRepository;

        public PupilsController(IPupilRepository pupilRepository, IStreamRepository streamRepository)
        {
            _pupilRepository = pupilRepository;
            _streamRepository = streamRepository;
        }

        // GET: Pupils        
        //public async Task<IActionResult> Index(Guid streamId)
        public async Task<IActionResult> Index(Guid streamId)
        {
            ViewData["StreamId"] = streamId;
            return View(await _pupilRepository.GetPupils(streamId));
        }

        // GET: Pupils/Create
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Guid? id)
        {
            ViewBag.Streams = new SelectList(await _streamRepository.GetStreams(), "Id", "Started", id);
            return View();
        }

        // POST: Pupils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreamId")] Pupil pupil)
        {
            await _pupilRepository.Create(pupil);
            return RedirectToAction("Index", "Pupils", new {streamId = pupil.StreamId});
        }

        // GET: Pupils/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null || _context.Pupil == null)
        //    {
        //        return NotFound();
        //    }

        //    var pupil = await _context.Pupil
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pupil == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pupil);
        //}



        //// GET: Pupils/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Pupil == null)
        //    {
        //        return NotFound();
        //    }

        //    var pupil = await _context.Pupil.FindAsync(id);
        //    if (pupil == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pupil);
        //}

        //// POST: Pupils/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName")] Pupil pupil)
        //{
        //    if (id != pupil.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pupil);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PupilExists(pupil.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pupil);
        //}

        //// GET: Pupils/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Pupil == null)
        //    {
        //        return NotFound();
        //    }

        //    var pupil = await _context.Pupil
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pupil == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pupil);
        //}

        //// POST: Pupils/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Pupil == null)
        //    {
        //        return Problem("Entity set 'SchoolJournalContext.Pupil'  is null.");
        //    }
        //    var pupil = await _context.Pupil.FindAsync(id);
        //    if (pupil != null)
        //    {
        //        _context.Pupil.Remove(pupil);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PupilExists(Guid id)
        //{
        //  return (_context.Pupil?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
