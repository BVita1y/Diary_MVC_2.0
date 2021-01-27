using Diary_MVC_2._0.Data;
using Diary_MVC_2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Diary_MVC_2._0.Controllers
{
    public class CaseController : Controller
    {
        private readonly DiaryDbContext _context;

        public CaseController(DiaryDbContext context)
        {
            _context = context;
        }

        // Get 

        // GET: Case
        public async Task<IActionResult> Index()
        {
            return View(await _context.Case.ToListAsync());
        }

        // GET: Case/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Case/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Case/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinishDateTime,Id,Type,Subject,StartDateTime,IsPerformed")] Case @case)
        {
            @case.Type = Plan.PlanType.Case;
            if (ModelState.IsValid)
            {
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), nameof(Plan));
            }
            return View(@case);
        }

        // GET: Case/ChangeStatusPerform/5
        public async Task<IActionResult> ChangeStatusPerform(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }

            // change task status (performed / not performed)
            @case.IsPerformed = !@case.IsPerformed;

            // making changes to DB
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), nameof(Plan));
            }
            return View(@case);
        }

        // GET: Case/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }
            return View(@case);
        }

        // POST: Case/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinishDateTime,Id,Type,Subject,StartDateTime,IsPerformed")] Case @case)
        {
            if (id != @case.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), nameof(Plan));
            }
            return View(@case);
        }

        // GET: Case/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // POST: Case/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @case = await _context.Case.FindAsync(id);
            _context.Case.Remove(@case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(int id)
        {
            return _context.Case.Any(e => e.Id == id);
        }
    }
}
