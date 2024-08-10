// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ObtenerColorDeFondo() {
    document.getElementById('encId').style.backgroundColor = $("body").css("backgroundColor");
    document.getElementById('encNom').style.backgroundColor = $("body").css("backgroundColor");
    document.getElementById('encSal').style.backgroundColor = $("body").css("backgroundColor");
}

function validarFormulario() {
    var nombre = document.getElementById("entNom").value;
    var salario = document.getElementById("entSal").value;
    //console.log(nombre);
    //console.log(salario);
    //alert(nombre + salario);
    if (nombre == "") {
        alert("Nombre obligatorio");
    }
}