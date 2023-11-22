using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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

        
        public IActionResult Listar(int idUsuario)
        { 
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var oLista = datosEmpleado.Listar(clientIPAddress, idUsuario);

            ViewBag.idUsuario = idUsuario;
            return View(oLista);
        }

        public IActionResult ListarPorNombre(string NombreEmpleado, int idUsuario)
        {
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var oLista = datosEmpleado.ListarPorNombre(NombreEmpleado, clientIPAddress, idUsuario);

            ViewBag.idUsuario = idUsuario;
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
                return RedirectToAction("Listar", "Mantenedor", new {idUsuario = idUsuario});
            else
                return View();
        }

        
        public IActionResult ELiminar(string NombreEmpleado, int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            ViewBag.NombreEmpleado = NombreEmpleado;

            return View();
        }
        
        
        [HttpPost]
        public IActionResult ConfirmarELiminar(string NombreEmpleado, int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            ViewBag.NombreEmpleado = NombreEmpleado;
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var rpta = datosEmpleado.Eliminar(NombreEmpleado, clientIPAddress, idUsuario);
            if (rpta)
                return RedirectToAction("Listar", "Mantenedor", new { idUsuario = idUsuario });
            else
                return RedirectToAction("Listar", "Mantenedor", new { idUsuario = idUsuario });
        }

        
        public IActionResult Editar(string NombreEmpleado, int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            ViewBag.NombreEmpleado = NombreEmpleado;

            return View();
        }
        [HttpPost]
        public IActionResult Editar(EmpleadoModel empleadoModel, int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var rpta = datosEmpleado.Editar(empleadoModel, clientIPAddress, idUsuario);
            if (rpta)
                return RedirectToAction("Listar", "Mantenedor", new { idUsuario = idUsuario });
            else
                return View();
        }

        public IActionResult Logout(int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var rpta = datosEmpleado.Logout(clientIPAddress, idUsuario);
            return View();
        }

        public IActionResult Impersonar(string NombreEmpleado, int idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            ViewBag.NombreEmpleado = NombreEmpleado;

            return View();
        }

        [HttpPost]
        public IActionResult Impersonar(int idUsuario, string NombreEmpleado)
        {
            ViewBag.idUsuario = idUsuario;
            ViewBag.NombreEmpleado = NombreEmpleado;
            //string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            int IdEmpleado = datosEmpleado.Impersonar(idUsuario, NombreEmpleado);
            if (IdEmpleado != -1)
                return RedirectToAction("InicioAdmin", "UsuarioEmpleado", new { idUsuario = idUsuario, IdEmpleado = IdEmpleado });
            else
                return View("Listar");
        }

    }
}

