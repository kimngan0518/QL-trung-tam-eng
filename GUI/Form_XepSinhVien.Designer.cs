
namespace GUI
{
    partial class Form_XepSinhVien
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
            this.dataGVXepSV = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sbd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSinhVien = new System.Windows.Forms.ComboBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.txtSBD = new System.Windows.Forms.TextBox();
            this.btnXepPhong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVXepSV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVXepSV
            // 
            this.dataGVXepSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVXepSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.hoTen,
            this.gioiTinh,
            this.ngaySinh,
            this.noiSinh,
            this.ngayCap,
            this.sdt,
            this.email,
            this.sbd});
            this.dataGVXepSV.Location = new System.Drawing.Point(397, 97);
            this.dataGVXepSV.Name = "dataGVXepSV";
            this.dataGVXepSV.RowHeadersWidth = 62;
            this.dataGVXepSV.RowTemplate.Height = 33;
            this.dataGVXepSV.Size = new System.Drawing.Size(895, 407);
            this.dataGVXepSV.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // hoTen
            // 
            this.hoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hoTen.DataPropertyName = "hoTen";
            this.hoTen.HeaderText = "Họ Tên";
            this.hoTen.MinimumWidth = 8;
            this.hoTen.Name = "hoTen";
            this.hoTen.ReadOnly = true;
            this.hoTen.Width = 103;
            // 
            // gioiTinh
            // 
            this.gioiTinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gioiTinh.DataPropertyName = "gioiTinh";
            this.gioiTinh.HeaderText = "Giới Tính";
            this.gioiTinh.MinimumWidth = 8;
            this.gioiTinh.Name = "gioiTinh";
            this.gioiTinh.ReadOnly = true;
            this.gioiTinh.Width = 117;
            // 
            // ngaySinh
            // 
            this.ngaySinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ngaySinh.DataPropertyName = "ngaySinh";
            this.ngaySinh.HeaderText = "Ngày Sinh";
            this.ngaySinh.MinimumWidth = 8;
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.ReadOnly = true;
            this.ngaySinh.Width = 129;
            // 
            // noiSinh
            // 
            this.noiSinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.noiSinh.DataPropertyName = "noiSinh";
            this.noiSinh.HeaderText = "Nơi Sinh";
            this.noiSinh.MinimumWidth = 8;
            this.noiSinh.Name = "noiSinh";
            this.noiSinh.ReadOnly = true;
            this.noiSinh.Width = 115;
            // 
            // ngayCap
            // 
            this.ngayCap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ngayCap.DataPropertyName = "ngayCap";
            this.ngayCap.HeaderText = "Ngày Cấp";
            this.ngayCap.MinimumWidth = 8;
            this.ngayCap.Name = "ngayCap";
            this.ngayCap.ReadOnly = true;
            this.ngayCap.Width = 126;
            // 
            // sdt
            // 
            this.sdt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sdt.DataPropertyName = "sdt";
            this.sdt.HeaderText = "SĐT";
            this.sdt.MinimumWidth = 8;
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            this.sdt.Width = 80;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 8;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 90;
            // 
            // sbd
            // 
            this.sbd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sbd.DataPropertyName = "sbd";
            this.sbd.HeaderText = "SBD";
            this.sbd.MinimumWidth = 8;
            this.sbd.Name = "sbd";
            this.sbd.ReadOnly = true;
            this.sbd.Width = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(228, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh Sách Thí Sinh";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbSinhVien
            // 
            this.cbSinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSinhVien.FormattingEnabled = true;
            this.cbSinhVien.Location = new System.Drawing.Point(76, 152);
            this.cbSinhVien.Name = "cbSinhVien";
            this.cbSinhVien.Size = new System.Drawing.Size(182, 33);
            this.cbSinhVien.TabIndex = 2;
            this.cbSinhVien.SelectedIndexChanged += new System.EventHandler(this.cbSinhVien_SelectedIndexChanged);
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(76, 227);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.ReadOnly = true;
            this.txtTenPhong.Size = new System.Drawing.Size(182, 31);
            this.txtTenPhong.TabIndex = 3;
            // 
            // txtSBD
            // 
            this.txtSBD.Location = new System.Drawing.Point(76, 310);
            this.txtSBD.Name = "txtSBD";
            this.txtSBD.Size = new System.Drawing.Size(182, 31);
            this.txtSBD.TabIndex = 4;
            // 
            // btnXepPhong
            // 
            this.btnXepPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXepPhong.Location = new System.Drawing.Point(76, 496);
            this.btnXepPhong.Name = "btnXepPhong";
            this.btnXepPhong.Size = new System.Drawing.Size(182, 44);
            this.btnXepPhong.TabIndex = 5;
            this.btnXepPhong.Text = "Xếp Phòng";
            this.btnXepPhong.UseVisualStyleBackColor = true;
            this.btnXepPhong.Click += new System.EventHandler(this.btnXepPhong_Click);
            // 
            // Form_XepSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 636);
            this.Controls.Add(this.btnXepPhong);
            this.Controls.Add(this.txtSBD);
            this.Controls.Add(this.txtTenPhong);
            this.Controls.Add(this.cbSinhVien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGVXepSV);
            this.Name = "Form_XepSinhVien";
            this.Text = "Form_XepSinhVien";
            this.Load += new System.EventHandler(this.Form_XepSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVXepSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVXepSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn noiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn sbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSinhVien;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtSBD;
        private System.Windows.Forms.Button btnXepPhong;
    }
}