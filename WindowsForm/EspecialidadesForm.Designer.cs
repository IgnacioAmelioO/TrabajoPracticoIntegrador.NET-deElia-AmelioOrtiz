namespace WindowsForms
{
    partial class EspecialidadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxID_especialidad = new TextBox();
            textBoxDesc_especialidad = new TextBox();
            LabelId = new Label();
            labelDesc_especialidad = new Label();
            buttonGuardar = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // textBoxID_especialidad
            // 
            textBoxID_especialidad.Location = new Point(150, 30);
            textBoxID_especialidad.Name = "textBoxID_especialidad";
            textBoxID_especialidad.ReadOnly = true;
            textBoxID_especialidad.Size = new Size(100, 23);
            textBoxID_especialidad.TabIndex = 23;
            // 
            // textBoxDesc_especialidad
            // 
            textBoxDesc_especialidad.Location = new Point(150, 70);
            textBoxDesc_especialidad.Name = "textBoxDesc_especialidad";
            textBoxDesc_especialidad.Size = new Size(200, 23);
            textBoxDesc_especialidad.TabIndex = 1;
            // 
            // LabelId
            // 
            LabelId.AutoSize = true;
            LabelId.Location = new Point(30, 33);
            LabelId.Name = "LabelId";
            LabelId.Size = new Size(18, 15);
            LabelId.TabIndex = 2;
            LabelId.Text = "ID";
            // 
            // labelDesc_especialidad
            // 
            labelDesc_especialidad.AutoSize = true;
            labelDesc_especialidad.Location = new Point(30, 73);
            labelDesc_especialidad.Name = "labelDesc_especialidad";
            labelDesc_especialidad.Size = new Size(69, 15);
            labelDesc_especialidad.TabIndex = 3;
            labelDesc_especialidad.Text = "Descripción";
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(150, 128);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(100, 30);
            buttonGuardar.TabIndex = 4;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(267, 128);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(100, 30);
            buttonCancelar.TabIndex = 5;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click_1;
            // 
            // EspecialidadForm
            // 
            ClientSize = new Size(400, 180);
            Controls.Add(textBoxID_especialidad);
            Controls.Add(textBoxDesc_especialidad);
            Controls.Add(LabelId);
            Controls.Add(labelDesc_especialidad);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonCancelar);
            Name = "EspecialidadForm";
            Text = "Formulario de Especialidad";
            ResumeLayout(false);
            PerformLayout();
        }


        private TextBox textBoxID_especialidad;
        private TextBox textBoxDesc_especialidad;
        private Label LabelId;
        private Label labelDesc_especialidad;
        private Button buttonGuardar;
        private Button buttonCancelar;
    }
}