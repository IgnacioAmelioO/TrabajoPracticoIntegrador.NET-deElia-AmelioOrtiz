namespace WindowsForm
{
    public partial class PersonaLista : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buscarAlumnoButton = new Button();
            label1 = new Label();
            inputIdAlumno = new TextBox();
            personasGrid = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            mostrarTodoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)personasGrid).BeginInit();
            SuspendLayout();
            // 
            // buscarAlumnoButton
            // 
            buscarAlumnoButton.Location = new Point(386, 54);
            buscarAlumnoButton.Name = "buscarAlumnoButton";
            buscarAlumnoButton.Size = new Size(134, 23);
            buscarAlumnoButton.TabIndex = 0;
            buscarAlumnoButton.Text = "Buscar";
            buscarAlumnoButton.UseVisualStyleBackColor = true;
            buscarAlumnoButton.Click += buscarButton_click;
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
            inputIdAlumno.Location = new Point(37, 54);
            inputIdAlumno.Name = "inputIdAlumno";
            inputIdAlumno.Size = new Size(318, 23);
            inputIdAlumno.TabIndex = 2;
            inputIdAlumno.Tag = "";
            // 
            // personasGrid
            // 
            personasGrid.AllowUserToOrderColumns = true;
            personasGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personasGrid.Location = new Point(37, 99);
            personasGrid.Name = "personasGrid";
            personasGrid.ReadOnly = true;
            personasGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            personasGrid.Size = new Size(709, 257);
            personasGrid.TabIndex = 0;
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
            Controls.Add(personasGrid);
            Controls.Add(inputIdAlumno);
            Controls.Add(label1);
            Controls.Add(buscarAlumnoButton);
            Name = "PersonaLista";
            Text = "PersonaLista";
            ((System.ComponentModel.ISupportInitialize)personasGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buscarAlumnoButton;
        private Label label1;
        private TextBox inputIdAlumno;
        private DataGridView personasGrid;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button mostrarTodoButton;
    }
}