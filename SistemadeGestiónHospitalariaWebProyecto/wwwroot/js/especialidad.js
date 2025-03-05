window.onload = function () {
    ListarEspecialidades();
}

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('exampleModalCenter').addEventListener('hidden.bs.modal', function () {
        // Asegurarse de que el backdrop se elimine
        if (document.querySelector('.modal-backdrop')) {
            document.querySelector('.modal-backdrop').remove();
        }
        document.body.classList.remove('modal-open');
        document.body.style.overflow = '';
        document.body.style.paddingRight = '';
    });
});

let objEspecialidades;
async function ListarEspecialidades() {

    objEspecialidades = {
        url: "Especialidad/ListarEspecialidades",
        cabeceras: ["Id Especialidad", "Nombre"],
        propiedades: ["especialidadId", "nombre"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true,
        propiedadID: "idespecialidadId
    }

    pintar(objEspecialidades);
}

function GuardarEspecialidad() {
    let form = document.getElementById("frmEspecialidad");
    let frm = new FormData(form);

    fetchPost("Especialidad/GuardarEspecialidades", "text", frm, function (res) {
        LimpiarDatos("frmEspecialidad");
        Exito("Registro Guardado con Éxito");
        ListarEspecialidades();

        // Cerrar modal correctamente
        var myModal = bootstrap.Modal.getInstance(document.getElementById('exampleModalCenter'));
        if (myModal) myModal.hide();
    });
}

function MostrarModal() {
    LimpiarDatos("frmEspecialidad");
    var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
    myModal.show();
}

function Editar(id) {
    fetchGet("Especialidad/ObtenerEspecialidad/?especialidadId=" + id, "json", function (data) {
        setN("especialidadId", data.id); 
        setN("nombre", data.nombre);

        var myModal = new bootstrap.Modal(document.getElementById('exampleModalCenter'));
        myModal.show();
    });
}

function Eliminar(id) {
    fetchGet("Especialidad/ObtenerEspecialidad/?especialidadId=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar la especialidad: " + data.nombre + " ?", function () {
            fetchGet("Especialidad/EliminarEspecialidad/?id=" + id, "text", function (r) {
                Exito("Especialidad eliminada del sistema con éxito.");
                ListarEspecialidades();
            });
        });
    });
}
