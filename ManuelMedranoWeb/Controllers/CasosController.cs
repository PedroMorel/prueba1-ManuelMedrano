using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManuelMedranoWeb.Models;

namespace ManuelMedranoWeb.Controllers
{
    public class CasosController : Controller
    {
        private readonly MedranoCTX _context;

        public CasosController(MedranoCTX context)
        {
            _context = context;
        }

        // GET: Casoes
        public async Task<IActionResult> Index()
        {
            var medranoCTX = _context.Caso.Include(c => c.IdCasoSelectNavigation);
            return View(await medranoCTX.ToListAsync());
        }

        // GET: Casoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caso = await _context.Caso
                .Include(c => c.IdCasoSelectNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caso == null)
            {
                return NotFound();
            }

            return View(caso);
        }

        // GET: Casoes/Create
        public IActionResult Create()
        {
            ViewData["IdCasoSelect"] = new SelectList(_context.Casoselect, "Id", "Nombre");
            return View();
        }

        // POST: Casoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Contacto,IdCasoSelect")] Caso caso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCasoSelect"] = new SelectList(_context.Casoselect, "Id", "Nombre", caso.IdCasoSelect);
            return View(caso);
        }

        // GET: Casoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caso = await _context.Caso.FindAsync(id);
            if (caso == null)
            {
                return NotFound();
            }
            ViewData["IdCasoSelect"] = new SelectList(_context.Casoselect, "Id", "Nombre", caso.IdCasoSelect);
            return View(caso);
        }

        // POST: Casoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Contacto,IdCasoSelect")] Caso caso)
        {
            if (id != caso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasoExists(caso.Id))
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
            ViewData["IdCasoSelect"] = new SelectList(_context.Casoselect, "Id", "Nombre", caso.IdCasoSelect);
            return View(caso);
        }

        // GET: Casoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caso = await _context.Caso
                .Include(c => c.IdCasoSelectNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caso == null)
            {
                return NotFound();
            }

            return View(caso);
        }

        // POST: Casoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caso = await _context.Caso.FindAsync(id);
            _context.Caso.Remove(caso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasoExists(int id)
        {
            return _context.Caso.Any(e => e.Id == id);
        }
    }
}
