using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTareas
{
    public partial class EliminarTarea : Form
    {
        public EliminarTarea()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = true;

            Conexion oConexion = new Conexion();
            List<Tarea> lista = new List<Tarea>();
            lista = oConexion.listarTareas();

            try
            {
                int indiceLista = 0;
                foreach (Tarea tarea in lista)
                {
                    indiceLista++;
                    if (txtBusqueda.Text != "" && tarea.Codigo == Convert.ToInt32(txtBusqueda.Text))
                    {
                        txtCodigo.Text = tarea.Codigo.ToString();
                        txtMateria.Text = tarea.Materia;
                        txtNombre.Text = tarea.Nombre;
                        txtEstado.Text = tarea.Estado ? "Activa" : "Inactiva";
                        txtFecha.Text = tarea.Fecha;
                        rTBTarea.Text = tarea.cTarea;
                        return;
                    }
                    else if (indiceLista == lista.Count)
                        MessageBox.Show("No existe ninguna tarea con este codigo de tarea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                if (ex.GetType() == typeof(FormatException))
                {
                    MessageBox.Show("El código de la tarea debe ser númerico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ex.GetType() == typeof(OverflowException))
                {
                    MessageBox.Show("El código de la tarea es muy largo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(ex.ToString(), "Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = false;
            Limpiar();
        }

        private void Limpiar()
        {
            txtBusqueda.Text = "";
            txtCodigo.Text = "";
            txtMateria.Text = "";
            txtNombre.Text = "";
            txtEstado.Text = "";
            txtFecha.Text = "";
            rTBTarea.Text = "";

        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            Conexion oConexion = new Conexion();

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("No hay ninguna tarea en las cajas de texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                oConexion.EliminarTarea(Convert.ToInt32(txtCodigo.Text));
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
