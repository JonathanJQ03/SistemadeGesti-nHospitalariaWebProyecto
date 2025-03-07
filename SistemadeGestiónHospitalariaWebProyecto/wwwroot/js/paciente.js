window.onload = function () {
    ListarPacientes();
};

document.addEventListener('DOMContentLoaded', function () {
    // Obtener el modal
    var modal = document.getElementById('pacienteModal');

    // Verificar si el modal existe antes de añadir el event listener
    if (modal) {
        // Limpiar la validación al cerrar el modal
        modal.addEventListener('hidden.bs.modal', function () {
            var form = document.getElementById('frmPaciente');
            if (form) {
                form.classList.remove('was-validated'); // Limpiar la validación
            }

            // Asegurarse de que el backdrop se elimine
            if (document.querySelector('.modal-backdrop')) {
                document.querySelector('.modal-backdrop').remove();
            }
            document.body.classList.remove('modal-open');
            document.body.style.overflow = '';
            document.body.style.paddingRight = '';
        });
    } else {
        console.error('El modal con ID "exampleModalCenter" no se encontró en el DOM.');
    }
});

let objPacientes;
async function ListarPacientes() {
    objPacientes = {
        url: "Pacientes/ListarPacientes",
        cabeceras: ["Id Paciente", "Nombre", "Apellido", "Fecha de Nacimiento", "Telefono", "Correo Electronico", "Dirección"],
        propiedades: ["idPaciente", "nombre", "apellido", "fechaNacimiento", "telefono", "email", "direccion"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true,
        propiedadID: "idPaciente"
    };

    pintar(objPacientes);
}

function GuardarPaciente() {
    let form = document.getElementById("frmPaciente");

    // Verificar si el formulario es válido
    if (!form.checkValidity()) {
        // Si el formulario no es válido, agregar la clase 'was-validated' para mostrar los mensajes de error
        form.classList.add('was-validated');
        return; // Detener la ejecución si el formulario no es válido
    }

    // Si el formulario es válido, proceder con el envío de datos
    let frm = new FormData(form);

    fetchPost("Pacientes/GuardarPacientes", "text", frm, function (res) {
        LimpiarDatos("frmPaciente");
        Exito("Registro Guardado con Éxito");
        ListarPacientes();

        // Cerrar modal correctamente
        var myModal = bootstrap.Modal.getInstance(document.getElementById('pacienteModal'));
        if (myModal) myModal.hide();
    });
}

function MostrarModal() {
    LimpiarDatos("frmPaciente");
    var myModal = new bootstrap.Modal(document.getElementById('pacienteModal'));
    myModal.show();
}

function Editar(id) {
    fetchGet("Pacientes/ObtenerPaciente/?idPaciente=" + id, "json", function (data) {
        setN("idPaciente", data.idPaciente);  
        setN("nombre", data.nombre);
        setN("apellido", data.apellido);
        setN("fechaNacimiento", data.fechaNacimiento);
        setN("telefono", data.telefono);
        setN("email", data.email);
        setN("direccion", data.direccion);

        var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
        myModal.show();
    });
}

function Eliminar(id) {
    fetchGet("Pacientes/ObtenerPaciente/?idPaciente=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar el paciente: " + data.nombre + " ?", function () {
            fetchGet("Pacientes/ELiminarPaciente/?idPaciente=" + id, "text", function (r) {
                Exito("Paciente eliminado del sistema con éxito.");
                ListarPacientes();
            });
        });
    });
}

function validarNombre(input) {
    let regex = /^[^0-9]+$/;
    if (!regex.test(input.value)) {
        input.value = input.value.replace(/[0-9]/g, ''); // Elimina números en tiempo real

    }

} 

function validarTelefono(input) {
    let telefono = document.getElementById("telefono").value.trim();
    let regex = /^09\d{8}$/;

    if (!regex.test(telefono)) {
        alert("El número debe comenzar con 09 y tener exactamente 10 dígitos.");
        return false;
    }

    alert("Número válido.");
    return true;
}