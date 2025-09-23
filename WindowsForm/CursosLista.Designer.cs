namespace WindowsForm
{
    partial class CursosLista
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView cursosGrid;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.Button mostrarTodosButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.TextBox inputIdCurso;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Label labelIdCurso;

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
            cursosGrid = new DataGridView();
            agregarButton = new Button();
            mostrarTodosButton = new Button();
            eliminarButton = new Button();
            modificarButton = new Button();
            inputIdCurso = new TextBox();
            buscarButton = new Button();
            labelIdCurso = new Label();
            ((System.ComponentModel.ISupportInitialize)cursosGrid).BeginInit();
            SuspendLayout();
            // 
            // cursosGrid
            // 
            cursosGrid.AllowUserToAddRows = false;
            cursosGrid.AllowUserToDeleteRows = false;
            cursosGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cursosGrid.Location = new Point(12, 50);
            cursosGrid.MultiSelect = false;
            cursosGrid.Name = "cursosGrid";
            cursosGrid.ReadOnly = true;
            cursosGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cursosGrid.Size = new Size(560, 250);
            cursosGrid.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(12, 320);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(100, 30);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // mostrarTodosButton
            // 
            mostrarTodosButton.Location = new Point(299, 12);
            mostrarTodosButton.Name = "mostrarTodosButton";
            mostrarTodosButton.Size = new Size(100, 30);
            mostrarTodosButton.TabIndex = 2;
            mostrarTodosButton.Text = "Mostrar todos";
            mostrarTodosButton.UseVisualStyleBackColor = true;
            mostrarTodosButton.Click += mostrarTodosButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(470, 320);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(100, 30);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(243, 320);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(100, 30);
            modificarButton.TabIndex = 4;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // inputIdCurso
            // 
            inputIdCurso.Location = new Point(90, 15);
            inputIdCurso.Name = "inputIdCurso";
            inputIdCurso.Size = new Size(100, 23);
            inputIdCurso.TabIndex = 5;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(200, 12);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(80, 27);
            buscarButton.TabIndex = 6;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // labelIdCurso
            // 
            labelIdCurso.AutoSize = true;
            labelIdCurso.Location = new Point(12, 18);
            labelIdCurso.Name = "labelIdCurso";
            labelIdCurso.Size = new Size(74, 15);
            labelIdCurso.TabIndex = 7;
            labelIdCurso.Text = "ID del Curso:";
            // 
            // CursosLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(labelIdCurso);
            Controls.Add(buscarButton);
            Controls.Add(inputIdCurso);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(mostrarTodosButton);
            Controls.Add(agregarButton);
            Controls.Add(cursosGrid);
            Name = "CursosLista";
            Text = "Listado de Cursos";
            ((System.ComponentModel.ISupportInitialize)cursosGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}