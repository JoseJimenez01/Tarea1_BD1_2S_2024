using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using Tarea1_BD1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tarea1_BD1.Controllers
{
    
    public class EmpleadoController : Controller
    {
        public readonly Dbtarea1Context _dbContext;
        //private readonly ILogger<EmpleadoController> _logger;

        public EmpleadoController(Dbtarea1Context _context)
        {
            _dbContext = _context;
        }
        //public EmpleadoController(ILogger<EmpleadoController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        //[Route("Listar")] se quita para cargar de una sola vez todos los empleados
        public IActionResult Listar()
        {
            try
            {
                SqlConnection connection = (SqlConnection)_dbContext.Database.GetDbConnection();
                connection.Open();

                SqlCommand comando = connection.CreateCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_ListarEmpleados";
                //si se ocupan parametros se le agregan con los siguiente
                comando.Parameters.Add("@outMessage", System.Data.SqlDbType.VarChar, 128).Value = "";
                comando.Parameters.Add("@outResult", System.Data.SqlDbType.Int, 1).Value = 0;

                SqlDataReader reader = comando.ExecuteReader();
                List<Models.Empleado> listaEmpleados = new List<Models.Empleado>();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = reader.GetInt32(0);
                    empleado.Nombre = reader.GetString(1);
                    empleado.Salario = reader.GetDecimal(2);
                    listaEmpleados.Add(empleado);
                }
                connection.Close();
                reader.Close();

                return View(listaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("agregar_empleados")]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult IngresarEmpleadoEnBD(string nombreForm, Decimal salarioForm )
        public JsonResult IngresarEmpleadoEnBD(string nombreForm, Decimal salarioForm)
        {
            try
            {
                SqlConnection connection = (SqlConnection)_dbContext.Database.GetDbConnection();
                connection.Open();

                SqlCommand comando = connection.CreateCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_AgregarEmpleados";
                //si se ocupan parametros se le agregan con los siguiente
                comando.Parameters.Add("@inNombre", System.Data.SqlDbType.VarChar, 128).Value = nombreForm;
                comando.Parameters.Add("inSalario", System.Data.SqlDbType.Money).Value = salarioForm;
                comando.Parameters.Add("@outMessage", System.Data.SqlDbType.VarChar, 128).Value = "";
                comando.Parameters.Add("@outResult", System.Data.SqlDbType.Int).Value = 0;

                //SqlDataReader reader = comando.ExecuteReader();
                //List<Models.Empleado> listaEmpleados = new List<Models.Empleado>();

                //while (reader.Read())
                //{
                //    Empleado empleado = new Empleado();
                //    empleado.Id = reader.GetInt32(0);
                //    empleado.Nombre = reader.GetString(1);
                //    empleado.Salario = reader.GetDecimal(2);
                //    listaEmpleados.Add(empleado);
                //}
                connection.Close();
                //reader.Close();

                string SPmessage = comando.Parameters["@outMessage"].Value.ToString();
                string SPresult = comando.Parameters["@outResult"].Value.ToString();
                if (SPmessage == "El empleado ya existe" || SPresult == "1")
                {
                    return Json(new {mensaje = "El empleado ya existe en la base de datos" });
                }
                else if (SPmessage == "Empleados agregados exitosamente." || SPresult == "0")
                {
                    return Json(new {mensaje = "Empleado agregado exitosamente"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {mensaje = ex.Message});
            }
            return Json(new {mensaje = "Hubo algun error inesperado"});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
