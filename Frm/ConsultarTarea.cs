using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTareas
{
    public partial class ConsultarTarea : Form
    {
        private int selectedRowIndex = -1;
        public ConsultarTarea()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBusqueda.Text == "")
            {
                MessageBox.Show("La caja de texto está vacia, es necesario ingresar el dato correspondiente.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Limpiar();
            string columaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvTareas.Rows.Count > 0)
                foreach(DataGridViewRow row in dgvTareas.Rows)
                    if (row.Cells[columaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;

            lblListANDResults.Text = "Resultados de la busqueda:";
            btnLimpiar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            foreach(DataGridViewRow row in dgvTareas.Rows)
                row.Visible = true;

            lblListANDResults.Text = "Lista de tareas:";
            btnLimpiar.Enabled = false;
            cboBusqueda.SelectedIndex = 0;
            Limpiar();
        }


        private void dgvTareas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == selectedRowIndex && e.ColumnIndex >= 0) && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.selected.Width;
                    var h = Properties.Resources.selected.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    e.Graphics.DrawImage(Properties.Resources.selected, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }
                    
            }
        }
        
        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                dgvTareas.Invalidate();

                txtCodigo.Text = dgvTareas.Rows[selectedRowIndex].Cells["Codigo"].Value.ToString();
                txtMateria.Text = dgvTareas.Rows[selectedRowIndex].Cells["Materia"].Value.ToString();
                txtNombre.Text = dgvTareas.Rows[selectedRowIndex].Cells["Nombre"].Value.ToString();
                txtEstado.Text = dgvTareas.Rows[selectedRowIndex].Cells["Estado"].Value.ToString();
                txtFecha.Text = dgvTareas.Rows[selectedRowIndex].Cells["Fecha"].Value.ToString();
                rTBTarea.Text = dgvTareas.Rows[selectedRowIndex].Cells["Tarea"].Value.ToString();
            }   
        }

        public void CargarDatos()
        {
            List<Tarea> datos = new List<Tarea>();
            Conexion conexion = new Conexion();

            datos = conexion.listarTareas();
            foreach (Tarea obj in datos)
            {
                dgvTareas.Rows.Add(new object[] { "", obj.Codigo, obj.Materia, obj.Nombre,
                obj.Estado == true ? 1 : 0, obj.Estado == true ? "Activa" : "Inactiva", obj.Fecha , obj.cTarea});
            }
        }

        private void ConsultarTarea_Load(object sender, EventArgs e)
        {
            foreach(DataGridViewColumn columna in dgvTareas.Columns)
            {
                if(columna.Visible == true && columna.Name != "btn")
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor=columna.Name , Texto=columna.HeaderText});
            }

            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtMateria.Text = "";
            txtNombre.Text = "";
            txtEstado.Text = "";
            txtFecha.Text = "";
            rTBTarea.Text = "";

            selectedRowIndex = -1;

        }
    }
}
