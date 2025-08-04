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
            SuspendLayout();
            // 
            // personasButton
            // 
            personasButton.Location = new Point(87, 168);
            personasButton.Name = "personasButton";
            personasButton.Size = new Size(224, 72);
            personasButton.TabIndex = 0;
            personasButton.Text = "Personas";
            personasButton.UseVisualStyleBackColor = true;
            personasButton.Click += personaButton_Click;
            // 
            // especialidadesButton
            // 
            especialidadesButton.Location = new Point(460, 168);
            especialidadesButton.Name = "especialidadesButton";
            especialidadesButton.Size = new Size(224, 72);
            especialidadesButton.TabIndex = 1;
            especialidadesButton.Text = "Especialidades";
            especialidadesButton.UseVisualStyleBackColor = true;
            especialidadesButton.Click += especialidadButton_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(especialidadesButton);
            Controls.Add(personasButton);
            Name = "Inicio";
            Text = "Inicio";
            ResumeLayout(false);
        }

        #endregion

        private Button personasButton;
        private Button especialidadesButton;
    }
}
