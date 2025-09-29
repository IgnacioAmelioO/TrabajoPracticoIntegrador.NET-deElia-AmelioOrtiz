namespace WindowsForm
{
    partial class CursosForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelIdCurso;
        private System.Windows.Forms.TextBox textBoxIdCurso;
        private System.Windows.Forms.Label labelAnio;
        private System.Windows.Forms.TextBox textBoxAnio;
        private System.Windows.Forms.Label labelCupo;
        private System.Windows.Forms.TextBox textBoxCupo;
        private System.Windows.Forms.Label labelMateria;
        private System.Windows.Forms.ComboBox comboBoxMateria;
        private System.Windows.Forms.Label labelComision;
        private System.Windows.Forms.ComboBox comboBoxComision;
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
            this.labelIdCurso = new System.Windows.Forms.Label();
            this.textBoxIdCurso = new System.Windows.Forms.TextBox();
            this.labelAnio = new System.Windows.Forms.Label();
            this.textBoxAnio = new System.Windows.Forms.TextBox();
            this.labelCupo = new System.Windows.Forms.Label();
            this.textBoxCupo = new System.Windows.Forms.TextBox();
            this.labelMateria = new System.Windows.Forms.Label();
            this.comboBoxMateria = new System.Windows.Forms.ComboBox();
            this.labelComision = new System.Windows.Forms.Label();
            this.comboBoxComision = new System.Windows.Forms.ComboBox();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
           
            this.labelIdCurso.AutoSize = true;
            this.labelIdCurso.Location = new System.Drawing.Point(30, 25);
            this.labelIdCurso.Name = "labelIdCurso";
            this.labelIdCurso.Size = new System.Drawing.Size(56, 15);
            this.labelIdCurso.TabIndex = 0;
            this.labelIdCurso.Text = "ID Curso:";
            // 
            // textBoxIdCurso
            // 
            this.textBoxIdCurso.Location = new System.Drawing.Point(120, 22);
            this.textBoxIdCurso.Name = "textBoxIdCurso";
            this.textBoxIdCurso.ReadOnly = true;
            this.textBoxIdCurso.Size = new System.Drawing.Size(100, 23);
            this.textBoxIdCurso.TabIndex = 1;
            // 
            // labelAnio
            // 
            this.labelAnio.AutoSize = true;
            this.labelAnio.Location = new System.Drawing.Point(30, 65);
            this.labelAnio.Name = "labelAnio";
            this.labelAnio.Size = new System.Drawing.Size(84, 15);
            this.labelAnio.TabIndex = 2;
            this.labelAnio.Text = "Año calendario:";
            // 
            // textBoxAnio
            // 
            this.textBoxAnio.Location = new System.Drawing.Point(120, 62);
            this.textBoxAnio.Name = "textBoxAnio";
            this.textBoxAnio.Size = new System.Drawing.Size(100, 23);
            this.textBoxAnio.TabIndex = 3;
            // 
            // labelCupo
            // 
            this.labelCupo.AutoSize = true;
            this.labelCupo.Location = new System.Drawing.Point(30, 105);
            this.labelCupo.Name = "labelCupo";
            this.labelCupo.Size = new System.Drawing.Size(38, 15);
            this.labelCupo.TabIndex = 4;
            this.labelCupo.Text = "Cupo:";
            // 
            // textBoxCupo
            // 
            this.textBoxCupo.Location = new System.Drawing.Point(120, 102);
            this.textBoxCupo.Name = "textBoxCupo";
            this.textBoxCupo.Size = new System.Drawing.Size(100, 23);
            this.textBoxCupo.TabIndex = 5;
            // 
            // labelMateria
            // 
            this.labelMateria.AutoSize = true;
            this.labelMateria.Location = new System.Drawing.Point(30, 145);
            this.labelMateria.Name = "labelMateria";
            this.labelMateria.Size = new System.Drawing.Size(50, 15);
            this.labelMateria.TabIndex = 6;
            this.labelMateria.Text = "Materia:";
            // 
            // comboBoxMateria
            // 
            this.comboBoxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateria.FormattingEnabled = true;
            this.comboBoxMateria.Location = new System.Drawing.Point(120, 142);
            this.comboBoxMateria.Name = "comboBoxMateria";
            this.comboBoxMateria.Size = new System.Drawing.Size(200, 23);
            this.comboBoxMateria.TabIndex = 7;
            // 
            // labelComision
            // 
            this.labelComision.AutoSize = true;
            this.labelComision.Location = new System.Drawing.Point(30, 185);
            this.labelComision.Name = "labelComision";
            this.labelComision.Size = new System.Drawing.Size(59, 15);
            this.labelComision.TabIndex = 8;
            this.labelComision.Text = "Comisión:";
            // 
            // comboBoxComision
            // 
            this.comboBoxComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComision.FormattingEnabled = true;
            this.comboBoxComision.Location = new System.Drawing.Point(120, 182);
            this.comboBoxComision.Name = "comboBoxComision";
            this.comboBoxComision.Size = new System.Drawing.Size(200, 23);
            this.comboBoxComision.TabIndex = 9;
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(120, 230);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(90, 30);
            this.buttonCrear.TabIndex = 10;
            this.buttonCrear.Text = "Crear";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(230, 230);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(90, 30);
            this.buttonCancelar.TabIndex = 11;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // CursosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 280);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.comboBoxComision);
            this.Controls.Add(this.labelComision);
            this.Controls.Add(this.comboBoxMateria);
            this.Controls.Add(this.labelMateria);
            this.Controls.Add(this.textBoxCupo);
            this.Controls.Add(this.labelCupo);
            this.Controls.Add(this.textBoxAnio);
            this.Controls.Add(this.labelAnio);
            this.Controls.Add(this.textBoxIdCurso);
            this.Controls.Add(this.labelIdCurso);
            this.Name = "CursosForm";
            this.Text = "Gestión de Cursos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}