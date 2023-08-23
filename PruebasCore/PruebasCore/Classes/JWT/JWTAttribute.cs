using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Jose; // Asegúrate de tener la referencia a la librería de JWT

namespace PruebasCore.Classes.JWT
{
    public class JWTAttribute : ActionFilterAttribute
    {
        private JWT clave = new JWT();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string token = context.HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer "))
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    Epoch epoch = new Epoch();
                    double ahora = epoch.convertirEpoch(DateTime.Now);

                    string tokenO = token.Substring(7); // Para eliminar "Bearer "
                    string payload = Jose.JWT.Decode(tokenO, clave.GetSecretKey());

                    Claims empleadoJwt = JsonConvert.DeserializeObject<Claims>(payload) ?? new Claims();

                    if (ahora <= empleadoJwt.Exp)
                    {
                        context.HttpContext.Items["payload"] = payload;
                    }
                    else
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}

