using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HotelSOL1.FormsAPP
{
    public partial class ExportarOdooForm : Form
    {
        public ExportarOdooForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string scriptDir = @"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\OdooExportScripts";
            string importarScriptPath = @"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\python";

            if (CheckBoxClientes.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_clientes.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "importar_clientes.py"));
            }

            if (CheckBoxReservas.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_reservas.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "importar_reservas.py"));
            }

            if (CheckBoxHabitaciones.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_habitaciones.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "importar_habitaciones.py"));
            }

            if (CheckBoxReservasHabitaciones.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_reservas_habitaciones.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "importar_reserva_habitaciones.py"));
            }

            if (CheckBoxServicios.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_servicios.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "import_servicios.py"));
            }

            if (CheckBoxIncidencias.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_incidencias.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "importar_incidencias.py"));
            }

            if (CheckBoxUsuarios.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_usuarios.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "import_usuarios.py"));
            }

            if (CheckBoxFacturas.Checked)
            {
                EjecutarScriptPython(Path.Combine(scriptDir, "export_facturas.py"));
                System.Threading.Thread.Sleep(3000);
                EjecutarScriptPython(Path.Combine(importarScriptPath, "importar_facturas.py"));
            }

            MessageBox.Show("Exportación completada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void EjecutarScriptPython(string scriptPath)
        {
            var start = new ProcessStartInfo
            {
                FileName = "python", // o "python3" si estás en Linux/macOS
                Arguments = $"\"{scriptPath}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = Process.Start(start))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show($"Error en script {Path.GetFileName(scriptPath)}:\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void CheckBoxIncidencias_CheckedChanged(object sender, EventArgs e)
        {
            // Este método fue referenciado en el Designer, así que lo definimos para evitar errores.
        }
    }
}
