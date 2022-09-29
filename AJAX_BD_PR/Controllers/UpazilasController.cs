using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AJAX_BD_PR.Data;
using AJAX_BD_PR.Models;

namespace AJAX_BD_PR.Controllers
{
    public class UpazilasController : Controller
    {
        private readonly AppBDContext _context;

        public UpazilasController(AppBDContext context)
        {
            _context = context;
        }

        // GET: Upazilas
        public async Task<IActionResult> Index()
        {
            var appBDContext = _context.Upazila.Include(u => u.District);
            return View(await appBDContext.ToListAsync());
        }

        // GET: Upazilas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazila
                .Include(u => u.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upazila == null)
            {
                return NotFound();
            }

            return View(upazila);
        }

        // GET: Upazilas/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Name");
            return View();
        }

        // POST: Upazilas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DistrictId")] Upazila upazila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upazila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Name", upazila.DistrictId);
            return View(upazila);
        }

        // GET: Upazilas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazila.FindAsync(id);
            if (upazila == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Name", upazila.DistrictId);
            return View(upazila);
        }

        // POST: Upazilas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DistrictId")] Upazila upazila)
        {
            if (id != upazila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upazila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpazilaExists(upazila.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Name", upazila.DistrictId);
            return View(upazila);
        }

        // GET: Upazilas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazila
                .Include(u => u.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upazila == null)
            {
                return NotFound();
            }

            return View(upazila);
        }

        // POST: Upazilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upazila = await _context.Upazila.FindAsync(id);
            _context.Upazila.Remove(upazila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpazilaExists(int id)
        {
            return _context.Upazila.Any(e => e.Id == id);
        }
    }
}
