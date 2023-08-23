using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasCore.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using PruebasCore.Classes.JWT;

namespace PruebasCore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCompanyController : ControllerBase
    {
        private readonly Modelo _context;
        public ApiCompanyController(Modelo context)
        {
            _context = context;
        }

        [JWT]
        [HttpGet]
        [Route("DatosCompañia")]
        public async Task<IActionResult> DatosCompañia()
        {
            List<CompanyDTO> companies = new List<CompanyDTO>();

            companies = await (from c in _context.Company
                               select new CompanyDTO
                               {
                                   Name = c.Name,
                                   Address = c.Address,
                                   Description = c.Description,
                                   employee = (from e in c.employee
                                               select new EmployeeDTO
                                               {
                                                   ID = e.ID,
                                                   Name= e.Name,
                                                   Phone = e.Phone,
                                                   Salary = e.Salary
                                               }).ToList()
                               }).ToListAsync();

            return Ok(companies);
        }

    }
}
