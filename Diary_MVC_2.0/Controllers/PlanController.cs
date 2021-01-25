using Diary_MVC_2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Diary_MVC_2._0.Models.PlansViewModel;

namespace Diary_MVC_2._0.Controllers
{
    public class PlanController : Controller
    {
        private readonly DiaryDbContext _context;

        public PlanController(DiaryDbContext context)
        {
            _context = context;
        }

        // GET: Plan
        public async Task<IActionResult> Index(Plan.PlanType? planType, DateTime? date, string searchString, DAYSLIMIT? limit)
        {
            IQueryable<string> typeQuery = from p in _context.Plan
                                           orderby p.Type
                                           select p.Type.ToString();

            var plans = from p in _context.Plan
                        select p;

            if (!string.IsNullOrEmpty(searchString))
                plans = plans.Where(p => p.Subject.Contains(searchString) || p is Meeting && ((Meeting)p).Place.Contains(searchString));

            if (planType != null)
                plans = plans.Where(x => x.Type == planType);

            if (date != null)
                plans = plans.Where(x => (x.StartDateTime.Date).Equals(date));

            if (limit != DAYSLIMIT.list)
            {
                if (limit == DAYSLIMIT.day) plans = plans.Where(x => (x.StartDateTime.Date) < DateTime.Now.Date.AddDays(1));
                else if (limit == DAYSLIMIT.week) plans = plans.Where(x => (x.StartDateTime.Date) < DateTime.Now.Date.AddDays(7));
                else if (limit == DAYSLIMIT.month) plans = plans.Where(x => (x.StartDateTime.Date) < DateTime.Now.Date.AddMonths(1));
            }

            var plansVM = new PlansViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Plans = await plans.ToListAsync()
            };

            return View(plansVM);

            //return View(await _context.Plan.ToListAsync());
        }

        // GET: Plan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Subject,StartDateTime,IsPerformed")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        // GET: Plan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Subject,StartDateTime,IsPerformed")] Plan plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.Id))
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
            return View(plan);
        }

        // GET: Plan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plan = await _context.Plan.FindAsync(id);
            _context.Plan.Remove(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanExists(int id)
        {
            return _context.Plan.Any(e => e.Id == id);
        }
    }
}
