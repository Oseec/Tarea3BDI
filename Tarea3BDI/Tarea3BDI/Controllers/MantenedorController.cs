using Microsoft.AspNetCore.Mvc;

using Tarea3BDI.Data;
using Tarea3BDI.Models;

namespace Tarea3BDI.Controllers
{
    public class MantenedorController : Controller
    {

        DatosEmpleado datosEmpleado = new DatosEmpleado();
        public IActionResult Listar()
        {
            var oLista = datosEmpleado.Listar();
            return View(oLista);
        }
    }
}
