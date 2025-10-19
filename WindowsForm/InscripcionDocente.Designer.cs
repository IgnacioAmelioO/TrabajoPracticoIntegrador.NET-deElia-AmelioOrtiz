using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WindowsForm
{
    partial class InscripcionDocente
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
            cursoDataGridView = new DataGridView();
            labelNoData = new Label();
            label1 = new Label();
            label2 = new Label();
            cargosComboBox = new ComboBox();
            inscribirseButton = new Button();
            cancelarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cursoDataGridView).BeginInit();
            SuspendLayout();
            // 
            // cursoDataGridView
            // 
            cursoDataGridView.AllowUserToAddRows = false;
            cursoDataGridView.AllowUserToDeleteRows = false;
            cursoDataGridView.AllowUserToResizeColumns = false;
            cursoDataGridView.AllowUserToResizeRows = false;
            cursoDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cursoDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cursoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cursoDataGridView.Location = new Point(12, 45);
            cursoDataGridView.MultiSelect = false;
            cursoDataGridView.Name = "cursoDataGridView";
            cursoDataGridView.ReadOnly = true;
            cursoDataGridView.RowHeadersWidth = 51;
            cursoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cursoDataGridView.Size = new Size(776, 297);
            cursoDataGridView.TabIndex = 0;
            // 
            // labelNoData
            // 
            labelNoData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNoData.BackColor = SystemColors.Control;
            labelNoData.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNoData.Location = new Point(12, 45);
            labelNoData.Name = "labelNoData";
            labelNoData.Size = new Size(776, 297);
            labelNoData.TabIndex = 1;
            labelNoData.Text = "No hay cursos disponibles para inscripción";
            labelNoData.TextAlign = ContentAlignment.MiddleCenter;
            labelNoData.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(339, 28);
            label1.TabIndex = 2;
            label1.Text = "Cursos disponibles para inscripción:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 363);
            label2.Name = "label2";
            label2.Size = new Size(59, 23);
            label2.TabIndex = 3;
            label2.Text = "Cargo:";
            // 
            // cargosComboBox
            // 
            cargosComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cargosComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cargosComboBox.FormattingEnabled = true;
            cargosComboBox.Location = new Point(77, 362);
            cargosComboBox.Name = "cargosComboBox";
            cargosComboBox.Size = new Size(196, 28);
            cargosComboBox.TabIndex = 4;
            // 
            // inscribirseButton
            // 
            inscribirseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            inscribirseButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            inscribirseButton.Location = new Point(639, 357);
            inscribirseButton.Name = "inscribirseButton";
            inscribirseButton.Size = new Size(149, 38);
            inscribirseButton.TabIndex = 5;
            inscribirseButton.Text = "Inscribirse";
            inscribirseButton.UseVisualStyleBackColor = true;
            inscribirseButton.Click += inscribirseButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelarButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            cancelarButton.Location = new Point(484, 357);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(149, 38);
            cancelarButton.TabIndex = 6;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // InscripcionDocente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 407);
            Controls.Add(cancelarButton);
            Controls.Add(inscribirseButton);
            Controls.Add(cargosComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cursoDataGridView);
            Controls.Add(labelNoData);
            MinimumSize = new Size(600, 400);
            Name = "InscripcionDocente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inscripción a Curso";
            ((System.ComponentModel.ISupportInitialize)cursoDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView cursoDataGridView;
        private Label labelNoData;
        private Label label1;
        private Label label2;
        private ComboBox cargosComboBox;
        private Button inscribirseButton;
        private Button cancelarButton;
    }
}