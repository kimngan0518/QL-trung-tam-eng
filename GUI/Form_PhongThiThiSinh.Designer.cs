
namespace GUI
{
    partial class Form_PhongThiThiSinh
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
            this.dataGVPhong = new System.Windows.Forms.DataGridView();
            this.maPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenTrinhDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhoaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVPhong
            // 
            this.dataGVPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maPhong,
            this.tenPhong,
            this.caThi,
            this.tenTrinhDo,
            this.tenKhoaThi});
            this.dataGVPhong.Location = new System.Drawing.Point(138, 129);
            this.dataGVPhong.Name = "dataGVPhong";
            this.dataGVPhong.RowHeadersWidth = 62;
            this.dataGVPhong.RowTemplate.Height = 33;
            this.dataGVPhong.Size = new System.Drawing.Size(1080, 468);
            this.dataGVPhong.TabIndex = 0;
            this.dataGVPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGVPhong.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVPhong_CellDoubleClick);
            // 
            // maPhong
            // 
            this.maPhong.DataPropertyName = "maPhong";
            this.maPhong.HeaderText = "Mã Phòng";
            this.maPhong.MinimumWidth = 8;
            this.maPhong.Name = "maPhong";
            this.maPhong.Visible = false;
            this.maPhong.Width = 150;
            // 
            // tenPhong
            // 
            this.tenPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tenPhong.DataPropertyName = "tenPhong";
            this.tenPhong.HeaderText = "Tên Phòng";
            this.tenPhong.MinimumWidth = 8;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.ReadOnly = true;
            this.tenPhong.Width = 131;
            // 
            // caThi
            // 
            this.caThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.caThi.DataPropertyName = "caThi";
            this.caThi.HeaderText = "caThi";
            this.caThi.MinimumWidth = 8;
            this.caThi.Name = "caThi";
            this.caThi.ReadOnly = true;
            this.caThi.Width = 88;
            // 
            // tenTrinhDo
            // 
            this.tenTrinhDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tenTrinhDo.DataPropertyName = "tenTrinhDo";
            this.tenTrinhDo.HeaderText = "Tên Trình Độ";
            this.tenTrinhDo.MinimumWidth = 8;
            this.tenTrinhDo.Name = "tenTrinhDo";
            this.tenTrinhDo.ReadOnly = true;
            this.tenTrinhDo.Width = 145;
            // 
            // tenKhoaThi
            // 
            this.tenKhoaThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tenKhoaThi.DataPropertyName = "tenKhoaThi";
            this.tenKhoaThi.HeaderText = "maKhoaThi";
            this.tenKhoaThi.MinimumWidth = 8;
            this.tenKhoaThi.Name = "tenKhoaThi";
            this.tenKhoaThi.ReadOnly = true;
            this.tenKhoaThi.Width = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(321, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Danh Sách Phòng Thi";
            // 
            // Form_PhongThiThiSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 660);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGVPhong);
            this.Name = "Form_PhongThiThiSinh";
            this.Text = "Form_PhongThiThiSinh";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn caThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenTrinhDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhoaThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}