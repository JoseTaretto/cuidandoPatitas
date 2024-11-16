// Define una función para mostrar un mensaje de éxito y redireccionar después de un tiempo determinado
function mostrarMensajeSuccess(successMessage, successAlertId) {
    $(document).ready(function () {
        if (successMessage) {

            if (successMessage.includes("Exito")) {
                $("#" + successAlertId).addClass("alert-success"); // Éxito
            } else if (successMessage.includes("Info")) {
                $("#" + successAlertId).addClass("alert-warning"); // Info
            } else if (successMessage.includes("Error")) { 
                $("#" + successAlertId).addClass("alert-danger"); // Error
            }

            $("#" + successAlertId).slideDown();

            setTimeout(function () {
                $("#" + successAlertId).slideUp();
            }, 5000); // Mostrar el mensaje durante 5 segundos
        }
    });
}
