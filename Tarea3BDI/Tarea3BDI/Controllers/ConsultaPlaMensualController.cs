using Microsoft.AspNetCore.Mvc;
using Tarea3BDI.Data;

namespace Tarea3BDI.Controllers
{
    public class ConsultaPlaMensualController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        PlanillaMensualXEmpleadoDatos DatosPlanillaMensualXEmpleado = new PlanillaMensualXEmpleadoDatos();

        public ConsultaPlaMensualController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InicioConsultaPlaMensual(int idUsuario, int idEmpleado)
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var olist = DatosPlanillaMensualXEmpleado.Listar(clientIPAddress, idUsuario, idEmpleado);

            return View(olist);
        }
    }
}
