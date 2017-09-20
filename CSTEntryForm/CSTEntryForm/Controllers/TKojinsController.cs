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
    public class TKojinsController : Controller
    {
        private readonly KojinContext _context;

        public TKojinsController(KojinContext context)
        {
            _context = context;    
        }

        // GET: TKojins
        public async Task<IActionResult> Index()
        {
            var kojinContext = _context.TKojin.Include(t => t.ESeibetsuNavigation);
            return View(await kojinContext.ToListAsync());
        }

        // GET: TKojins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tKojin = await _context.TKojin
                .Include(t => t.ESeibetsuNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tKojin == null)
            {
                return NotFound();
            }

            return View(tKojin);
        }

        // GET: TKojins/Create
        public IActionResult Create()
        {
            ViewData["ESeibetsu"] = new SelectList(_context.TSeibetsu, "Id", "ESeibetsu");
            return View();
        }

        // POST: TKojins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ENamae,ENamaeNamae,ENamaeSeiKana,ENamaeNamaeKana,ENenrei,ESeibetsu,EEmail,EDenwaArea,EDenwaLocal,EDenwa4num,EShigotoKibou,EMendan1Month,EMendan1Day,EMendan1Ampm,EMendan2Month,EMendan2Day,EMendan2Ampm,EMendan3Month,EMendan3Day,EMendan3Ampm,EQuestion")] TKojin tKojin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tKojin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ESeibetsu"] = new SelectList(_context.TSeibetsu, "Id", "ESeibetsu", tKojin.ESeibetsu);
            return View(tKojin);
        }

        // GET: TKojins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tKojin = await _context.TKojin.SingleOrDefaultAsync(m => m.Id == id);
            if (tKojin == null)
            {
                return NotFound();
            }
            ViewData["ESeibetsu"] = new SelectList(_context.TSeibetsu, "Id", "ESeibetsu", tKojin.ESeibetsu);
            return View(tKojin);
        }

        // POST: TKojins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ENamae,ENamaeNamae,ENamaeSeiKana,ENamaeNamaeKana,ENenrei,ESeibetsu,EEmail,EDenwaArea,EDenwaLocal,EDenwa4num,EShigotoKibou,EMendan1Month,EMendan1Day,EMendan1Ampm,EMendan2Month,EMendan2Day,EMendan2Ampm,EMendan3Month,EMendan3Day,EMendan3Ampm,EQuestion")] TKojin tKojin)
        {
            if (id != tKojin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tKojin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TKojinExists(tKojin.Id))
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
            ViewData["ESeibetsu"] = new SelectList(_context.TSeibetsu, "Id", "ESeibetsu", tKojin.ESeibetsu);
            return View(tKojin);
        }

        // GET: TKojins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tKojin = await _context.TKojin
                .Include(t => t.ESeibetsuNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tKojin == null)
            {
                return NotFound();
            }

            return View(tKojin);
        }

        // POST: TKojins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tKojin = await _context.TKojin.SingleOrDefaultAsync(m => m.Id == id);
            _context.TKojin.Remove(tKojin);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TKojinExists(int id)
        {
            return _context.TKojin.Any(e => e.Id == id);
        }
    }
}
