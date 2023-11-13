using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea3BDI.Data;

namespace Tarea3BDI.Controllers
{
    public class UsuarioEmpleadoController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        PlanillaSemanalXEmpleadoDatos DatosPlanillaSemanaXEmpleado = new PlanillaSemanalXEmpleadoDatos();
        public UsuarioEmpleadoController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Inicio(int idUsuario, int idEmpleado)
        {
            ViewBag.IdUsuario = idUsuario;
            ViewBag.IdEmpleado = idEmpleado;
            return View();
        }
    }
}
