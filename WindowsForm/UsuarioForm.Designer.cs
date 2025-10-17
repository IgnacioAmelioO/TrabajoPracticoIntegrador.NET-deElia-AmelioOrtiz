namespace WindowsForm
{
    partial class UsuarioForm
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
            labelPersonaInfo = new Label();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            buttonCrear = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // labelPersonaInfo
            // 
            labelPersonaInfo.AutoSize = true;
            labelPersonaInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPersonaInfo.Location = new Point(12, 9);
            labelPersonaInfo.Name = "labelPersonaInfo";
            labelPersonaInfo.Size = new Size(148, 15);
            labelPersonaInfo.TabIndex = 0;
            labelPersonaInfo.Text = "Crear usuario para: [INFO]";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(12, 48);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(109, 15);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Nombre de usuario:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(12, 66);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(339, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(12, 101);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 15);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(12, 119);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(339, 23);
            textBoxPassword.TabIndex = 2;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Location = new Point(12, 154);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(127, 15);
            labelConfirmPassword.TabIndex = 5;
            labelConfirmPassword.Text = "Confirmar contraseña:";
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(12, 172);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new Size(339, 23);
            textBoxConfirmPassword.TabIndex = 3;
            // 
            // buttonCrear
            // 
            buttonCrear.Location = new Point(195, 217);
            buttonCrear.Name = "buttonCrear";
            buttonCrear.Size = new Size(75, 23);
            buttonCrear.TabIndex = 4;
            buttonCrear.Text = "Crear";
            buttonCrear.UseVisualStyleBackColor = true;
            buttonCrear.Click += buttonCrear_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(276, 217);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 23);
            buttonCancelar.TabIndex = 5;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // UsuarioForm
            // 
            AcceptButton = buttonCrear;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancelar;
            ClientSize = new Size(363, 252);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonCrear);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(labelConfirmPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Controls.Add(labelPersonaInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UsuarioForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Crear Usuario";
            Load += UsuarioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPersonaInfo;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonCrear;
        private Button buttonCancelar;
    }
}