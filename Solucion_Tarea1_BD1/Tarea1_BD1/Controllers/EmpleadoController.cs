using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tarea1_BD1.Models;

namespace Tarea1_BD1.Controllers
{
    
    public class EmpleadoController : Controller
    {
        public readonly Dbtarea1Context _dbContext;
        private readonly ILogger<EmpleadoController> _logger;

        public EmpleadoController(ILogger<EmpleadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //[Route("Listar")] se quita para cargar de una sola vez todos los empleados
        public IActionResult Listar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
