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
    public partial class Principal : Form
    {
        ToolStripMenuItem menuActivo = null;
        Form formActivo = null;

        public Principal()
        {
            InitializeComponent();
           
        }

        //Funcion para Abrir el formulario, se le pasa como parametro el elemento del menu strip seleccionado y el formulario que se va a abrir.
        private void AbrirFormulario(ToolStripMenuItem menu, Form formulario)
        {
            label2.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            //Si el menu se deselecciono un ItemMenu previamente seleccionado, pintar a azul.
            if(menuActivo != null){
                menuActivo.BackColor = Color.DeepSkyBlue;
                menuActivo.ForeColor = Color.White;
            }

            //Pintar el menu seleccionado a azul bajito y ponerlo como activo
            menu.BackColor = Color.Black;
            menu.ForeColor = Color.Aqua;
            menuActivo = menu;

            //Si se abrió otra Ventana(otro menu) y habia otra previamente abierta, cerrar la anterior.
            if(formActivo != null){
                formActivo.Close();
            }


            //Ajustando propiedades de la ventana para mostrarla en la principal
            formActivo = formulario;//<- Para saber cual formulario es el activo 
            formulario.TopLevel = false;// <- Para indicar que es una ventana secundaria
            formulario.FormBorderStyle = FormBorderStyle.None; //<- Quitarle los bordes y botones
            formulario.Dock = DockStyle.Fill;//<- Para que se rellene por completo

            contenedor.Controls.Add(formulario);//<- Acoplando el formulario secundario en el principal
            formulario.Show();//<- Mostrando el formulario

        }

        //Casos de click en el MenuStrip
        private void agregarTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sender != menuActivo)
                AbrirFormulario((ToolStripMenuItem)sender,new AgregarTarea());
        }

        private void eliminarTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender != menuActivo)
                AbrirFormulario((ToolStripMenuItem)sender, new EliminarTarea());
        }

        private void modificarTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender != menuActivo)
                AbrirFormulario((ToolStripMenuItem)sender, new ModificarTarea());
        }

        private void consultarTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender != menuActivo)
                AbrirFormulario((ToolStripMenuItem)sender, new ConsultarTarea());
        }


    }
}
