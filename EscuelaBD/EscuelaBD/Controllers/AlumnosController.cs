using EscuelaBD.Models;
using EscuelaBD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EscuelaBD.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly Modelo _context;

        public AlumnosController(Modelo context)
        {
            _context = context;
        }   
        public async Task<IActionResult> Index()
        {
            var alumno = _context.Alumnos.Include(a => a.Salon); //incluyo la relación
            return View(await alumno.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Salones"] = new SelectList(_context.Salones, "ID", "Salon");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Solo admite la información del formulario del dominio
        public async Task<IActionResult> Create(AlumnoViewModel model)
        {
            if (ModelState.IsValid)
            {
                clsAlumno alumno = new clsAlumno()
                {
                    Nombre= model.Nombre,
                    Edad = model.Edad,
                    SalonID = model.SalonID,
                };

                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Salones"] = new SelectList(_context.Salones, "ID", "Salon", model.SalonID);
            return View(model);
        }
    }
}
