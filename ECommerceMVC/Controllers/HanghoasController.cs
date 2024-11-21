using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data;

namespace ECommerceMVC.Controllers
{
    public class HanghoasController : Controller
    {
        private readonly ECommerceTutContext _context;

        public HanghoasController(ECommerceTutContext context)
        {
            _context = context;
        }

        // GET: Hanghoas
        public async Task<IActionResult> Index()
        {
            var eCommerceTutContext = _context.Hanghoas.Include(h => h.MaloaiNavigation).Include(h => h.ManccNavigation);
            return View(await eCommerceTutContext.ToListAsync());
        }

        // GET: Hanghoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas
                .Include(h => h.MaloaiNavigation)
                .Include(h => h.ManccNavigation)
                .FirstOrDefaultAsync(m => m.Mahh == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // GET: Hanghoas/Create
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.Loais, "Maloai", "Maloai");
            ViewData["Mancc"] = new SelectList(_context.Nhacungcaps, "Mancc", "Mancc");
            return View();
        }

        // POST: Hanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahh,Tenhh,Tenalias,Maloai,Motadonvi,Dongia,Hinh,Ngaysx,Giamgia,Solanxem,Mota,Mancc")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hanghoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maloai"] = new SelectList(_context.Loais, "Maloai", "Maloai", hanghoa.Maloai);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcaps, "Mancc", "Mancc", hanghoa.Mancc);
            return View(hanghoa);
        }

        // GET: Hanghoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.Loais, "Maloai", "Maloai", hanghoa.Maloai);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcaps, "Mancc", "Mancc", hanghoa.Mancc);
            return View(hanghoa);
        }

        // POST: Hanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahh,Tenhh,Tenalias,Maloai,Motadonvi,Dongia,Hinh,Ngaysx,Giamgia,Solanxem,Mota,Mancc")] Hanghoa hanghoa)
        {
            if (id != hanghoa.Mahh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hanghoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HanghoaExists(hanghoa.Mahh))
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
            ViewData["Maloai"] = new SelectList(_context.Loais, "Maloai", "Maloai", hanghoa.Maloai);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcaps, "Mancc", "Mancc", hanghoa.Mancc);
            return View(hanghoa);
        }

        // GET: Hanghoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas
                .Include(h => h.MaloaiNavigation)
                .Include(h => h.ManccNavigation)
                .FirstOrDefaultAsync(m => m.Mahh == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // POST: Hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hanghoa = await _context.Hanghoas.FindAsync(id);
            if (hanghoa != null)
            {
                _context.Hanghoas.Remove(hanghoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HanghoaExists(int id)
        {
            return _context.Hanghoas.Any(e => e.Mahh == id);
        }
    }
}
