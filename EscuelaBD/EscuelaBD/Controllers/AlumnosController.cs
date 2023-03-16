using EscuelaBD.Models;
using Microsoft.AspNetCore.Mvc;
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
            var alumno = _context.Alumnos.Include(a => a.Salon);
            return View(await alumno.ToListAsync());
        }
    }
}
