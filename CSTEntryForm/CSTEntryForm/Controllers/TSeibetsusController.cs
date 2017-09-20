using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSTEntryForm.Models;

namespace CSTEntryForm.Controllers
{
    public class TSeibetsusController : Controller
    {
        private readonly KojinContext _context;

        public TSeibetsusController(KojinContext context)
        {
            _context = context;    
        }

        // GET: TSeibetsus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TSeibetsu.ToListAsync());
        }

        // GET: TSeibetsus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSeibetsu = await _context.TSeibetsu
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tSeibetsu == null)
            {
                return NotFound();
            }

            return View(tSeibetsu);
        }

        // GET: TSeibetsus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TSeibetsus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ESeibetsu")] TSeibetsu tSeibetsu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tSeibetsu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tSeibetsu);
        }

        // GET: TSeibetsus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSeibetsu = await _context.TSeibetsu.SingleOrDefaultAsync(m => m.Id == id);
            if (tSeibetsu == null)
            {
                return NotFound();
            }
            return View(tSeibetsu);
        }

        // POST: TSeibetsus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ESeibetsu")] TSeibetsu tSeibetsu)
        {
            if (id != tSeibetsu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tSeibetsu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSeibetsuExists(tSeibetsu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(tSeibetsu);
        }

        // GET: TSeibetsus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSeibetsu = await _context.TSeibetsu
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tSeibetsu == null)
            {
                return NotFound();
            }

            return View(tSeibetsu);
        }

        // POST: TSeibetsus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSeibetsu = await _context.TSeibetsu.SingleOrDefaultAsync(m => m.Id == id);
            _context.TSeibetsu.Remove(tSeibetsu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TSeibetsuExists(int id)
        {
            return _context.TSeibetsu.Any(e => e.Id == id);
        }
    }
}
