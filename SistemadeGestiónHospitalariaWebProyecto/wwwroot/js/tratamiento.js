window.onload = function () {
    ListarTratamientos();
}

document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('exampleModalCenter');
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
        console.error('El modal con ID "exampleModalCenter" no se encontró en el DOM.');
    }
});

let objTratamientos;
async function ListarTratamientos() {
    objTratamientos = {
        url: "Tratamientos/ListarTratamientos",
        cabeceras: ["Id Tratamiento", "Id Paciente", "Descripción", "Fecha", "Costo"],
        propiedades: ["idTratamiento", "pacienteId", "descripcion", "fecha", "costo"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true,
        propiedadID: "idTratamiento"
    };
    pintar(objTratamientos);
}

function GuardarTratamiento() {
    let form = document.getElementById("frmTratamiento");
    let frm = new FormData(form);

    fetchPost("Tratamientos/GuardarTratamiento", "text", frm, function (res) {
        LimpiarDatos("frmTratamiento");
        Exito("Registro Guardado con Éxito");
        ListarTratamientos();
        // Cerrar modal correctamente
        var myModal = bootstrap.Modal.getInstance(document.getElementById('exampleModalCenter'));
        if (myModal) myModal.hide();
    });
}

function MostrarModal() {
    LimpiarDatos("frmTratamiento");
    var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
    myModal.show();
}

function Editar(id) {
    fetchGet("Tratamientos/ObtenerTratamiento/?idTratamiento=" + id, "json", function (data) {
        setN("idTratamiento", data.idTratamiento);
        setN("pacienteId", data.pacienteId);
        setN("descripcion", data.descripcion);
        setN("fecha", data.fecha);
        setN("costo", data.costo);

        var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
        myModal.show();
    });
}

