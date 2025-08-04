namespace WindowsForms
{
    partial class EspecialidadesLista
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
            buscarEspecialidadButton = new Button();
            label1 = new Label();
            inputIdEspecialidad = new TextBox();
            especialidadesGrid = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            mostrarTodoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)especialidadesGrid).BeginInit();
            SuspendLayout();
            // 
            // buscarAlumnoButton
            // 
            buscarEspecialidadButton.Location = new Point(386, 54);
            buscarEspecialidadButton.Name = "buscarEspecialidadButton";
            buscarEspecialidadButton.Size = new Size(134, 23);
            buscarEspecialidadButton.TabIndex = 0;
            buscarEspecialidadButton.Text = "Buscar";
            buscarEspecialidadButton.UseVisualStyleBackColor = true;
            buscarEspecialidadButton.Click += buscarButton_click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 31);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 1;
            label1.Text = "Inserte el id del alumno";
            // 
            // inputIdAlumno
            // 
            inputIdEspecialidad.Location = new Point(37, 54);
            inputIdEspecialidad.Name = "inputIdEspecialidad";
            inputIdEspecialidad.Size = new Size(318, 23);
            inputIdEspecialidad.TabIndex = 2;
            inputIdEspecialidad.Tag = "";
            // 
            // personasGrid
            // 
            especialidadesGrid.AllowUserToOrderColumns = true;
            especialidadesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            especialidadesGrid.Location = new Point(37, 99);
            especialidadesGrid.Name = "especialidadesGrid";
            especialidadesGrid.ReadOnly = true;
            especialidadesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            especialidadesGrid.Size = new Size(709, 257);
            especialidadesGrid.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(90, 386);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(142, 34);
            eliminarButton.TabIndex = 4;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(311, 386);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(142, 34);
            modificarButton.TabIndex = 5;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(535, 386);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(142, 34);
            agregarButton.TabIndex = 6;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // mostrarTodoButton
            // 
            mostrarTodoButton.Location = new Point(535, 53);
            mostrarTodoButton.Name = "mostrarTodoButton";
            mostrarTodoButton.Size = new Size(156, 23);
            mostrarTodoButton.TabIndex = 7;
            mostrarTodoButton.Text = "Mostrar Todo";
            mostrarTodoButton.UseVisualStyleBackColor = true;
            mostrarTodoButton.Click += mostrarButton_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mostrarTodoButton);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(especialidadesGrid);
            Controls.Add(inputIdEspecialidad);
            Controls.Add(label1);
            Controls.Add(buscarEspecialidadButton);
            Name = "Especialidades";// no se si va EspecialidadesLista
            Text = "Especialidades";
            ((System.ComponentModel.ISupportInitialize)especialidadesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Button buscarEspecialidadButton;
        private Label label1;
        private TextBox inputIdEspecialidad;
        private DataGridView especialidadesGrid;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button mostrarTodoButton;
    }
}