// Validar que el nombre y apellido solo contengan letras y espacios
function validarNombre(input) {
    let regex = /^[A-Za-zÁáÉéÍíÓóÚúÑñ\s]+$/;
    if (!regex.test(input.value)) {
        input.value = input.value.replace(/[^A-Za-zÁáÉéÍíÓóÚúÑñ\s]/g, ''); 
    }
}


function validarTelefono(input) {
    let telefono = input.value.trim();
    let regex = /^09\d{8}$/;
    let errorContainer = document.getElementById('telefono-error');

    if (!regex.test(telefono)) {
        if (errorContainer) {
            errorContainer.textContent = "El número debe comenzar con 09 y tener exactamente 10 dígitos.";
            errorContainer.style.display = 'block';
        }
        return false;
    } else {
        if (errorContainer) {
            errorContainer.textContent = '';
            errorContainer.style.display = 'none';
        }
        return true;
    }
}


document.addEventListener('DOMContentLoaded', function () {
    let telefonoInput = document.getElementById('telefono');
    if (telefonoInput) {
        telefonoInput.addEventListener('blur', function () {
            validarTelefono(this);
        });

        telefonoInput.addEventListener('input', function () {
            validarTelefono(this);
        });
    }
});