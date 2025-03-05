window.onload = function () {
    ListarFacturacion();
}

document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('modalFactura');
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
        console.error('El modal con ID "modalFactura" no se encontró en el DOM.');
    }
});

let objFacturas;
async function ListarFacturacion() {
    objFacturas = {
        url: "Facturacion/ListarFacturacion",
        cabeceras: ["ID", "Paciente", "Monto", "Método de Pago", "Fecha de Pago"],
        propiedades: ["id", "pacienteId", "monto", "metodoPago", "fechaPago"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true,
        propiedadID: "id"
    }
    pintar(objFacturas);
}

function GuardarFactura() {
    let form = document.getElementById("frmFactura");
    let frm = new FormData(form);

    fetchPost("Facturacion/GuardarFactura", "text", frm, function (res) {
        LimpiarDatos("frmFactura");
        Exito("Factura registrada con éxito");
        ListarFacturas();
        var myModal = bootstrap.Modal.getInstance(document.getElementById('modalFactura'));
        if (myModal) myModal.hide();
    });
}

function MostrarModal() {
    LimpiarDatos("frmFactura");
    var myModal = new bootstrap.Modal(document.getElementById('modalFactura'));
    myModal.show();
}

function Editar(id) {
    fetchGet("Facturacion/ObtenerFactura/?id=" + id, "json", function (data) {
        setN("id", data.id);
        setN("pacienteId", data.pacienteId);
        setN("monto", data.monto);
        setN("metodoPago", data.metodoPago);
        setN("fechaPago", data.fechaPago);

        var myModal = new bootstrap.Modal(document.getElementById('modalFactura'));
        myModal.show();
    });
}


