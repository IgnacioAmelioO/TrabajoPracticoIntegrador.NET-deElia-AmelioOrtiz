namespace WindowsForm
{
    partial class PlanesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelIdPlan;
        private System.Windows.Forms.TextBox textBoxIdPlan;
        private System.Windows.Forms.Label labelDescPlan;
        private System.Windows.Forms.TextBox textBoxDescPlan;
        private System.Windows.Forms.Label labelEspecialidad;
        private System.Windows.Forms.ComboBox comboBoxEspecialidad;
        private System.Windows.Forms.Button buttonCrear;
        private System.Windows.Forms.Button buttonCancelar;

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
            this.labelIdPlan = new System.Windows.Forms.Label();
            this.textBoxIdPlan = new System.Windows.Forms.TextBox();
            this.labelDescPlan = new System.Windows.Forms.Label();
            this.textBoxDescPlan = new System.Windows.Forms.TextBox();
            this.labelEspecialidad = new System.Windows.Forms.Label();
            this.comboBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIdPlan
            // 
            this.labelIdPlan.AutoSize = true;
            this.labelIdPlan.Location = new System.Drawing.Point(30, 25);
            this.labelIdPlan.Name = "labelIdPlan";
            this.labelIdPlan.Size = new System.Drawing.Size(49, 15);
            this.labelIdPlan.TabIndex = 0;
            this.labelIdPlan.Text = "ID Plan:";
            // 
            // textBoxIdPlan
            // 
            this.textBoxIdPlan.Location = new System.Drawing.Point(120, 22);
            this.textBoxIdPlan.Name = "textBoxIdPlan";
            this.textBoxIdPlan.ReadOnly = true;
            this.textBoxIdPlan.Size = new System.Drawing.Size(100, 23);
            this.textBoxIdPlan.TabIndex = 1;
            // 
            // labelDescPlan
            // 
            this.labelDescPlan.AutoSize = true;
            this.labelDescPlan.Location = new System.Drawing.Point(30, 65);
            this.labelDescPlan.Name = "labelDescPlan";
            this.labelDescPlan.Size = new System.Drawing.Size(72, 15);
            this.labelDescPlan.TabIndex = 2;
            this.labelDescPlan.Text = "Descripción:";
            // 
            // textBoxDescPlan
            // 
            this.textBoxDescPlan.Location = new System.Drawing.Point(120, 62);
            this.textBoxDescPlan.Name = "textBoxDescPlan";
            this.textBoxDescPlan.Size = new System.Drawing.Size(200, 23);
            this.textBoxDescPlan.TabIndex = 3;
            // 
            // labelEspecialidad
            // 
            this.labelEspecialidad.AutoSize = true;
            this.labelEspecialidad.Location = new System.Drawing.Point(30, 105);
            this.labelEspecialidad.Name = "labelEspecialidad";
            this.labelEspecialidad.Size = new System.Drawing.Size(80, 15);
            this.labelEspecialidad.TabIndex = 4;
            this.labelEspecialidad.Text = "Especialidad:";
            // 
            // comboBoxEspecialidad
            // 
            this.comboBoxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEspecialidad.FormattingEnabled = true;
            this.comboBoxEspecialidad.Location = new System.Drawing.Point(120, 102);
            this.comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            this.comboBoxEspecialidad.Size = new System.Drawing.Size(200, 23);
            this.comboBoxEspecialidad.TabIndex = 5;
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(120, 150);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(90, 30);
            this.buttonCrear.TabIndex = 6;
            this.buttonCrear.Text = "Crear";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(230, 150);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(90, 30);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // PlanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 210);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.comboBoxEspecialidad);
            this.Controls.Add(this.labelEspecialidad);
            this.Controls.Add(this.textBoxDescPlan);
            this.Controls.Add(this.labelDescPlan);
            this.Controls.Add(this.textBoxIdPlan);
            this.Controls.Add(this.labelIdPlan);
            this.Name = "PlanesForm";
            this.Text = "Gestión de Planes";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}