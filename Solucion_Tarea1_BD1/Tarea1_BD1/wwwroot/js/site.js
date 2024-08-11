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

    let expresionRegularNombre = /[A-Za-z\ \-\xC1\xC9\xCD\xD3\xDA\xDC\xE1\xE9\xED\xF3\xFA\xFC\xD1\xF1]+/g;
    let expresionRegularSalario = /[\d]+\.{1}[\d]{2}/g;

    if (nombre == "") {
        //alert("Debe digitar el nombre.");

    //La doble validación es necesaria
    } else if (expresionRegularNombre.test(nombre) === false || !(nombre.match(expresionRegularNombre) == nombre)) {
        alert("El nombre solo puede incluir letras, espacios o guiones.");
    } else if (salario == "") {
        alert("Debe digitar el salario.");
        //La doble validación es necesaria
    } else if (expresionRegularSalario.test(salario) === false || !(salario.match(expresionRegularSalario) == salario)) {
        alert("El salario solo puede usar el punto como separador decimal y dos decimales obligatorios.");
    }
}

function cerrarDivAvisos() {

}

/*
    Desde aqui el JS para el popup de avisos
*/

const abrirPopup = document.getElementById('btnSubmit');
const cerrarPopup = document.getElementById('btnCerrarPopup');
const contenedorPopup = document.getElementById('elPopup');
const taparContenido = document.getElementById('overlay');


// Funciones para abrir y cerrar el popup
function showPopup() {
    taparContenido.style.display = 'block';
    contenedorPopup.style.display = 'block';
}

function hidePopup() {
    taparContenido.style.display = 'none';
    contenedorPopup.style.display = 'none';
}

// Event listeners para abrir y cerrar el popup
abrirPopup.addEventListener('click', showPopup);
cerrarPopup.addEventListener('click', hidePopup);

document.addEventListener('click', function (event) {
    // Valida si el clic sucedio en el contenedor overlay
    if (taparContenido.contains(event.target)) {
        hidePopup();
    }
});

/*
    Hasta aqui el JS para el popup de avisos
*/