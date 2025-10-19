       namespace WindowsForm
{
    partial class VistaAlumno
    {
       
        private System.ComponentModel.IContainer components = null;

       
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador


        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblWelcome = new Label();
            btnRefrescar = new Button();
            btnInscribirse = new Button();
            inscripcionesGrid = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inscripcionesGrid).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTop.Controls.Add(lblWelcome);
            panelTop.Controls.Add(btnRefrescar);
            panelTop.Controls.Add(btnInscribirse);
            panelTop.Location = new Point(12, 12);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(760, 40);
            panelTop.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Left;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.Location = new Point(6, 10);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(130, 19);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bienvenido, Usuario";
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefrescar.Location = new Point(225, 9);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(75, 28);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // btnInscribirse
            // 
            btnInscribirse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInscribirse.Location = new Point(375, 9);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(180, 28);
            btnInscribirse.TabIndex = 2;
            btnInscribirse.Text = "Inscribirse a un nuevo curso";
            btnInscribirse.UseVisualStyleBackColor = true;
            btnInscribirse.Click += btnInscribirse_Click;
            // 
            // inscripcionesGrid
            // 
            inscripcionesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inscripcionesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inscripcionesGrid.Location = new Point(12, 58);
            inscripcionesGrid.MultiSelect = false;
            inscripcionesGrid.Name = "inscripcionesGrid";
            inscripcionesGrid.ReadOnly = true;
            inscripcionesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inscripcionesGrid.Size = new Size(555, 380);
            inscripcionesGrid.TabIndex = 3;
            // 
            // VistaAlumno
            // 
            ClientSize = new Size(784, 450);
            Controls.Add(inscripcionesGrid);
            Controls.Add(panelTop);
            Name = "VistaAlumno";
            Text = "Mis inscripciones";
            Load += VistaAlumno_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inscripcionesGrid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.DataGridView inscripcionesGrid;
    }
}