namespace WindowsForm
{
    partial class Inicio
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
            personasButton = new Button();
            especialidadesButton = new Button();
            planesButton = new Button();
            cursosButton = new Button();
            Materiasbutton = new Button();
            Comisionesbutton = new Button();
            ReportesButton = new Button();
            SuspendLayout();
            // 
            // personasButton
            // 
            personasButton.Location = new Point(92, 12);
            personasButton.Name = "personasButton";
            personasButton.Size = new Size(224, 72);
            personasButton.TabIndex = 0;
            personasButton.Text = "Personas";
            personasButton.UseVisualStyleBackColor = true;
            personasButton.Click += personaButton_Click;
            // 
            // especialidadesButton
            // 
            especialidadesButton.Location = new Point(444, 12);
            especialidadesButton.Name = "especialidadesButton";
            especialidadesButton.Size = new Size(224, 72);
            especialidadesButton.TabIndex = 1;
            especialidadesButton.Text = "Especialidades";
            especialidadesButton.UseVisualStyleBackColor = true;
            especialidadesButton.Click += especialidadButton_Click;
            // 
            // planesButton
            // 
            planesButton.Location = new Point(92, 128);
            planesButton.Name = "planesButton";
            planesButton.Size = new Size(224, 72);
            planesButton.TabIndex = 2;
            planesButton.Text = "Planes";
            planesButton.UseVisualStyleBackColor = true;
            planesButton.Click += planesButton_Click;
            // 
            // cursosButton
            // 
            cursosButton.Location = new Point(92, 256);
            cursosButton.Name = "cursosButton";
            cursosButton.Size = new Size(224, 72);
            cursosButton.TabIndex = 3;
            cursosButton.Text = "Cursos";
            cursosButton.UseVisualStyleBackColor = true;
            cursosButton.Click += cursosButton_Click;
            // 
            // Materiasbutton
            // 
            Materiasbutton.Location = new Point(444, 128);
            Materiasbutton.Name = "Materiasbutton";
            Materiasbutton.Size = new Size(224, 72);
            Materiasbutton.TabIndex = 4;
            Materiasbutton.Text = "Materias";
            Materiasbutton.UseVisualStyleBackColor = true;
            Materiasbutton.Click += Materiasbutton_Click;
            // 
            // Comisionesbutton
            // 
            Comisionesbutton.Location = new Point(444, 256);
            Comisionesbutton.Name = "Comisionesbutton";
            Comisionesbutton.Size = new Size(224, 72);
            Comisionesbutton.TabIndex = 5;
            Comisionesbutton.Text = "Comisiones";
            Comisionesbutton.UseVisualStyleBackColor = true;
            Comisionesbutton.Click += Comisionesbutton_Click;
            // 
            // ReportesButton
            // 
            ReportesButton.BackColor = Color.DodgerBlue;
            ReportesButton.Location = new Point(268, 350);
            ReportesButton.Name = "ReportesButton";
            ReportesButton.Size = new Size(224, 72);
            ReportesButton.TabIndex = 6;
            ReportesButton.Text = "Reportes";
            ReportesButton.UseVisualStyleBackColor = false;
            ReportesButton.Click += reportesButton_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ReportesButton);
            Controls.Add(Comisionesbutton);
            Controls.Add(Materiasbutton);
            Controls.Add(cursosButton);
            Controls.Add(planesButton);
            Controls.Add(especialidadesButton);
            Controls.Add(personasButton);
            Name = "Inicio";
            Text = "Inicio";
            ResumeLayout(false);
        }

        #endregion

        private Button personasButton;
        private Button especialidadesButton;
        private Button planesButton;
        private Button cursosButton;
        private Button Materiasbutton;
        private Button Comisionesbutton;
        private Button ReportesButton;
    }
}
