using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSTEntryForm02.Models;

namespace CSTEntryForm02.Controllers
{
    public class TEntryDatasController : Controller
    {
        private readonly EntryDataContext _context;

        public TEntryDatasController(EntryDataContext context)
        {
            _context = context;
        }

        // GET: TEntryDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TEntryData.ToListAsync());
        }

        // GET: TEntryDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryData = await _context.TEntryData
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryData == null)
            {
                return NotFound();
            }

            return View(tEntryData);
        }

        // GET: TEntryDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TEntryDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ELastname,EFirstname,ELastnameKana,EFirstnameKana,ENenrei,EEmail,EDenwa,EMoyoriekiRosen,EMoyoriekiEki,EMoyoriekiKyori,EShigotoKibou,EMendan1Month,EMendan1Day,EMendan1Ampm,EMendan2Month,EMendan2Day,EMendan2Ampm,EMendan3Month,EMendan3Day,EMendan3Ampm,EQuestion")] TEntryData tEntryData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tEntryData);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tEntryData);
        }

        // GET: TEntryDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryData = await _context.TEntryData.SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryData == null)
            {
                return NotFound();
            }
            return View(tEntryData);
        }

        // POST: TEntryDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ELastname,EFirstname,ELastnameKana,EFirstnameKana,ENenrei,EEmail,EDenwa,EMoyoriekiRosen,EMoyoriekiEki,EMoyoriekiKyori,EShigotoKibou,EMendan1Month,EMendan1Day,EMendan1Ampm,EMendan2Month,EMendan2Day,EMendan2Ampm,EMendan3Month,EMendan3Day,EMendan3Ampm,EQuestion")] TEntryData tEntryData)
        {
            if (id != tEntryData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tEntryData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TEntryDataExists(tEntryData.Id))
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
            return View(tEntryData);
        }

        // GET: TEntryDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryData = await _context.TEntryData
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryData == null)
            {
                return NotFound();
            }

            return View(tEntryData);
        }

        // POST: TEntryDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tEntryData = await _context.TEntryData.SingleOrDefaultAsync(m => m.Id == id);
            _context.TEntryData.Remove(tEntryData);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TEntryDataExists(int id)
        {
            return _context.TEntryData.Any(e => e.Id == id);
        }
    }
}
