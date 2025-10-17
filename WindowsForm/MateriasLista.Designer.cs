namespace WindowsForms
{
    partial class MateriasLista
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMaterias;
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
            dgvMaterias = new System.Windows.Forms.DataGridView();
            btnNuevo = new System.Windows.Forms.Button();
            btnEditar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            btnRefrescar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();

            SuspendLayout();

            dgvMaterias.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
            dgvMaterias.Location = new System.Drawing.Point(12, 12);
            dgvMaterias.Size = new System.Drawing.Size(860, 340);
            dgvMaterias.ReadOnly = true;
            dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.AutoGenerateColumns = true;

            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new System.Drawing.Point(12, 370);
            btnNuevo.Click += btnNuevo_Click;

            btnEditar.Text = "Editar";
            btnEditar.Location = new System.Drawing.Point(112, 370);
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new System.Drawing.Point(212, 370);
            btnEliminar.Click += btnEliminar_Click;

            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Location = new System.Drawing.Point(312, 370);
            btnRefrescar.Click += btnRefrescar_Click;

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new System.Drawing.Point(412, 370);
            btnCerrar.Click += btnCerrar_Click;

            Controls.Add(dgvMaterias);
            Controls.Add(btnNuevo);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnRefrescar);
            Controls.Add(btnCerrar);

            ClientSize = new System.Drawing.Size(884, 421);
            Text = "Materias";
            ResumeLayout(false);
        }
    }
}