namespace WindowsForms
{
    partial class ComisionesLista
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvComisiones = new System.Windows.Forms.DataGridView();
            btnNuevo = new System.Windows.Forms.Button();
            btnEditar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            btnRefrescar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();

            SuspendLayout();

            dgvComisiones.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
            dgvComisiones.Location = new System.Drawing.Point(12, 12);
            dgvComisiones.Size = new System.Drawing.Size(760, 320);
            dgvComisiones.ReadOnly = true;
            dgvComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvComisiones.AutoGenerateColumns = true;

            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new System.Drawing.Point(12, 350);
            btnNuevo.Click += btnNuevo_Click;

            btnEditar.Text = "Editar";
            btnEditar.Location = new System.Drawing.Point(112, 350);
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new System.Drawing.Point(212, 350);
            btnEliminar.Click += btnEliminar_Click;

            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Location = new System.Drawing.Point(312, 350);
            btnRefrescar.Click += btnRefrescar_Click;

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new System.Drawing.Point(412, 350);
            btnCerrar.Click += btnCerrar_Click;

            Controls.Add(dgvComisiones);
            Controls.Add(btnNuevo);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnRefrescar);
            Controls.Add(btnCerrar);

            ClientSize = new System.Drawing.Size(784, 401);
            Text = "Comisiones";
            ResumeLayout(false);
        }
    }
}