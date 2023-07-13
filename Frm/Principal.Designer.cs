namespace GestionTareas
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.agregarTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarTareaToolStripMenuItem,
            this.eliminarTareaToolStripMenuItem,
            this.modificarTareaToolStripMenuItem,
            this.consultarTareaToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // agregarTareaToolStripMenuItem
            // 
            this.agregarTareaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarTareaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.agregarTareaToolStripMenuItem.Name = "agregarTareaToolStripMenuItem";
            this.agregarTareaToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.agregarTareaToolStripMenuItem.Text = "Agregar Tarea";
            this.agregarTareaToolStripMenuItem.Click += new System.EventHandler(this.agregarTareaToolStripMenuItem_Click);
            // 
            // eliminarTareaToolStripMenuItem
            // 
            this.eliminarTareaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarTareaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eliminarTareaToolStripMenuItem.Name = "eliminarTareaToolStripMenuItem";
            this.eliminarTareaToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.eliminarTareaToolStripMenuItem.Text = "Eliminar Tarea";
            this.eliminarTareaToolStripMenuItem.Click += new System.EventHandler(this.eliminarTareaToolStripMenuItem_Click);
            // 
            // modificarTareaToolStripMenuItem
            // 
            this.modificarTareaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarTareaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modificarTareaToolStripMenuItem.Name = "modificarTareaToolStripMenuItem";
            this.modificarTareaToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.modificarTareaToolStripMenuItem.Text = "Modificar Tarea";
            this.modificarTareaToolStripMenuItem.Click += new System.EventHandler(this.modificarTareaToolStripMenuItem_Click);
            // 
            // consultarTareaToolStripMenuItem
            // 
            this.consultarTareaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultarTareaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.consultarTareaToolStripMenuItem.Name = "consultarTareaToolStripMenuItem";
            this.consultarTareaToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.consultarTareaToolStripMenuItem.Text = "Consultar Tarea";
            this.consultarTareaToolStripMenuItem.Click += new System.EventHandler(this.consultarTareaToolStripMenuItem_Click);
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.SteelBlue;
            this.contenedor.Controls.Add(this.label3);
            this.contenedor.Controls.Add(this.label1);
            this.contenedor.Controls.Add(this.label2);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor.Location = new System.Drawing.Point(0, 24);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(800, 426);
            this.contenedor.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Versión: Sistema de Gestion de Tareas V 1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Atajos:\r\nCtr + Rueda del Mouse (En la cajas de texto de Tareas): Permite hacer la" +
    "s letras más chicas o agrandarlas.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(510, 65);
            this.label2.TabIndex = 2;
            this.label2.Text = "Este es un programa de gestion de tareas, con el objetivo de llevar un control de" +
    " tareas.\r\n\r\nRealizado por: Leoncio Martinez\r\n\r\nFecha: 17 / 06 / 23\r\n";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestion de Tareas";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem agregarTareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarTareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarTareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarTareaToolStripMenuItem;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

