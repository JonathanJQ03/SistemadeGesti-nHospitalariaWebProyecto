window.onload = function () {
    ListarCitas();
    cargarPacientes();
    cargarMedicos();
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

function cargarPacientes() {
    console.log("Cargando pacientes..."); // Añade esta línea
    fetchGet("Citas/CargarPacientes", "json", function (data) {
        console.log("Pacientes recibidos:", data); // Y esta línea
        let selectPacientes = document.getElementById("pacienteId");
        selectPacientes.innerHTML = "<option value=''>Seleccione un paciente</option>";
        data.forEach(function (paciente) {
            let option = document.createElement("option");
            option.value = paciente.idPaciente;
            option.text = paciente.nombre + " " + paciente.apellido;
            selectPacientes.appendChild(option);
        });
    });
}
function cargarMedicos() {
    console.log("Intentando cargar médicos...");

    fetchGet("Citas/CargarMedicos", "json", function (data) {
        console.log("Datos recibidos:", data); // Para verificar la respuesta

        let selectMedicos = document.getElementById("medicoId");
        selectMedicos.innerHTML = "<option value=''>Seleccione un médico</option>";

        if (data.length === 0) {
            console.warn("No se recibieron médicos.");
            return;
        }

        data.forEach(function (medico) {
            let option = document.createElement("option");
            option.value = medico.idMedico;
            option.text = medico.nombre + " " + medico.apellido;
            selectMedicos.appendChild(option);
        });
    });
}


function MostrarModal() {
    LimpiarDatos("frmCita");
    var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
    myModal.show();
}

