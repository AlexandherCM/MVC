using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasCore.Classes;
using PruebasCore.Classes.JWT;
using PruebasCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PruebasCore.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiUsersController : ControllerBase
    {
        private readonly Modelo _context;
        public ApiUsersController(Modelo context)
        {
            _context = context;
        }

        [JWT]
        [HttpGet]
        [Route("MisUsuarios")]
        public IQueryable<UserDTO> GetUsers()
        {
            IQueryable<UserDTO> users = from user in _context.User
                                        select new UserDTO
                                        {
                                            ID = user.ID,
                                            UserName = user.UserName,
                                            UserEmail = user.UserEmail,
                                            Password = user.Password
                                        };
            return users;
        }

        [JWT]
        [HttpGet]
        [Route("Obtener")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.User.ToListAsync();
            return new JsonResult(users);
        }

        // - - - - - - - - - - - - - - - - - Clases y Controladores JWT - - - - - - - - - - - - - - - - - - //
        JWT jwt = new JWT();
        // - - - - - - - - - - - - - - - - - - Controlador que crea JWT - - - - - - - - - - - - - - - - - - //

        [HttpPost]
        [Route("IniciarSesion")]
        public string PedirToken(InicioSesion DatosInicio)
        {
            var Usuario = _context.User.Where(c => c.UserEmail == DatosInicio.UserEmail && c.Password == DatosInicio.Password).FirstOrDefault();
            if (Usuario == null) { return null; }

            bool password = string.Equals(Usuario.Password, DatosInicio.Password, StringComparison.Ordinal);

            if (password)
            {
                DateTime expira;

                expira = DateTime.Now.AddMinutes(20);
                Epoch epoch = new Epoch();

                Dictionary<string, object> payload = new Dictionary<string, object>()
                {
                    {"iss", Usuario.ID},
                    {"Exp", epoch.convertirEpoch(expira)},
                    {"iat", epoch.convertirEpoch(DateTime.Now)},
                };

                return jwt.GetJWT(payload);
            }
            else
            {
                return null;
            }
        }

    }
}
