namespace WindowsForm
{
    partial class PlanesLista
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView planesGrid;
        private System.Windows.Forms.Button mostrarButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.TextBox inputIdPlan;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Label labelIdPlan;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.Button mostrarTodosButton;

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
            planesGrid = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            inputIdPlan = new TextBox();
            buscarButton = new Button();
            labelIdPlan = new Label();
            agregarButton = new Button();
            mostrarTodosButton = new Button();
            ((System.ComponentModel.ISupportInitialize)planesGrid).BeginInit();
            SuspendLayout();
            // 
            // planesGrid
            // 
            planesGrid.AllowUserToAddRows = false;
            planesGrid.AllowUserToDeleteRows = false;
            planesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            planesGrid.Location = new Point(12, 50);
            planesGrid.MultiSelect = false;
            planesGrid.Name = "planesGrid";
            planesGrid.ReadOnly = true;
            planesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            planesGrid.Size = new Size(560, 250);
            planesGrid.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(470, 320);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(100, 30);
            eliminarButton.TabIndex = 2;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(240, 320);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(100, 30);
            modificarButton.TabIndex = 3;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // inputIdPlan
            // 
            inputIdPlan.Location = new Point(90, 15);
            inputIdPlan.Name = "inputIdPlan";
            inputIdPlan.Size = new Size(100, 23);
            inputIdPlan.TabIndex = 4;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(200, 12);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(80, 27);
            buscarButton.TabIndex = 5;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // labelIdPlan
            // 
            labelIdPlan.AutoSize = true;
            labelIdPlan.Location = new Point(12, 18);
            labelIdPlan.Name = "labelIdPlan";
            labelIdPlan.Size = new Size(66, 15);
            labelIdPlan.TabIndex = 6;
            labelIdPlan.Text = "ID del Plan:";
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(55, 320);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(100, 30);
            agregarButton.TabIndex = 7;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // mostrarTodosButton
            // 
            mostrarTodosButton.Location = new Point(286, 12);
            mostrarTodosButton.Name = "mostrarTodosButton";
            mostrarTodosButton.Size = new Size(100, 30);
            mostrarTodosButton.TabIndex = 8;
            mostrarTodosButton.Text = "Mostrar todos";
            mostrarTodosButton.UseVisualStyleBackColor = true;
            mostrarTodosButton.Click += mostrarTodosButton_Click;
            // 
            // PlanesLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(labelIdPlan);
            Controls.Add(buscarButton);
            Controls.Add(inputIdPlan);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(planesGrid);
            Controls.Add(agregarButton);
            Controls.Add(mostrarTodosButton);
            Name = "PlanesLista";
            Text = "Listado de Planes";
            ((System.ComponentModel.ISupportInitialize)planesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}