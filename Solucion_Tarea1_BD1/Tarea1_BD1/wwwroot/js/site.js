
// Cambiar el color de los encabezados de la tabla al listar
function ObtenerColorDeFondo() {
    document.getElementById('encId').style.backgroundColor = $("body").css("backgroundColor");
    document.getElementById('encNom').style.backgroundColor = $("body").css("backgroundColor");
    document.getElementById('encSal').style.backgroundColor = $("body").css("backgroundColor");
}

$(document).ready(function () {
    // Desaparece después de 4 segundos
    setTimeout(function () {
        $(".alert").css("opacity", "0"); // Inicia el desvanecimiento
        setTimeout(function () {
            $(".alert").remove(); // Elimina el elemento después del desvanecimiento
        }, 2000); // Tiempo para que el desvanecimiento complete
    }, 4000);

    // Permite cerrar el alert manualmente
    $(".alert .close").click(function () {
        $(this).parent().css("opacity", "0");
        setTimeout(function () {
            $(this).parent().remove();
        }, 2000);
    });
});