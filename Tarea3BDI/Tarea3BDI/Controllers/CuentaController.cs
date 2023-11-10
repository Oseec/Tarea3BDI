using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tarea3BDI.Data;
using Tarea3BDI.Models;

namespace Tarea3BDI.Controllers
{
    
    public class CuentaController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        DatosUsuario datosUsuario = new DatosUsuario();
        public CuentaController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult ValidacionLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidacionLogin(LoginModel loginModel)
        {
            string clientIPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            (bool validacionResultado, int idUsuario) = datosUsuario.ValidacionLogin(loginModel.Pwd, loginModel.Tipo, loginModel.Username, clientIPAddress);

            if (validacionResultado == true && loginModel.Tipo == 1)
            {
               
                return RedirectToAction("listar", "Mantenedor", new {idUsuario = idUsuario}); 
            }
            else
            {
                if (validacionResultado == true && loginModel.Tipo == 2)
                {
                    // La validación fue exitosa, redirige al usuario a la página deseada
                    return RedirectToAction("Inicio", "UsuarioEmpleado", new {idUsuario = idUsuario});
                }
                else
                {
                    // La validación falló, muestra un mensaje de error o redirige al usuario a una página de inicio de sesión
                    return View();
                }               
            }
        }
    }
}




/*
[HttpPost]
public IActionResult ValidarLogin(LoginModel loginModel)
{
    string clientIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
    int idUsuario;
    int tipoDeUsuario;

    // Llama al método ValidarLogin para obtener idUsuario y tipoDeUsuario
    datosUsuario.ValidarLogin(loginModel, clientIPAddress, out idUsuario, out tipoDeUsuario);

    if (idUsuario != -1)
    {
        // El inicio de sesión fue exitoso y los valores se obtuvieron correctamente
        // Ahora puedes utilizar idUsuario y tipoDeUsuario según tus necesidades
        // Por ejemplo, puedes redirigir al usuario a diferentes páginas o realizar acciones específicas según el tipo de usuario.

        if (tipoDeUsuario == 1)
        {
            // Realiza acciones específicas para usuarios administradores
            return RedirectToAction("Listar");
        }
        else if (tipoDeUsuario == 2)
        {
            // Realiza acciones específicas para usuarios empleados
            //return RedirectToAction("vista para empleados")
        }

        return RedirectToAction("Listar");
    }
    else
    {
        // El inicio de sesión falló
        return View();
    }
}
*/
