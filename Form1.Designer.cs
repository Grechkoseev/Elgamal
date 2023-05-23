using System.Windows.Forms;

namespace Lab_6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            decriptionLabel = new Label();
            signButton = new Button();
            checkButton = new Button();
            openFileDialog = new OpenFileDialog();
            explanationLabel = new Label();
            dataGridView = new DataGridView();
            selectedFileLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // decriptionLabel
            // 
            decriptionLabel.AutoSize = true;
            decriptionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            decriptionLabel.Location = new Point(212, 51);
            decriptionLabel.Name = "decriptionLabel";
            decriptionLabel.Size = new Size(519, 19);
            decriptionLabel.TabIndex = 0;
            decriptionLabel.Text = "Программа реализует ЭЦП по алгоритму Эль-Гамаля, где p = 137, g = 20, x = 3";
            // 
            // signButton
            // 
            signButton.Location = new Point(212, 623);
            signButton.Name = "signButton";
            signButton.Size = new Size(100, 50);
            signButton.TabIndex = 1;
            signButton.Text = "Подписать файл";
            signButton.UseVisualStyleBackColor = true;
            signButton.Click += signButton_Click;
            // 
            // checkButton
            // 
            checkButton.Location = new Point(712, 623);
            checkButton.Name = "checkButton";
            checkButton.Size = new Size(100, 50);
            checkButton.TabIndex = 2;
            checkButton.Text = "Проверить подпись";
            checkButton.UseVisualStyleBackColor = true;
            checkButton.Click += checkButton_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.InitialDirectory = "\\\\?\\C:\\Users\\igorg\\AppData\\Local\\Microsoft\\VisualStudio\\17.0_a2deef55\\WinFormsDesigner\\nhac5wjx.e5n";
            // 
            // explanationLabel
            // 
            explanationLabel.AutoSize = true;
            explanationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            explanationLabel.Location = new Point(212, 106);
            explanationLabel.Name = "explanationLabel";
            explanationLabel.Size = new Size(535, 95);
            explanationLabel.TabIndex = 3;
            explanationLabel.Text = resources.GetString("explanationLabel.Text");
            explanationLabel.Visible = false;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightCyan;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(212, 254);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 90;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(600, 317);
            dataGridView.TabIndex = 4;
            // 
            // selectedFileLabel
            // 
            selectedFileLabel.AutoSize = true;
            selectedFileLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectedFileLabel.Location = new Point(212, 201);
            selectedFileLabel.Name = "selectedFileLabel";
            selectedFileLabel.Size = new Size(0, 19);
            selectedFileLabel.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 736);
            Controls.Add(selectedFileLabel);
            Controls.Add(dataGridView);
            Controls.Add(explanationLabel);
            Controls.Add(checkButton);
            Controls.Add(signButton);
            Controls.Add(decriptionLabel);
            Name = "Form1";
            Text = "Lab_6 10 variant";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label decriptionLabel;
        private Button signButton;
        private Button checkButton;
        private OpenFileDialog openFileDialog;
        private Label explanationLabel;
        private DataGridView dataGridView;
        private Label selectedFileLabel;
    }
}