
namespace WindowsForms
{
    partial class ComisionesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxID_comision;
        private System.Windows.Forms.TextBox textBoxDesc_comision;
        private System.Windows.Forms.NumericUpDown numericUpDownAnio;
        private System.Windows.Forms.ComboBox comboBoxPlan;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

       
        private System.Windows.Forms.Label labelID_comision;
        private System.Windows.Forms.Label labelDesc_comision;
        private System.Windows.Forms.Label labelAnio_comision;
        private System.Windows.Forms.Label labelPlan_comision;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxID_comision = new System.Windows.Forms.TextBox();
            textBoxDesc_comision = new System.Windows.Forms.TextBox();
            numericUpDownAnio = new System.Windows.Forms.NumericUpDown();
            comboBoxPlan = new System.Windows.Forms.ComboBox();
            buttonGuardar = new System.Windows.Forms.Button();
            buttonCancelar = new System.Windows.Forms.Button();

            
            labelID_comision = new System.Windows.Forms.Label();
            labelDesc_comision = new System.Windows.Forms.Label();
            labelAnio_comision = new System.Windows.Forms.Label();
            labelPlan_comision = new System.Windows.Forms.Label();

            SuspendLayout();

            
            labelID_comision.Location = new System.Drawing.Point(20, 2);
            labelID_comision.Size = new System.Drawing.Size(60, 16);
            labelID_comision.Text = "ID";

            labelDesc_comision.Location = new System.Drawing.Point(100, 2);
            labelDesc_comision.Size = new System.Drawing.Size(220, 16);
            labelDesc_comision.Text = "Descripción";

            labelAnio_comision.Location = new System.Drawing.Point(20, 60);
            labelAnio_comision.Size = new System.Drawing.Size(80, 16);
            labelAnio_comision.Text = "Año";

            labelPlan_comision.Location = new System.Drawing.Point(20, 100);
            labelPlan_comision.Size = new System.Drawing.Size(80, 16);
            labelPlan_comision.Text = "Plan";

            
            textBoxID_comision.Location = new System.Drawing.Point(20, 20);
            textBoxID_comision.Size = new System.Drawing.Size(60, 23);
            textBoxID_comision.ReadOnly = true;

            textBoxDesc_comision.Location = new System.Drawing.Point(100, 20);
            textBoxDesc_comision.Size = new System.Drawing.Size(220, 23);

            numericUpDownAnio.Location = new System.Drawing.Point(100, 60);
            numericUpDownAnio.Size = new System.Drawing.Size(80, 23);
            numericUpDownAnio.Minimum = 1;
            numericUpDownAnio.Maximum = 9999;
            numericUpDownAnio.Value = 1;

            comboBoxPlan.Location = new System.Drawing.Point(100, 100);
            comboBoxPlan.Size = new System.Drawing.Size(220, 23);
            comboBoxPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            buttonGuardar.Text = "Guardar";
            buttonGuardar.Location = new System.Drawing.Point(100, 140);
            buttonGuardar.Click += buttonGuardar_Click;

            buttonCancelar.Text = "Cancelar";
            buttonCancelar.Location = new System.Drawing.Point(220, 140);
            buttonCancelar.Click += buttonCancelar_Click;

           
            Controls.Add(labelID_comision);
            Controls.Add(labelDesc_comision);
            Controls.Add(labelAnio_comision);
            Controls.Add(labelPlan_comision);

            Controls.Add(textBoxID_comision);
            Controls.Add(textBoxDesc_comision);
            Controls.Add(numericUpDownAnio);
            Controls.Add(comboBoxPlan);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonCancelar);

            ClientSize = new System.Drawing.Size(350, 200);
            Text = "Comisión";
            ResumeLayout(false);
        }
    }
}