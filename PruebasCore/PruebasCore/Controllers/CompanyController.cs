using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasCore.Classes.JWT;
using PruebasCore.Models;
using PruebasCore.Models.ViewModels;

namespace PruebasCore.Controllers
{
    public class CompanyController : Controller
    {
        private readonly Modelo _context;
        public CompanyController(Modelo context)
        {
            _context = context;
        }

        //Contolador que retorna la lista de datos
        [JWT]
        public async Task<IActionResult> Index()
            => View(await _context.Company.ToListAsync());

        //Me lleva a la vista de create
        public IActionResult Create()
        {
            return View();
        }

        //La vista de create me manda el JSON a registrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if(ModelState.IsValid)
            {
                var company = new Company()
                {
                    Name = model.Name,
                    Address = model.Address,
                    Description= model.Description,
                };

                _context.Add(company);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
