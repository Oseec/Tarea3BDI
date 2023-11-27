using Microsoft.AspNetCore.Mvc;
using Tarea3BDI.Data;

namespace Tarea3BDI.Controllers
{
    public class ConsultaPlaSemanalController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        PlanillaSemanalXEmpleadoDatos DatosPlanillaSemanaXEmpleado = new PlanillaSemanalXEmpleadoDatos();

        public ConsultaPlaSemanalController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InicioConsultaPlaSemanal(int idUsuario, int IdEmpleado)
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var olist = DatosPlanillaSemanaXEmpleado.Listar(clientIPAddress, idUsuario, IdEmpleado);
            ViewBag.IdUsuario = idUsuario;
            ViewBag.IdEmpleado = IdEmpleado;
            return View(olist);
        }

        public IActionResult VerDetalleDeduccionSemanal(int idUsuario, int IdEmpleado)
        {
            ViewBag.IdUsuario = idUsuario;
            ViewBag.IdEmpleado = IdEmpleado;
            var olist = DatosPlanillaSemanaXEmpleado.ObtenerDeduccionesPorEmpleado(idUsuario, IdEmpleado);

            return View(olist);
        }

    }
}
