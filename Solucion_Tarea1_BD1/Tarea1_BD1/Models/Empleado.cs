using System;
using System.Collections.Generic;

namespace Tarea1_BD1.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Salario { get; set; }
}
