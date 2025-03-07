window.onload = function () {
    ListarCitas();
    cargarPacientes();
    cargarMedicos();
}

document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('modalCita');
    if (modal) {
        modal.addEventListener('hidden.bs.modal', function () {
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
    console.log("Cargando pacientes..."); 
    fetchGet("Citas/CargarPacientes", "json", function (data) {
        console.log("Pacientes recibidos:", data); 
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
        console.log("Datos recibidos:", data); 
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
function GuardarCita() {
    let form = document.getElementById("frmCita");

    
    if (!form.checkValidity()) {
        form.classList.add('was-validated'); 
        return; 
    }

    
    let frm = new FormData(form);

    fetchPost("Citas/GuardarCita", "text", frm, function (res) {
        LimpiarDatos("frmCita");
        Exito("Cita guardada con éxito");
        ListarCitas();

        
        var myModal = bootstrap.Modal.getInstance(document.getElementById('modalCita'));
        if (myModal) myModal.hide();
    });
}

function Editar(id) {
    fetchGet("Citas/ObtenerCita/?id=" + id, "json", function (data) {
        setN("id", data.id);
        setN("pacienteId", data.pacienteId);
        setN("medicoId", data.medicoId);
        setN("fechaHora", data.fechaHora);
        setN("estado", data.estado);

        
        var myModal = new bootstrap.Modal(document.getElementById('modalCita'));
        myModal.show();
    });
}


function Eliminar(id) {
    fetchGet("Citas/ObtenerCita/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar la cita programada para el " + data.fechaHora + "?", function () {
            fetchGet("Citas/EliminarCita/?id=" + id, "text", function (r) {
                Exito("Cita eliminada con éxito.");
                ListarCitas();
            });
        });
    });
}
function LimpiarDatos(formId) {
    let form = document.getElementById(formId);
    if (form) {
        form.reset();
        form.classList.remove('was-validated'); 
    }
}
function MostrarModal() {
    LimpiarDatos("frmCita");
    var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
    myModal.show();
}

