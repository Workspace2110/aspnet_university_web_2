using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountingWeb.Models;

namespace AccountingWeb.Controllers
{
    public class AccountingsController : Controller
    {
        private readonly AccountingWebContext _context;

        public AccountingsController(AccountingWebContext context)
        {
            _context = context;
        }

        // GET: Accountings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accountings.ToListAsync());
        }

        // GET: Accountings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounting = await _context.Accountings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accounting == null)
            {
                return NotFound();
            }

            return View(accounting);
        }

        // GET: Accountings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accountings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Type,Comment,Date")] Accounting accounting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accounting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accounting);
        }

        // GET: Accountings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounting = await _context.Accountings.FindAsync(id);
            if (accounting == null)
            {
                return NotFound();
            }
            return View(accounting);
        }

        // POST: Accountings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Type,Comment,Date")] Accounting accounting)
        {
            if (id != accounting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accounting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingExists(accounting.Id))
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
            return View(accounting);
        }

        // GET: Accountings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounting = await _context.Accountings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accounting == null)
            {
                return NotFound();
            }

            return View(accounting);
        }

        // POST: Accountings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accounting = await _context.Accountings.FindAsync(id);
            _context.Accountings.Remove(accounting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountingExists(int id)
        {
            return _context.Accountings.Any(e => e.Id == id);
        }
    }
}
