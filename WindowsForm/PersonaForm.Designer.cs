namespace WindowsForms
{
    partial class PersonaForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxDireccion = new TextBox();
            textBoxEmail = new TextBox();
            labelNombre = new Label();
            labelApellido = new Label();
            labelEmail = new Label();
            labelDireccion = new Label();
            labelTelefono = new Label();
            labelLegajo = new Label();
            labelPlan = new Label();
            labelFecha_nacimiento = new Label();
            labelTipo_persona = new Label();
            textBoxTelefono = new TextBox();
            textBoxLegajo = new TextBox();
            comboBoxTipo_persona = new ComboBox();
            comboBoxId_plan = new ComboBox();
            buttonCrear = new Button();
            dateTimePickerFecha_nacimiento = new DateTimePicker();
            cancelarButton = new Button();
            label1 = new Label();
            textBoxId_persona = new TextBox();
            SuspendLayout();
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(312, 115);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(204, 23);
            textBoxNombre.TabIndex = 1;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(312, 158);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(204, 23);
            textBoxApellido.TabIndex = 2;
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.Location = new Point(312, 201);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(204, 23);
            textBoxDireccion.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(312, 239);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(204, 23);
            textBoxEmail.TabIndex = 4;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(157, 118);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 5;
            labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Location = new Point(157, 166);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(51, 15);
            labelApellido.TabIndex = 6;
            labelApellido.Text = "Apellido";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(157, 247);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 7;
            labelEmail.Text = "Email";
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Location = new Point(157, 201);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(57, 15);
            labelDireccion.TabIndex = 9;
            labelDireccion.Text = "Direccion";
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Location = new Point(157, 292);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(53, 15);
            labelTelefono.TabIndex = 10;
            labelTelefono.Text = "Telefono";
            // 
            // labelLegajo
            // 
            labelLegajo.AutoSize = true;
            labelLegajo.Location = new Point(157, 385);
            labelLegajo.Name = "labelLegajo";
            labelLegajo.Size = new Size(42, 15);
            labelLegajo.TabIndex = 11;
            labelLegajo.Text = "Legajo";
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Location = new Point(162, 482);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(30, 15);
            labelPlan.TabIndex = 12;
            labelPlan.Text = "Plan";
            // 
            // labelFecha_nacimiento
            // 
            labelFecha_nacimiento.AutoSize = true;
            labelFecha_nacimiento.Location = new Point(157, 338);
            labelFecha_nacimiento.Name = "labelFecha_nacimiento";
            labelFecha_nacimiento.Size = new Size(117, 15);
            labelFecha_nacimiento.TabIndex = 13;
            labelFecha_nacimiento.Text = "Fecha de nacimiento";
            // 
            // labelTipo_persona
            // 
            labelTipo_persona.AutoSize = true;
            labelTipo_persona.Location = new Point(157, 437);
            labelTipo_persona.Name = "labelTipo_persona";
            labelTipo_persona.Size = new Size(92, 15);
            labelTipo_persona.TabIndex = 14;
            labelTipo_persona.Text = "Tipo de persona";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(312, 284);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(204, 23);
            textBoxTelefono.TabIndex = 15;
            // 
            // textBoxLegajo
            // 
            textBoxLegajo.Location = new Point(312, 382);
            textBoxLegajo.Name = "textBoxLegajo";
            textBoxLegajo.ReadOnly = true;
            textBoxLegajo.Size = new Size(204, 23);
            textBoxLegajo.TabIndex = 17;
            // 
            // comboBoxTipo_persona
            // 
            comboBoxTipo_persona.FormattingEnabled = true;
            comboBoxTipo_persona.Location = new Point(312, 434);
            comboBoxTipo_persona.Name = "comboBoxTipo_persona";
            comboBoxTipo_persona.Size = new Size(121, 23);
            comboBoxTipo_persona.TabIndex = 18;
            // 
            // comboBoxId_plan
            // 
            comboBoxId_plan.FormattingEnabled = true;
            comboBoxId_plan.Location = new Point(312, 474);
            comboBoxId_plan.Name = "comboBoxId_plan";
            comboBoxId_plan.Size = new Size(121, 23);
            comboBoxId_plan.TabIndex = 19;
            // 
            // buttonCrear
            // 
            buttonCrear.Location = new Point(577, 532);
            buttonCrear.Name = "buttonCrear";
            buttonCrear.Size = new Size(75, 23);
            buttonCrear.TabIndex = 20;
            buttonCrear.Text = "Crear";
            buttonCrear.UseVisualStyleBackColor = true;
            buttonCrear.Click += button1_Click;
            // 
            // dateTimePickerFecha_nacimiento
            // 
            dateTimePickerFecha_nacimiento.Location = new Point(312, 332);
            dateTimePickerFecha_nacimiento.Name = "dateTimePickerFecha_nacimiento";
            dateTimePickerFecha_nacimiento.Size = new Size(200, 23);
            dateTimePickerFecha_nacimiento.TabIndex = 16;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(673, 532);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 21;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += canelarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 82);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 22;
            label1.Text = "ID";
            // 
            // textBoxId_persona
            // 
            textBoxId_persona.Location = new Point(312, 74);
            textBoxId_persona.Name = "textBoxId_persona";
            textBoxId_persona.ReadOnly = true;
            textBoxId_persona.Size = new Size(200, 23);
            textBoxId_persona.TabIndex = 23;
            // 
            // PersonaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 584);
            Controls.Add(textBoxId_persona);
            Controls.Add(label1);
            Controls.Add(cancelarButton);
            Controls.Add(buttonCrear);
            Controls.Add(comboBoxId_plan);
            Controls.Add(comboBoxTipo_persona);
            Controls.Add(textBoxLegajo);
            Controls.Add(dateTimePickerFecha_nacimiento);
            Controls.Add(textBoxTelefono);
            Controls.Add(labelTipo_persona);
            Controls.Add(labelFecha_nacimiento);
            Controls.Add(labelPlan);
            Controls.Add(labelLegajo);
            Controls.Add(labelTelefono);
            Controls.Add(labelDireccion);
            Controls.Add(labelEmail);
            Controls.Add(labelApellido);
            Controls.Add(labelNombre);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxDireccion);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Name = "PersonaForm";
            Text = "PersonaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxDireccion;
        private TextBox textBoxEmail;
        private Label labelNombre;
        private Label labelApellido;
        private Label labelEmail;
        private Label labelDireccion;
        private Label labelTelefono;
        private Label labelLegajo;
        private Label labelPlan;
        private Label labelFecha_nacimiento;
        private Label labelTipo_persona;
        private TextBox textBoxTelefono;
        private TextBox textBoxLegajo;
        private ComboBox comboBoxTipo_persona;
        private ComboBox comboBoxId_plan;
        private Button buttonCrear;
        private DateTimePicker dateTimePickerFecha_nacimiento;
        private Button cancelarButton;
        private Label label1;
        private TextBox textBoxId_persona;
    }
}