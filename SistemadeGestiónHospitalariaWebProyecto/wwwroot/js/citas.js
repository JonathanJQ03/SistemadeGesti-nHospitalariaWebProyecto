window.onload = function () {
    ListarCitas();
}

document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('modalCita'); // Usa el ID correcto
    if (modal) {
        modal.addEventListener('hidden.bs.modal', function () {
            // Asegurarse de que el backdrop se elimine
            if (document.querySelector('.modal-backdrop')) {
                document.querySelector('.modal-backdrop').remove();
            }
            document.body.classList.remove('modal-open');
            document.body.style.overflow = '';
            document.body.style.paddingRight = '';
        });
    } else {
        console.error('El modal con ID "modalCita" no se encontró en el DOM.');
    }
});

let objCitas;
async function ListarCitas() {

    objCitas = {
        url: "Citas/ListarCitas",
        cabeceras: ["Id Cita", "PacienteId", "Medico", "Fecha y Hora", "EstadoCita"],
        propiedades: ["id", "pacienteId","medicoID", "fechaHora", "estado"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true,
        propiedadID: "id"
    }

    pintar(objCitas);
}

//function GuardarEspecialidad() {
//    let form = document.getElementById("frmEspecialidad");
//    let frm = new FormData(form);

//    fetchPost("Especialidad/GuardarEspecialidades", "text", frm, function (res) {
//        LimpiarDatos("frmEspecialidad");
//        Exito("Registro Guardado con Éxito");
//        ListarEspecialidades();

//        // Cerrar modal correctamente
//        var myModal = bootstrap.Modal.getInstance(document.getElementById('exampleModalCenter'));
//        if (myModal) myModal.hide();
//    });
//}

function MostrarModal() {
    LimpiarDatos("frmCita");
    var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
    myModal.show();
}

//function Editar(id) {
//    fetchGet("Especialidad/ObtenerEspecialidad/?id=" + id, "json", function (data) {
//        setN("id", data.id);
//        setN("nombre", data.nombre);

//        var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
//        myModal.show();
//    });
//}

//function Eliminar(id) {
//    fetchGet("Especialidad/ObtenerEspecialidad/?id=" + id, "json", function (data) {
//        Confirmar(undefined, "¿Desea eliminar la especialidad: " + data.nombre + " ?", function () {
//            fetchGet("Especialidad/EliminarEspecialidad/?id=" + id, "text", function (r) {
//                Exito("Especialidad eliminada del sistema con éxito.");
//                ListarEspecialidades();
//            });
//        });
//    });
//}
////function cargarMedicos() {
////    fetchGet("Medicos/ListarMedicos", "json", function (data) {
////        let selectMedicos = document.getElementById("medicoId");
////        selectMedicos.innerHTML = "<option value=''>Seleccione un médico</option>";

////        data.forEach(function (medico) {
////            let option = document.createElement("option");
////            option.value = medico.id;
////            option.text = medico.nombre + " " + medico.apellido; // Ajusta esto según la estructura de tus datos
////            selectMedicos.appendChild(option);
////        });
////    });
////}

// Función para cargar los pacientes en el select
function cargarPacientes() {
    fetchGet("Pacientes/ListarPacientes", "json", function (data) {
        let selectPacientes = document.getElementById("idPaciente");
        selectPacientes.innerHTML = "<option value=''>Seleccione un paciente</option>";

        data.forEach(function (paciente) {
            let option = document.createElement("option");
            option.value = paciente.idPaciente;
            option.text = paciente.nombre + " " + paciente.apellido; 
            selectPacientes.appendChild(option);
        });
    });
}