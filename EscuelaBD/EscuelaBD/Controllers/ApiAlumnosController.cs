using EscuelaBD.Models;
using EscuelaBD.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAlumnosController : ControllerBase
    {
        private readonly Modelo _context;

        public ApiAlumnosController(Modelo context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Delete")]
        public async Task<List<AlumnoViewModel>> Get()
            =>await _context.Alumnos.Include(a => a.Salon)
            .Select(a => new AlumnoViewModel
            {
                Nombre = a.Nombre,
                Edad = a.Edad,
                SalonID = a.SalonID,
            })
            .ToListAsync();
        

    }
}
