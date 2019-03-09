namespace NhatKyVanHanh.GUI
{
    partial class User
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkKipTruong = new System.Windows.Forms.CheckBox();
            this.btnXoaNV = new System.Windows.Forms.Button();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dGNhanVien = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKipNV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnXoaKip = new System.Windows.Forms.Button();
            this.btnThemKip = new System.Windows.Forms.Button();
            this.dGKip = new System.Windows.Forms.DataGridView();
            this.txtTenKip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaKip = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSuaNV = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGNhanVien)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGKip)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 539F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(696, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSuaNV);
            this.groupBox1.Controls.Add(this.chkKipTruong);
            this.groupBox1.Controls.Add(this.btnXoaNV);
            this.groupBox1.Controls.Add(this.btnThemNV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dGNhanVien);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbKipNV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.txtTenNV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 278);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhân Viên";
            // 
            // chkKipTruong
            // 
            this.chkKipTruong.AutoSize = true;
            this.chkKipTruong.Location = new System.Drawing.Point(9, 145);
            this.chkKipTruong.Name = "chkKipTruong";
            this.chkKipTruong.Size = new System.Drawing.Size(80, 17);
            this.chkKipTruong.TabIndex = 31;
            this.chkKipTruong.Text = "Kíp Trưởng";
            this.chkKipTruong.UseVisualStyleBackColor = true;
            // 
            // btnXoaNV
            // 
            this.btnXoaNV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoaNV.Location = new System.Drawing.Point(124, 192);
            this.btnXoaNV.Name = "btnXoaNV";
            this.btnXoaNV.Size = new System.Drawing.Size(75, 23);
            this.btnXoaNV.TabIndex = 16;
            this.btnXoaNV.Text = "Xóa";
            this.btnXoaNV.UseVisualStyleBackColor = true;
            this.btnXoaNV.Click += new System.EventHandler(this.btnXoaNV_Click);
            // 
            // btnThemNV
            // 
            this.btnThemNV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemNV.Location = new System.Drawing.Point(17, 192);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(75, 23);
            this.btnThemNV.TabIndex = 8;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Kíp";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dGNhanVien
            // 
            this.dGNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGNhanVien.Dock = System.Windows.Forms.DockStyle.Right;
            this.dGNhanVien.Location = new System.Drawing.Point(345, 16);
            this.dGNhanVien.Name = "dGNhanVien";
            this.dGNhanVien.Size = new System.Drawing.Size(342, 259);
            this.dGNhanVien.TabIndex = 1;
            this.dGNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGNhanVien_CellClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tên NV";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKipNV
            // 
            this.cbKipNV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbKipNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKipNV.FormattingEnabled = true;
            this.cbKipNV.Location = new System.Drawing.Point(95, 146);
            this.cbKipNV.Name = "cbKipNV";
            this.cbKipNV.Size = new System.Drawing.Size(167, 21);
            this.cbKipNV.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã NV";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMaNV.Location = new System.Drawing.Point(95, 77);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(167, 20);
            this.txtMaNV.TabIndex = 17;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTenNV.Location = new System.Drawing.Point(95, 106);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(167, 20);
            this.txtTenNV.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnXoaKip);
            this.groupBox3.Controls.Add(this.btnThemKip);
            this.groupBox3.Controls.Add(this.dGKip);
            this.groupBox3.Controls.Add(this.txtTenKip);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtMaKip);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(690, 279);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kíp Làm Việc";
            // 
            // btnXoaKip
            // 
            this.btnXoaKip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoaKip.Location = new System.Drawing.Point(220, 162);
            this.btnXoaKip.Name = "btnXoaKip";
            this.btnXoaKip.Size = new System.Drawing.Size(75, 23);
            this.btnXoaKip.TabIndex = 33;
            this.btnXoaKip.Text = "Xóa";
            this.btnXoaKip.UseVisualStyleBackColor = true;
            this.btnXoaKip.Click += new System.EventHandler(this.btnXoaKip_Click);
            // 
            // btnThemKip
            // 
            this.btnThemKip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemKip.Location = new System.Drawing.Point(114, 162);
            this.btnThemKip.Name = "btnThemKip";
            this.btnThemKip.Size = new System.Drawing.Size(75, 23);
            this.btnThemKip.TabIndex = 33;
            this.btnThemKip.Text = "Thêm";
            this.btnThemKip.UseVisualStyleBackColor = true;
            this.btnThemKip.Click += new System.EventHandler(this.btnThemKip_Click);
            // 
            // dGKip
            // 
            this.dGKip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGKip.Dock = System.Windows.Forms.DockStyle.Right;
            this.dGKip.Location = new System.Drawing.Point(345, 16);
            this.dGKip.Name = "dGKip";
            this.dGKip.Size = new System.Drawing.Size(342, 260);
            this.dGKip.TabIndex = 33;
            this.dGKip.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGKip_CellClick);
            // 
            // txtTenKip
            // 
            this.txtTenKip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTenKip.Location = new System.Drawing.Point(71, 124);
            this.txtTenKip.Name = "txtTenKip";
            this.txtTenKip.Size = new System.Drawing.Size(145, 20);
            this.txtTenKip.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tên Kíp";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaKip
            // 
            this.txtMaKip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMaKip.Location = new System.Drawing.Point(71, 89);
            this.txtMaKip.Name = "txtMaKip";
            this.txtMaKip.Size = new System.Drawing.Size(145, 20);
            this.txtMaKip.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã Kíp";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.Enabled = false;
            this.btnSuaNV.Location = new System.Drawing.Point(220, 192);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(75, 23);
            this.btnSuaNV.TabIndex = 32;
            this.btnSuaNV.Text = "Sửa";
            this.btnSuaNV.UseVisualStyleBackColor = true;
            this.btnSuaNV.Click += new System.EventHandler(this.btnSuaNV_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "User";
            this.Text = "User";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGNhanVien)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGKip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtMaKip;
        private System.Windows.Forms.DataGridView dGNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenKip;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.Button btnXoaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.ComboBox cbKipNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXoaKip;
        private System.Windows.Forms.Button btnThemKip;
        private System.Windows.Forms.DataGridView dGKip;
        private System.Windows.Forms.CheckBox chkKipTruong;
        private System.Windows.Forms.Button btnSuaNV;
    }
}