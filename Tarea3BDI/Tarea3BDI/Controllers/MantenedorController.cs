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
        public IActionResult Listar()
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();


            var oLista = datosEmpleado.Listar(clientIPAddress);
            return View(oLista);
        }

        public IActionResult InsertarEmpleado(int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            return View();
        }
        [HttpPost]
        public IActionResult InsertarEmpleado(EmpleadoModel empleadoModel, int idUsuario)
        {
            
            
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var respuesta = datosEmpleado.InsertarEmpleado(empleadoModel, clientIPAddress, idUsuario);
            if(respuesta)
                return RedirectToAction("Index", "Home");
            else
                return View();
        }  
    }
}

/*
public IActionResult ObtieneIdUsuario(LoginModel loginModel)
{
    string pwd = loginModel.Pwd;
    int tipo = loginModel.Tipo;
    string username = loginModel.Username;

    int IdUsuario = datosEmpleado.ObtieneIdUsuario(username, pwd, tipo);
    return View();
}
*/