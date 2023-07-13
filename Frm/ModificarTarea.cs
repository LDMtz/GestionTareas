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
    public partial class ModificarTarea : Form
    {
        private int codigoTareaAnterior = -1;
        public ModificarTarea()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = true;

            Conexion oConexion = new Conexion();
            List<Tarea> lista = new List<Tarea>();
            lista=oConexion.listarTareas();

            try
            {
                int indiceLista = 0;
                foreach (Tarea tarea in lista)
                {
                    indiceLista++;
                    if (txtBusqueda.Text != "" && tarea.Codigo == Convert.ToInt32(txtBusqueda.Text))
                    {
                        codigoTareaAnterior = tarea.Codigo;
                        txtCodigo.Text = tarea.Codigo.ToString();
                        txtMateria.Text = tarea.Materia;
                        txtNombre.Text = tarea.Nombre;
                        cboEstado.Text = tarea.Estado ? "Activa" : "Inactiva";
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
                    MessageBox.Show("El código de la tarea debe ser númerico.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ex.GetType() == typeof(OverflowException))
                {
                    MessageBox.Show("El código de la tarea es muy largo.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(ex.ToString(),"Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = false;
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Conexion oConexion = new Conexion();
            Tarea oTarea = new Tarea();

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Es obligatorio que ingreses el código de la tarea","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                oTarea.Codigo = Convert.ToInt32(txtCodigo.Text);
                oTarea.Materia = txtMateria.Text;
                oTarea.Nombre = txtNombre.Text;
                oTarea.Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false;
                oTarea.cTarea = rTBTarea.Text;

                oConexion.ModificarTarea(oTarea,codigoTareaAnterior);
                Limpiar();
            }
            catch(Exception ex)
            {
                if (ex.GetType() == typeof(FormatException))
                {
                    MessageBox.Show("El código de la tarea debe ser númerico.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ex.GetType() == typeof(OverflowException))
                {
                    MessageBox.Show("El código de la tarea es muy largo.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(ex.ToString(),"Exception - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarTarea_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactiva" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activa" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";

            codigoTareaAnterior = -1;
        }

        private void Limpiar()
        {
            txtBusqueda.Text = "";
            txtCodigo.Text = "";
            txtMateria.Text = "";
            txtNombre.Text = "";
            cboEstado.SelectedIndex = 1;
            txtFecha.Text = "";
            rTBTarea.Text = "";

            codigoTareaAnterior = -1;

        }
    }
}
