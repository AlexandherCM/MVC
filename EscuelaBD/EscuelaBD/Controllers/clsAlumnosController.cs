using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscuelaBD.Models;

namespace EscuelaBD.Controllers
{
    public class clsAlumnosController : Controller
    {
        private readonly Modelo _context;

        public clsAlumnosController(Modelo context)
        {
            _context = context;
        }

        // GET: clsAlumnos
        public async Task<IActionResult> Index()
        {
            var modelo = _context.Alumnos.Include(c => c.Salon);
            return View(await modelo.ToListAsync());
        }

        // GET: clsAlumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var clsAlumno = await _context.Alumnos
                .Include(c => c.Salon)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clsAlumno == null)
            {
                return NotFound();
            }

            return View(clsAlumno);
        }

        // GET: clsAlumnos/Create
        public IActionResult Create()
        {
            ViewData["SalonID"] = new SelectList(_context.Salones, "ID", "Salon");
            return View();
        }

        // POST: clsAlumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Edad,SalonID")] clsAlumno clsAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonID"] = new SelectList(_context.Salones, "ID", "Salon", clsAlumno.SalonID);
            return View(clsAlumno);
        }

        // GET: clsAlumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var clsAlumno = await _context.Alumnos.FindAsync(id);
            if (clsAlumno == null)
            {
                return NotFound();
            }
            ViewData["SalonID"] = new SelectList(_context.Salones, "ID", "Salon", clsAlumno.SalonID);
            return View(clsAlumno);
        }

        // POST: clsAlumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Edad,SalonID")] clsAlumno clsAlumno)
        {
            if (id != clsAlumno.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clsAlumnoExists(clsAlumno.ID))
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
            ViewData["SalonID"] = new SelectList(_context.Salones, "ID", "Salon", clsAlumno.SalonID);
            return View(clsAlumno);
        }

        // GET: clsAlumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var clsAlumno = await _context.Alumnos
                .Include(c => c.Salon)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clsAlumno == null)
            {
                return NotFound();
            }

            return View(clsAlumno);
        }

        // POST: clsAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alumnos == null)
            {
                return Problem("Entity set 'Modelo.Alumnos'  is null.");
            }
            var clsAlumno = await _context.Alumnos.FindAsync(id);
            if (clsAlumno != null)
            {
                _context.Alumnos.Remove(clsAlumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clsAlumnoExists(int id)
        {
          return (_context.Alumnos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
