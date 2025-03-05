//using Capa_Entidad;
//using Capa_Negocio;
//using Xceed.Wpf.Toolkit;

//public class PacienteForm : Form
//{
//    // Controles del formulario (simulados)
//    private TextBox txtIdPaciente = new TextBox();
//    private TextBox txtNombre = new TextBox();
//    private TextBox txtApellido = new TextBox();
//    private DateTimePicker dtpFechaNacimiento = new DateTimePicker();
//    private TextBox txtTelefono = new TextBox();
//    private TextBox txtEmail = new TextBox();
//    private TextBox txtDireccion = new TextBox();

//    // Método público para manejar el evento de clic en el botón Guardar
//    public void btnGuardar_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            // Crear el objeto PacientesCLS con los datos del formulario
//            PacientesCLS paciente = new PacientesCLS
//            {
//                idPaciente = string.IsNullOrEmpty(txtIdPaciente.Text) ? 0 : int.Parse(txtIdPaciente.Text), // Si el ID es opcional
//                nombre = txtNombre.Text,
//                apellido = txtApellido.Text,
//                fechaNacimiento = dtpFechaNacimiento.Value,
//                telefono = txtTelefono.Text,
//                email = txtEmail.Text,
//                direccion = txtDireccion.Text
//            };

//            // Llamar a la capa de negocio para guardar el paciente
//            PacienteBL bl = new PacienteBL();
//            int resultado = bl.GuardarPacientes(paciente);

//            // Mostrar mensaje de éxito
//            MessageBox.Show("Paciente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            // Limpiar el formulario o cerrar la ventana (opcional)
//            LimpiarFormulario();
//        }
//        catch (ArgumentException ex)
//        {
//            // Mostrar el mensaje de error específico de validación
//            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//        catch (Exception ex)
//        {
//            // Manejar errores inesperados
//            MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//    }

//    // Método privado para limpiar el formulario
//    private void LimpiarFormulario()
//    {
//        // Limpiar los campos del formulario
//        txtIdPaciente.Clear();
//        txtNombre.Clear();
//        txtApellido.Clear();
//        dtpFechaNacimiento.Value = DateTime.Now;
//        txtTelefono.Clear();
//        txtEmail.Clear();
//        txtDireccion.Clear();
//    }
//}
