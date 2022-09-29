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
    public class divListsController : Controller
    {
        private readonly AppBDContext _context;

        public divListsController(AppBDContext context)
        {
            _context = context;
        }

        // GET: divLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.divList.ToListAsync());
        }

        // GET: divLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divList = await _context.divList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (divList == null)
            {
                return NotFound();
            }

            return View(divList);
        }

        // GET: divLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: divLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] divList divList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divList);
        }

        // GET: divLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divList = await _context.divList.FindAsync(id);
            if (divList == null)
            {
                return NotFound();
            }
            return View(divList);
        }

        // POST: divLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] divList divList)
        {
            if (id != divList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!divListExists(divList.Id))
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
            return View(divList);
        }

        // GET: divLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divList = await _context.divList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (divList == null)
            {
                return NotFound();
            }

            return View(divList);
        }

        // POST: divLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divList = await _context.divList.FindAsync(id);
            _context.divList.Remove(divList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool divListExists(int id)
        {
            return _context.divList.Any(e => e.Id == id);
        }
    }
}
