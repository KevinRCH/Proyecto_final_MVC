using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BliotecaApp.Models;

namespace BliotecaApp.Controllers
{
    public class PrestamoLibroesController : Controller
    {
        private readonly DbBibliotecaContext _context;

        public PrestamoLibroesController(DbBibliotecaContext context)
        {
            _context = context;
        }

        // GET: PrestamoLibroes
        public async Task<IActionResult> Index()
        {
            var dbBibliotecaContext = _context.PrestamoLibros.Include(p => p.Libro).Include(p => p.Prestamo).Include(p => p.Prestamo.Cliente);
            return View(await dbBibliotecaContext.ToListAsync());
        }

        // GET: PrestamoLibroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoLibro = await _context.PrestamoLibros
                .Include(p => p.Libro)
                .Include(p => p.Prestamo)
                .FirstOrDefaultAsync(m => m.PrestamoLibroId == id);
            if (prestamoLibro == null)
            {
                return NotFound();
            }

            return View(prestamoLibro);
        }

        // GET: PrestamoLibroes/Create
        public IActionResult Create()
        {
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Autor");
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "PrestamoId");
            return View();
        }

        // POST: PrestamoLibroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestamoLibroId,PrestamoId,LibroId")] PrestamoLibro prestamoLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamoLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Autor", prestamoLibro.LibroId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "PrestamoId", prestamoLibro.PrestamoId);
            return View(prestamoLibro);
        }

        // GET: PrestamoLibroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoLibro = await _context.PrestamoLibros.FindAsync(id);
            if (prestamoLibro == null)
            {
                return NotFound();
            }
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Autor", prestamoLibro.LibroId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "PrestamoId", prestamoLibro.PrestamoId);
            return View(prestamoLibro);
        }

        // POST: PrestamoLibroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestamoLibroId,PrestamoId,LibroId")] PrestamoLibro prestamoLibro)
        {
            if (id != prestamoLibro.PrestamoLibroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamoLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoLibroExists(prestamoLibro.PrestamoLibroId))
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
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Autor", prestamoLibro.LibroId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "PrestamoId", prestamoLibro.PrestamoId);
            return View(prestamoLibro);
        }

        // GET: PrestamoLibroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoLibro = await _context.PrestamoLibros
                .Include(p => p.Libro)
                .Include(p => p.Prestamo)
                .FirstOrDefaultAsync(m => m.PrestamoLibroId == id);
            if (prestamoLibro == null)
            {
                return NotFound();
            }

            return View(prestamoLibro);
        }

        // POST: PrestamoLibroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamoLibro = await _context.PrestamoLibros.FindAsync(id);
            _context.PrestamoLibros.Remove(prestamoLibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoLibroExists(int id)
        {
            return _context.PrestamoLibros.Any(e => e.PrestamoLibroId == id);
        }
    }
}
