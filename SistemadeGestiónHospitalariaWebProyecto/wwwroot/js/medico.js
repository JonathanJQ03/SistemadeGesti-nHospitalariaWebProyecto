window.onload = function () {
    ListarMedicos();
    cargarEspecialidad();
}

document.addEventListener('DOMContentLoaded', function () {
    // Obtener el modal
    var modal = document.getElementById('exampleModalCenter');

    // Verificar si el modal existe antes de añadir el event listener
    if (modal) {
        // Limpiar la validación al cerrar el modal
        modal.addEventListener('hidden.bs.modal', function () {
            var form = document.getElementById('frmMedico');
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

let objMedicos;
async function ListarMedicos() {

    objMedicos = {
        url: "Medicos/ListarMedicos",
        cabeceras: ["Id Médico", "Nombre", "Apellido", "Id Especialidad", "Telefono", "Correo Electronico"],
        propiedades: ["idMedico", "nombre", "apellido", "especialidadId", "telefono", "email"],
        divContenedorTabla: "divContenedorTabla",
        propiedadID: "idMedico",
        
    }

    pintar(objMedicos); // Asegurarse de que la función pintar se complete antes de continuar
}

function GuardarMedico() {
    let form = document.getElementById("frmMedico");

    if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
    }

    let frm = new FormData(form);

    fetchPost("Medicos/GuardarMedicos", "text", frm, function (res) {
        LimpiarDatos("frmMedico");
        Exito("Registro Guardado con Éxito");
        ListarMedicos();
        var myModal = bootstrap.Modal.getInstance(document.getElementById('exampleModalCenter'));
        if (myModal) myModal.hide();
    });
}

function cargarEspecialidad() {
    console.log("Cargando Especialidades..."); // Añade esta línea
    fetchGet("Medicos/CargarEspecialidad", "json", function (data) {
        console.log("Especialidades recibidas:", data); // Y esta línea
        let selectEspecialidad = document.getElementById("especialidadId");
        selectEspecialidad.innerHTML = "<option value=''>Seleccione una especalidad</option>";
        data.forEach(function (especialidad) {
            let option = document.createElement("option");
            option.value = especialidad.especialidadId;
            option.text = especialidad.nombre;
            selectEspecialidad.appendChild(option);
        });
    });
}
function MostrarModal() {
    LimpiarDatos("frmMedico");
    var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
    myModal.show();
}
