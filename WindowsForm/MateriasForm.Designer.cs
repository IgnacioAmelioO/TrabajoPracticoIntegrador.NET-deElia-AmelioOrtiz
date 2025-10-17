namespace WindowsForms
{
    partial class MateriasForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxID_materia;
        private System.Windows.Forms.TextBox textBoxDesc_materia;
        private System.Windows.Forms.NumericUpDown numericUpDownHsSem;
        private System.Windows.Forms.NumericUpDown numericUpDownHsTot;
        private System.Windows.Forms.ComboBox comboBoxPlan;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

        // Labels añadidos
        private System.Windows.Forms.Label labelID_materia;
        private System.Windows.Forms.Label labelDesc_materia;
        private System.Windows.Forms.Label labelHsSem_materia;
        private System.Windows.Forms.Label labelHsTot_materia;
        private System.Windows.Forms.Label labelPlan_materia;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxID_materia = new System.Windows.Forms.TextBox();
            textBoxDesc_materia = new System.Windows.Forms.TextBox();
            numericUpDownHsSem = new System.Windows.Forms.NumericUpDown();
            numericUpDownHsTot = new System.Windows.Forms.NumericUpDown();
            comboBoxPlan = new System.Windows.Forms.ComboBox();
            buttonGuardar = new System.Windows.Forms.Button();
            buttonCancelar = new System.Windows.Forms.Button();

            // Inicializar labels
            labelID_materia = new System.Windows.Forms.Label();
            labelDesc_materia = new System.Windows.Forms.Label();
            labelHsSem_materia = new System.Windows.Forms.Label();
            labelHsTot_materia = new System.Windows.Forms.Label();
            labelPlan_materia = new System.Windows.Forms.Label();

            SuspendLayout();

            // Labels - posición y texto
            labelID_materia.Location = new System.Drawing.Point(20, 2);
            labelID_materia.Size = new System.Drawing.Size(60, 16);
            labelID_materia.Text = "ID";

            labelDesc_materia.Location = new System.Drawing.Point(100, 2);
            labelDesc_materia.Size = new System.Drawing.Size(220, 16);
            labelDesc_materia.Text = "Descripción";

            labelHsSem_materia.Location = new System.Drawing.Point(20, 60);
            labelHsSem_materia.Size = new System.Drawing.Size(80, 16);
            labelHsSem_materia.Text = "Hs/Sem";

            labelHsTot_materia.Location = new System.Drawing.Point(20, 100);
            labelHsTot_materia.Size = new System.Drawing.Size(80, 16);
            labelHsTot_materia.Text = "Hs/Total";

            labelPlan_materia.Location = new System.Drawing.Point(20, 140);
            labelPlan_materia.Size = new System.Drawing.Size(80, 16);
            labelPlan_materia.Text = "Plan";

            // Controles existentes
            textBoxID_materia.Location = new System.Drawing.Point(20, 20);
            textBoxID_materia.Size = new System.Drawing.Size(60, 23);
            textBoxID_materia.ReadOnly = true;

            textBoxDesc_materia.Location = new System.Drawing.Point(100, 20);
            textBoxDesc_materia.Size = new System.Drawing.Size(220, 23);

            numericUpDownHsSem.Location = new System.Drawing.Point(100, 60);
            numericUpDownHsSem.Size = new System.Drawing.Size(80, 23);
            numericUpDownHsSem.Minimum = 0;
            numericUpDownHsSem.Maximum = 1000;
            numericUpDownHsSem.Value = 1;

            numericUpDownHsTot.Location = new System.Drawing.Point(100, 100);
            numericUpDownHsTot.Size = new System.Drawing.Size(80, 23);
            numericUpDownHsTot.Minimum = 0;
            numericUpDownHsTot.Maximum = 10000;
            numericUpDownHsTot.Value = 1;

            comboBoxPlan.Location = new System.Drawing.Point(100, 140);
            comboBoxPlan.Size = new System.Drawing.Size(220, 23);
            comboBoxPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            buttonGuardar.Text = "Guardar";
            buttonGuardar.Location = new System.Drawing.Point(100, 180);
            buttonGuardar.Click += buttonGuardar_Click;

            buttonCancelar.Text = "Cancelar";
            buttonCancelar.Location = new System.Drawing.Point(220, 180);
            buttonCancelar.Click += buttonCancelar_Click;

            // Añadir labels y controles al formulario (orden lógico)
            Controls.Add(labelID_materia);
            Controls.Add(labelDesc_materia);
            Controls.Add(labelHsSem_materia);
            Controls.Add(labelHsTot_materia);
            Controls.Add(labelPlan_materia);

            Controls.Add(textBoxID_materia);
            Controls.Add(textBoxDesc_materia);
            Controls.Add(numericUpDownHsSem);
            Controls.Add(numericUpDownHsTot);
            Controls.Add(comboBoxPlan);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonCancelar);

            ClientSize = new System.Drawing.Size(350, 230);
            Text = "Materia";
            ResumeLayout(false);
        }
    }
}