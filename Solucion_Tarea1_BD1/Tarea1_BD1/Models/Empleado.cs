using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea1_BD1.Models;

public partial class Empleado
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre no puede quedar en blanco")]
    [RegularExpression(@"^[A-Za-z\ \-\xC1\xC9\xCD\xD3\xDA\xDC\xE1\xE9\xED\xF3\xFA\xFC\xD1\xF1]+$", ErrorMessage = "El nombre pude contener letras, espacios, tildes o un guión")]
    [MaxLength(128, ErrorMessage = "El nombre no puede exceder los 128 caracteres")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El salario no puede quedar en blanco")]
    [RegularExpression(@"^[\d]+\.{1}[\d]{2}$", ErrorMessage = "El salario debe ser mayor o igual a cero, debe contener un punto decimal y dos decimales obligatoriamente")]
    [DataType(DataType.Currency)]
    [Range(0.00, 999999999.99, ErrorMessage = "El salario debe estar entre 0.00 y 999,999,999.99")]
    public decimal Salario { get; set; }

}
