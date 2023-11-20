using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tarea3BDI.Data;
using Tarea3BDI.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarea3BDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly _DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, _DbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> UploadCatalogo(ArchivoModel model)
        {
            if (model.Archivo != null && model.Archivo.Length > 0)
            {
                using (var reader = new StreamReader(model.Archivo.OpenReadStream()))
                {
                    string xmlContent = await reader.ReadToEndAsync();
                    var inRutaXML = new Microsoft.Data.SqlClient.SqlParameter("@inRutaXML", xmlContent);
                    var resultados = _dbContext.Database.ExecuteSqlRaw("EXEC CargarXML @inRutaXML", inRutaXML);

                }
            }
            return RedirectToAction("Index");
        }

    }
}
35.9
    47.9