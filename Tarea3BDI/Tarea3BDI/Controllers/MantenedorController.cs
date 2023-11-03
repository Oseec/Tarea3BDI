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
        DatosUsuario datosUsuario = new DatosUsuario();

        public MantenedorController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Listar(LoginModel loginModel)
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            string pwd = loginModel.Pwd;
            int tipo = loginModel.Tipo;
            string username = loginModel.Username;
            int IdUsuario = datosUsuario.ObtieneIdUsuario(username, pwd, tipo);

            var oLista = datosEmpleado.Listar(clientIPAddress, IdUsuario);
            return View(oLista);
        }

        public IActionResult InsertarEmpleado()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertarEmpleado(EmpleadoModel empleadoModel, LoginModel loginModel)
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            string pwd = loginModel.Pwd;
            int tipo = loginModel.Tipo;
            string username = loginModel.Username;
            int IdUsuario = datosUsuario.ObtieneIdUsuario(username, pwd, tipo);

            var respuesta = datosEmpleado.InsertarEmpleado(empleadoModel, clientIPAddress, IdUsuario);
            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        /*
        public IActionResult ObtieneIdUsuario(LoginModel loginModel)
        {
            string pwd = loginModel.Pwd;
            int tipo = loginModel.Tipo;
            string username = loginModel.Username;

            int IdUsuario = datosUsuario.ObtieneIdUsuario(username, pwd, tipo);
            return View();
        }
        */
    }
}
 