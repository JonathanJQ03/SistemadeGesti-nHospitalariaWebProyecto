document.addEventListener('DOMContentLoaded', function () {
    // Obtener el formulario
    let form = document.getElementById('frmPaciente');
    if (!form) {
        console.error("El formulario con ID 'frmPaciente' no se encontró en el DOM.");
        return;
    }

    form.addEventListener('blur', function (event) {


    }
    

    // Validaciones específicas para el formulario de pacientes
    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Evita el envío del formulario para validar primero

        // Obtener los valores de los campos
        let nombre = document.getElementById('nombre').value.trim();
        let apellido = document.getElementById('apellido').value.trim();
        let fechaNacimiento = document.getElementById('fechaNacimiento').value;
        let telefono = document.getElementById('telefono').value.trim();
        let email = document.getElementById('email').value.trim();
        let direccion = document.getElementById('direccion').value.trim();
        let errorMessage = "";

        // Validación de nombre y apellido (solo letras y espacios)
        let nombreApellidoRegex = /^[A-Za-zÁáÉéÍíÓóÚúÑñ\s]+$/;
        if (!nombreApellidoRegex.test(nombre)) {
            errorMessage += "El nombre solo debe contener letras.<br>";
        }
        if (!nombreApellidoRegex.test(apellido)) {
            errorMessage += "El apellido solo debe contener letras.<br>";
        }

        // Validación de fecha de nacimiento (mayor de 0 años y 1 día, y menor de 100 años)
        let fechaNac = new Date(fechaNacimiento);
        let hoy = new Date();

        // Fecha mínima: Hoy menos 100 años
        let fechaMinima = new Date(hoy.getFullYear() - 100, hoy.getMonth(), hoy.getDate());

        // Fecha máxima: Hoy menos 1 día
        let fechaMaxima = new Date(hoy.getFullYear(), hoy.getMonth(), hoy.getDate() - 1);

        if (fechaNac > fechaMaxima) {
            errorMessage += "El paciente debe tener al menos 0 años y 1 día.<br>";
        }
        if (fechaNac < fechaMinima) {
            errorMessage += "El paciente no puede tener más de 100 años.<br>";
        }

        // Validación de teléfono (10 dígitos, comienza con 09)
        let telefonoRegex = /^09\d{8}$/;
        if (!telefonoRegex.test(telefono)) {
            errorMessage += "El teléfono debe tener 10 dígitos y comenzar con '09'.<br>";
        }

        // Validación de email
        let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            errorMessage += "Por favor, ingrese un email válido.<br>";
        }

        // Validación de dirección (opcional, pero puede añadir una validación básica si se desea)
        if (direccion.length < 5) {
            errorMessage += "La dirección parece demasiado corta.<br>";
        }

        // Mostrar mensajes de error
        let errorContainer = document.getElementById('error-message');
        if (errorContainer) {
            if (errorMessage) {
                errorContainer.innerHTML = errorMessage;
                errorContainer.style.display = 'block';
                return false; // No enviamos el formulario
            } else {
                errorContainer.innerHTML = '';
                errorContainer.style.display = 'none';
            }
        }

        // Si todo está bien, enviamos el formulario
        this.submit();
    });
});