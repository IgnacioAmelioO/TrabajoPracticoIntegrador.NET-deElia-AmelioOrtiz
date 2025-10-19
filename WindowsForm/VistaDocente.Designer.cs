namespace WindowsForm
{
    partial class VistaDocente
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
            cursosMateriaDataGridView = new DataGridView();
            labelTitle = new Label();
            labelNoData = new Label();
            panelHeader = new Panel();
            DescripcionButton = new Button();
            InscripcionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cursosMateriaDataGridView).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // cursosMateriaDataGridView
            // 
            cursosMateriaDataGridView.AllowUserToAddRows = false;
            cursosMateriaDataGridView.AllowUserToDeleteRows = false;
            cursosMateriaDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cursosMateriaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cursosMateriaDataGridView.BackgroundColor = SystemColors.Control;
            cursosMateriaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cursosMateriaDataGridView.Location = new Point(12, 70);
            cursosMateriaDataGridView.MultiSelect = false;
            cursosMateriaDataGridView.Name = "cursosMateriaDataGridView";
            cursosMateriaDataGridView.ReadOnly = true;
            cursosMateriaDataGridView.RowHeadersWidth = 51;
            cursosMateriaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cursosMateriaDataGridView.Size = new Size(776, 309);
            cursosMateriaDataGridView.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(12, 13);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(320, 25);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Materias y Comisiones del Docente";
            // 
            // labelNoData
            // 
            labelNoData.Anchor = AnchorStyles.None;
            labelNoData.AutoSize = true;
            labelNoData.Font = new Font("Segoe UI", 12F);
            labelNoData.ForeColor = Color.Gray;
            labelNoData.Location = new Point(310, 223);
            labelNoData.Name = "labelNoData";
            labelNoData.Size = new Size(175, 21);
            labelNoData.TabIndex = 2;
            labelNoData.Text = "Cargando información...";
            labelNoData.TextAlign = ContentAlignment.MiddleCenter;
            labelNoData.Visible = false;
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.WhiteSmoke;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 51);
            panelHeader.TabIndex = 3;
            // 
            // DescripcionButton
            // 
            DescripcionButton.Location = new Point(642, 397);
            DescripcionButton.Name = "DescripcionButton";
            DescripcionButton.Size = new Size(100, 41);
            DescripcionButton.TabIndex = 4;
            DescripcionButton.Text = "Descripción";
            DescripcionButton.UseVisualStyleBackColor = true;
            DescripcionButton.Click += descripcionButton_Click;
            // 
            // InscripcionButton
            // 
            InscripcionButton.Location = new Point(517, 397);
            InscripcionButton.Name = "InscripcionButton";
            InscripcionButton.Size = new Size(100, 41);
            InscripcionButton.TabIndex = 5;
            InscripcionButton.Text = "Inscripción";
            InscripcionButton.UseVisualStyleBackColor = true;
            InscripcionButton.Click += inscripcionButton_Click;
            // 
            // VistaDocente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(InscripcionButton);
            Controls.Add(DescripcionButton);
            Controls.Add(panelHeader);
            Controls.Add(labelNoData);
            Controls.Add(cursosMateriaDataGridView);
            MinimizeBox = false;
            Name = "VistaDocente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Materias y Comisiones del Docente";
            ((System.ComponentModel.ISupportInitialize)cursosMateriaDataGridView).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView cursosMateriaDataGridView;
        private Label labelTitle;
        private Label labelNoData;
        private Panel panelHeader;
        private Button DescripcionButton;
        private Button InscripcionButton;
    }
}