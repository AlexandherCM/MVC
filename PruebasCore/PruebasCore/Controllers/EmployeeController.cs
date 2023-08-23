using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebasCore.Models;
using PruebasCore.Models.ViewModels;

namespace PruebasCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Modelo _context;
        public EmployeeController(Modelo context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Incluyo la relación
            var employee = _context.Employee.Include(b=>b.company);
            return View(await employee.ToListAsync());
        }

        public IActionResult Create()
        {   
            ViewData["Company"] = new SelectList(_context.Company, "ID","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {   
            if(ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    CompanyID = model.CompanyID
                };

                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Company"] = new SelectList(_context.Company, "ID","Name");
            return View();
        }

    }
}
