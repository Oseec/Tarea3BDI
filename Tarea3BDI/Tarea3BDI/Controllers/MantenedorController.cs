using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tarea3BDI.Data;
using Tarea3BDI.Models;

namespace Tarea3BDI.Controllers
{
    public class MantenedorController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        DatosEmpleado datosEmpleado = new DatosEmpleado();

        public MantenedorController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Listar()
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var oLista = datosEmpleado.Listar(clientIPAddress);
            return View(oLista);
        }

        public IActionResult InsertarEmpleado()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertarEmpleado(EmpleadoModel empleadoModel)
        {
            var respuesta = datosEmpleado.InsertarEmpleado(empleadoModel);
            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
