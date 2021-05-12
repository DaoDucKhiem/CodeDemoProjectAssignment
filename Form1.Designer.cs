
namespace AssignmentInternship
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
            System.Windows.Forms.Button btnFileCom;
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFileSV = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFileCom = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            btnFileCom = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFileCom
            // 
            btnFileCom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnFileCom.Location = new System.Drawing.Point(1108, 64);
            btnFileCom.Name = "btnFileCom";
            btnFileCom.Size = new System.Drawing.Size(150, 46);
            btnFileCom.TabIndex = 1;
            btnFileCom.Text = "browse";
            btnFileCom.UseCompatibleTextRendering = true;
            btnFileCom.UseVisualStyleBackColor = true;
            btnFileCom.Click += new System.EventHandler(this.btnFileCom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(268, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(918, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phân công sinh viên thực tập tại các công ty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFile);
            this.groupBox1.Controls.Add(this.txtFileSV);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(67, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1293, 141);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sinh viên";
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFile.Location = new System.Drawing.Point(1108, 63);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(150, 46);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "browse";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFileSV
            // 
            this.txtFileSV.Location = new System.Drawing.Point(34, 66);
            this.txtFileSV.Name = "txtFileSV";
            this.txtFileSV.ReadOnly = true;
            this.txtFileSV.Size = new System.Drawing.Size(1048, 43);
            this.txtFileSV.TabIndex = 0;
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(67, 543);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 82;
            this.dataGrid.RowTemplate.Height = 41;
            this.dataGrid.Size = new System.Drawing.Size(1293, 523);
            this.dataGrid.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(btnFileCom);
            this.groupBox2.Controls.Add(this.txtFileCom);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(67, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1293, 150);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách công ty";
            // 
            // txtFileCom
            // 
            this.txtFileCom.Location = new System.Drawing.Point(34, 64);
            this.txtFileCom.Name = "txtFileCom";
            this.txtFileCom.ReadOnly = true;
            this.txtFileCom.Size = new System.Drawing.Size(1048, 43);
            this.txtFileCom.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(584, 474);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(150, 46);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 1091);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFileSV;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFileCom;
        private System.Windows.Forms.TextBox txtFileCom;
        private System.Windows.Forms.Button btnExecute;
    }
}

