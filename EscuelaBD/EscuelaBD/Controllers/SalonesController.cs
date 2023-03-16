using EscuelaBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EscuelaBD.Controllers
{
    public class SalonesController : Controller
    {
        private readonly Modelo _context;

        public SalonesController(Modelo context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
            => View(await _context.Salones.ToListAsync());
        
        
    }
}
