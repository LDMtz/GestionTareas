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
    public partial class AgregarTarea : Form
    {
        public AgregarTarea()
        {
            InitializeComponent();
        }

        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {
            Conexion oConexion = new Conexion();
            Tarea oTarea = new Tarea();

            //Si no ingresa el Codigo de la Tarea
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Es obligatorio que ingreses el código de la tarea.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            try
            {
                oTarea.Codigo = Convert.ToInt32(txtCodigo.Text);
                oTarea.Materia = txtNombreMateria.Text;
                oTarea.Nombre = txtNombreTarea.Text;
                oTarea.Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false;
                oTarea.cTarea = rTBTarea.Text;

                oConexion.AgregarTarea(oTarea);
                Limpiar();
            }
            catch(Exception ex)
            {
                if(ex.GetType() == typeof(FormatException))
                {
                    MessageBox.Show("El código de la tarea debe ser númerico.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ex.GetType() == typeof(OverflowException))
                {
                    MessageBox.Show("El código de la tarea es muy largo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(ex.ToString());
            }
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombreMateria.Text= "";
            txtNombreTarea.Text = "";
            cboEstado.SelectedIndex = 1;
            rTBTarea.Text = "";

        }

        private void AgregarTarea_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactiva" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto="Activa"});

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 1;

        }
    }
}
