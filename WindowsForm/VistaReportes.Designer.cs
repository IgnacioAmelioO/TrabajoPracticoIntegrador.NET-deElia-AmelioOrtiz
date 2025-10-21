namespace WindowsForm
{
    partial class VistaReportes
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
            NotaPromCursoButton = new Button();
            SuspendLayout();
            // 
            // NotaPromCursoButton
            // 
            NotaPromCursoButton.Location = new Point(66, 56);
            NotaPromCursoButton.Name = "NotaPromCursoButton";
            NotaPromCursoButton.Size = new Size(249, 66);
            NotaPromCursoButton.TabIndex = 0;
            NotaPromCursoButton.Text = "Nota promedio curso";
            NotaPromCursoButton.UseVisualStyleBackColor = true;
            NotaPromCursoButton.Click += notaPromCursoButton_Click;
            // 
            // VistaReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NotaPromCursoButton);
            Name = "VistaReportes";
            Text = "VistaReportes";
            ResumeLayout(false);
        }

        #endregion

        private Button NotaPromCursoButton;
    }
}