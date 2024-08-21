// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Constantes para hacer avisos
const abrirPopup = document.getElementById('btnSubmit');
const cerrarPopup = document.getElementById('btnCerrarPopup');
const contenedorPopup = document.getElementById('elPopup');
const taparContenido = document.getElementById('overlay');


// Cambiar el color de los encabezados de la tabla al listar
function ObtenerColorDeFondo() {
    document.getElementById('encId').style.backgroundColor = $("body").css("backgroundColor");
    document.getElementById('encNom').style.backgroundColor = $("body").css("backgroundColor");
    document.getElementById('encSal').style.backgroundColor = $("body").css("backgroundColor");
}

// Abrir el div para hacer avisos y muestra el aviso
function avisos(mensaje) {
    taparContenido.style.display = 'block';
    contenedorPopup.style.display = 'flex';
    document.getElementById('labelParaAviso').innerHTML = mensaje;
}

// Hace las validaciones en el formulario
function validarFormulario() {
    let nombre = document.getElementById("entNom").value;
    let salario = document.getElementById("entSal").value;

    let expresionRegularNombre = /[A-Za-z\ \-\xC1\xC9\xCD\xD3\xDA\xDC\xE1\xE9\xED\xF3\xFA\xFC\xD1\xF1]+/g;
    let expresionRegularSalario = /[\d]+\.{1}[\d]{2}/g;

    if (nombre == "") {
        avisos("Debe digitar el nombre");
        return;
    //La doble validación es necesaria
    } else if (expresionRegularNombre.test(nombre) === false || !(nombre.match(expresionRegularNombre) == nombre)) {
        avisos("El nombre solo puede incluir letras, espacios o guiones");
        return;
    } else if (salario == "") {
        avisos("Debe digitar el salario");
        return;
    //La doble validación es necesaria
    } else if (expresionRegularSalario.test(salario) === false || !(salario.match(expresionRegularSalario) == salario)) {
        avisos("El salario solo puede usar el punto como separador decimal y dos decimales obligatorios");
        return;
    }
}

// Funciones para abrir y cerrar el popup
function showPopup() {
    taparContenido.style.display = 'block';
    contenedorPopup.style.display = 'flex';
}

function hidePopup() {
    taparContenido.style.display = 'none';
    contenedorPopup.style.display = 'none';
}

// Event listeners para abrir y cerrar el popup
/*abrirPopup.addEventListener('click', showPopup);*/
cerrarPopup.addEventListener('click', hidePopup);

document.addEventListener('click', function (event) {
    // Valida si el clic sucedio en el contenedor overlay
    if (taparContenido.contains(event.target)) {
        hidePopup();
    }
});
