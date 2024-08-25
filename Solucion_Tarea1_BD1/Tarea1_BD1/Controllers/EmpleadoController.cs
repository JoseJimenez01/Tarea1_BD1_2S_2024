using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Tarea1_BD1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tarea1_BD1.Controllers
{

    public class EmpleadoController : Controller
    {
        public readonly Dbtarea1Context _dbContext;

        public EmpleadoController(Dbtarea1Context _context)
        {
            _dbContext = _context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                //Se crea a conexión se abre
                SqlConnection connection = (SqlConnection)_dbContext.Database.GetDbConnection();
                connection.Open();

                //Se crea el SP
                SqlCommand comando = connection.CreateCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_ListarEmpleados";

                //Código para crear parámetros al Store Procedure
                SqlParameter parametroMens = new SqlParameter();
                parametroMens.ParameterName = "@outMessage";
                parametroMens.SqlDbType = SqlDbType.VarChar;
                parametroMens.Size = 128;
                parametroMens.Value = "mensaje enviado desde C#";
                parametroMens.Direction = ParameterDirection.InputOutput;

                SqlParameter parametroCod = new SqlParameter();
                parametroCod.ParameterName = "@outResult";
                parametroCod.SqlDbType = SqlDbType.Int;
                parametroCod.Value = -567;
                parametroCod.Direction = ParameterDirection.InputOutput;

                //Se agrega cada parámetro al SP
                comando.Parameters.Add(parametroMens);
                comando.Parameters.Add(parametroCod);

                //Se leen los datos devueltos por el SP(dataset)
                SqlDataReader reader = comando.ExecuteReader();
                List<Models.Empleado> listaEmpleados = new List<Models.Empleado>();
                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = Convert.ToInt16(reader["id"]);
                    empleado.Nombre = Convert.ToString(reader["Nombre"])!;
                    empleado.Salario = Convert.ToDecimal(reader["Salario"]);
                    listaEmpleados.Add(empleado);
                }
                reader.Close();

                //Se leen los parámetros de salida
                comando.ExecuteNonQuery();
                Console.WriteLine("\n------------------- SE HA EJECUTADO EL SP_LISTAREMPLEADOS -------------------");
                Console.WriteLine(" El mensaje de salida del sp es: " + comando.Parameters["@outMessage"].Value.ToString()!);
                Console.WriteLine(" El codigo de salida del sp es: " + comando.Parameters["@outResult"].Value.ToString()!);
                Console.WriteLine("-----------------------------------------------------------------------------\n");
                connection.Close();
                return View(listaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("agregar_empleados")]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarDataAnnotations(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                string json = IngresarEmpleadoEnBD(empleado.Nombre, empleado.Salario);
                dynamic mensaje = JsonConvert.DeserializeObject(json);
                if (mensaje["mensaje"].ToString() == "El empleado ya existe en la base de datos")
                {
                    return HacerAviso("Agregar", "Nombre de empleado ya existe", empleado);
                }else if (mensaje["mensaje"].ToString() == "Empleado agregado exitosamente")
                {
                    return HacerAviso("Listar", "Inserción exitosa", empleado);
                }
            }
            return HacerAviso("Listar", "No debería de poder verse este mensaje.", empleado);
        }

        public ActionResult HacerAviso(string nombreVista, string aviso, Empleado modelo)
        {
            TempData["Message"] = aviso;
            if(nombreVista == "Listar")
            {
                return RedirectToAction(nombreVista);
            }
            return RedirectToAction(nombreVista, modelo);
        }

        [HttpPost]
        public string IngresarEmpleadoEnBD(string nombreForm, Decimal salarioForm)
        {
            try
            {
                //Se crea a conexión se abre
                SqlConnection connection = (SqlConnection)_dbContext.Database.GetDbConnection();
                connection.Open();

                //Se crea el SP
                SqlCommand comando = connection.CreateCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_AgregarEmpleados";

                //Código para crear parámetros al Store Procedure
                SqlParameter parametroNom = new SqlParameter
                {
                    ParameterName = "@inNombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 128,
                    Value = nombreForm,
                    Direction = ParameterDirection.Input
                };

                SqlParameter parametroSal = new SqlParameter
                {
                    ParameterName = "@inSalario",
                    SqlDbType = SqlDbType.Money,
                    Value = salarioForm,
                    Direction = ParameterDirection.Input
                };

                SqlParameter parametroMens = new SqlParameter
                {
                    ParameterName = "@outMessage",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 128,
                    Value = "mensaje enviado desde C#",
                    Direction = ParameterDirection.InputOutput
                };

                SqlParameter parametroCod = new SqlParameter
                {
                    ParameterName = "@outResult",
                    SqlDbType = SqlDbType.Int,
                    Value = -567,
                    Direction = ParameterDirection.InputOutput
                };

                //Se agrega cada parámetro al SP
                comando.Parameters.Add(parametroNom);
                comando.Parameters.Add(parametroSal);
                comando.Parameters.Add(parametroMens);
                comando.Parameters.Add(parametroCod);

                //Se leen los parámetros de salida
                comando.ExecuteNonQuery();
                string SPmessage = comando.Parameters["@outMessage"].Value.ToString()!;
                string SPresult = comando.Parameters["@outResult"].Value.ToString()!;
                Console.WriteLine("\n------------------- SE HA EJECUTADO EL SP_AGREGAREMPLEADOS -------------------");
                Console.WriteLine(" El mensaje de salida del sp es: " + comando.Parameters["@outMessage"].Value.ToString()!);
                Console.WriteLine(" El codigo de salida del sp es: " + comando.Parameters["@outResult"].Value.ToString()!);
                Console.WriteLine("-----------------------------------------------------------------------------\n");

                connection.Close();

                if (SPmessage == "El empleado ya existe" || SPresult == "1")
                {
                    return @"{ 'mensaje': 'El empleado ya existe en la base de datos' }";
                    //return "El empleado ya existe en la base de datos";

                }
                else if (SPmessage == "Empleados agregados exitosamente." || SPresult == "0")
                {
                    return @"{ 'mensaje': 'Empleado agregado exitosamente' }";
                }
            }
            catch (Exception ex)
            {
                //string error = ex.Message;
                //return @"{ 'mensaje': 'error' }";
            }
            return @"{ 'mensaje': 'Hubo algun error inesperado'}";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
