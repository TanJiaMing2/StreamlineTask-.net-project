using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamlineTask.Data;
using StreamlineTask.Models;

namespace StreamlineTask.Controllers
{
    public class to_do_listController : Controller
    {
        private readonly ApplicationDbContext _context;

        public to_do_listController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: to_do_list
        public async Task<IActionResult> Index()
        {
            return View(await _context.to_Do_Lists.ToListAsync());
        }

        // GET: to_do_list/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var to_do_list = await _context.to_Do_Lists
                .FirstOrDefaultAsync(m => m.id == id);
            if (to_do_list == null)
            {
                return NotFound();
            }

            return View(to_do_list);
        }

        // GET: to_do_list/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: to_do_list/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Task,Description,Date,Duration")] to_do_list to_do_list)
        {
            if (ModelState.IsValid)
            {
                _context.Add(to_do_list);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(to_do_list);
        }

        // GET: to_do_list/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var to_do_list = await _context.to_Do_Lists.FindAsync(id);
            if (to_do_list == null)
            {
                return NotFound();
            }
            return View(to_do_list);
        }

        // POST: to_do_list/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Task,Description,Date,Duration")] to_do_list to_do_list)
        {
            if (id != to_do_list.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(to_do_list);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!to_do_listExists(to_do_list.id))
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
            return View(to_do_list);
        }

        // GET: to_do_list/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var to_do_list = await _context.to_Do_Lists
                .FirstOrDefaultAsync(m => m.id == id);
            if (to_do_list == null)
            {
                return NotFound();
            }

            return View(to_do_list);
        }

        // POST: to_do_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var to_do_list = await _context.to_Do_Lists.FindAsync(id);
            if (to_do_list != null)
            {
                _context.to_Do_Lists.Remove(to_do_list);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool to_do_listExists(int id)
        {
            return _context.to_Do_Lists.Any(e => e.id == id);
        }
    }
}
