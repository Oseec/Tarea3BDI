using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea3BDI.Data;

namespace Tarea3BDI.Controllers
{
    public class UsuarioEmpleadoController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        PlanillaSemanalXEmpleadoDatos DatosPlanillaSemanaXEmpleado = new PlanillaSemanalXEmpleadoDatos();


        public IActionResult Inicio()
        {

            return View();
        }
    }
}
