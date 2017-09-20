using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSTEntryForm02a.Models;

namespace CSTEntryForm02a.Controllers
{
    public class TEntryMeiboesController : Controller
    {
        private readonly EntryMeiboContext _context;

        public TEntryMeiboesController(EntryMeiboContext context)
        {
            _context = context;    
        }

        // GET: TEntryMeiboes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TEntryMeibo.ToListAsync());
        }

        // GET: TEntryMeiboes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryMeibo = await _context.TEntryMeibo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryMeibo == null)
            {
                return NotFound();
            }

            return View(tEntryMeibo);
        }

        // GET: TEntryMeiboes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TEntryMeiboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ENameSei,ENameNamae,ENameSeiKana,ENameNamaeKana,ENenrei,EJitakuRosen,EJitakuMoyorieki,EJitakuToEki,EShigotoKibou,EEmail,EPhone,EMendan1Date,EMendan1Ampm,EMendan2Date,EMendan2Ampm,EMendan3Date,EMendan3Ampm,EQuestion,ETimeStamp")] TEntryMeibo tEntryMeibo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tEntryMeibo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tEntryMeibo);
        }

        // GET: TEntryMeiboes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryMeibo = await _context.TEntryMeibo.SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryMeibo == null)
            {
                return NotFound();
            }
            return View(tEntryMeibo);
        }

        // POST: TEntryMeiboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ENameSei,ENameNamae,ENameSeiKana,ENameNamaeKana,ENenrei,EJitakuRosen,EJitakuMoyorieki,EJitakuToEki,EShigotoKibou,EEmail,EPhone,EMendan1Date,EMendan1Ampm,EMendan2Date,EMendan2Ampm,EMendan3Date,EMendan3Ampm,EQuestion,ETimeStamp")] TEntryMeibo tEntryMeibo)
        {
            if (id != tEntryMeibo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tEntryMeibo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TEntryMeiboExists(tEntryMeibo.Id))
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
            return View(tEntryMeibo);
        }

        // GET: TEntryMeiboes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryMeibo = await _context.TEntryMeibo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryMeibo == null)
            {
                return NotFound();
            }

            return View(tEntryMeibo);
        }

        // POST: TEntryMeiboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tEntryMeibo = await _context.TEntryMeibo.SingleOrDefaultAsync(m => m.Id == id);
            _context.TEntryMeibo.Remove(tEntryMeibo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TEntryMeiboExists(int id)
        {
            return _context.TEntryMeibo.Any(e => e.Id == id);
        }
    }
}