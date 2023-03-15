
namespace GUI
{
    partial class Form_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.menuLeft = new System.Windows.Forms.Panel();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.btnXepPhong = new System.Windows.Forms.Button();
            this.btnTaoPhong = new System.Windows.Forms.Button();
            this.btnThiSinh = new System.Windows.Forms.Button();
            this.pnLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnContent = new System.Windows.Forms.Panel();
            this.menuLeft.SuspendLayout();
            this.pnLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuLeft
            // 
            this.menuLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(54)))));
            this.menuLeft.Controls.Add(this.btnTraCuu);
            this.menuLeft.Controls.Add(this.btnNhapDiem);
            this.menuLeft.Controls.Add(this.btnXepPhong);
            this.menuLeft.Controls.Add(this.btnTaoPhong);
            this.menuLeft.Controls.Add(this.btnThiSinh);
            this.menuLeft.Controls.Add(this.pnLogo);
            this.menuLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuLeft.Location = new System.Drawing.Point(0, 0);
            this.menuLeft.Name = "menuLeft";
            this.menuLeft.Size = new System.Drawing.Size(170, 661);
            this.menuLeft.TabIndex = 0;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTraCuu.FlatAppearance.BorderSize = 0;
            this.btnTraCuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraCuu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTraCuu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTraCuu.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuu.Image")));
            this.btnTraCuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraCuu.Location = new System.Drawing.Point(0, 320);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTraCuu.Size = new System.Drawing.Size(170, 60);
            this.btnTraCuu.TabIndex = 5;
            this.btnTraCuu.Text = "  Tra cứu";
            this.btnTraCuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraCuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapDiem.FlatAppearance.BorderSize = 0;
            this.btnNhapDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapDiem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNhapDiem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNhapDiem.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapDiem.Image")));
            this.btnNhapDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.Location = new System.Drawing.Point(0, 260);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNhapDiem.Size = new System.Drawing.Size(170, 60);
            this.btnNhapDiem.TabIndex = 4;
            this.btnNhapDiem.Text = "  Nhập điểm";
            this.btnNhapDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapDiem.UseVisualStyleBackColor = true;
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
            // 
            // btnXepPhong
            // 
            this.btnXepPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXepPhong.FlatAppearance.BorderSize = 0;
            this.btnXepPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXepPhong.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXepPhong.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnXepPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnXepPhong.Image")));
            this.btnXepPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXepPhong.Location = new System.Drawing.Point(0, 200);
            this.btnXepPhong.Name = "btnXepPhong";
            this.btnXepPhong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnXepPhong.Size = new System.Drawing.Size(170, 60);
            this.btnXepPhong.TabIndex = 3;
            this.btnXepPhong.Text = "  Xếp phòng thi";
            this.btnXepPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXepPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXepPhong.UseVisualStyleBackColor = true;
            this.btnXepPhong.Click += new System.EventHandler(this.btnXepPhong_Click);
            // 
            // btnTaoPhong
            // 
            this.btnTaoPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaoPhong.FlatAppearance.BorderSize = 0;
            this.btnTaoPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPhong.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTaoPhong.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTaoPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoPhong.Image")));
            this.btnTaoPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPhong.Location = new System.Drawing.Point(0, 140);
            this.btnTaoPhong.Name = "btnTaoPhong";
            this.btnTaoPhong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTaoPhong.Size = new System.Drawing.Size(170, 60);
            this.btnTaoPhong.TabIndex = 2;
            this.btnTaoPhong.Text = "  Tạo phòng thi";
            this.btnTaoPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoPhong.UseVisualStyleBackColor = true;
            this.btnTaoPhong.Click += new System.EventHandler(this.btnTaoPhong_Click);
            // 
            // btnThiSinh
            // 
            this.btnThiSinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThiSinh.FlatAppearance.BorderSize = 0;
            this.btnThiSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThiSinh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThiSinh.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThiSinh.Image = ((System.Drawing.Image)(resources.GetObject("btnThiSinh.Image")));
            this.btnThiSinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThiSinh.Location = new System.Drawing.Point(0, 80);
            this.btnThiSinh.Name = "btnThiSinh";
            this.btnThiSinh.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThiSinh.Size = new System.Drawing.Size(170, 60);
            this.btnThiSinh.TabIndex = 1;
            this.btnThiSinh.Text = "  Thí sinh";
            this.btnThiSinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThiSinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThiSinh.UseVisualStyleBackColor = true;
            this.btnThiSinh.Click += new System.EventHandler(this.btnThiSinh_Click);
            // 
            // pnLogo
            // 
            this.pnLogo.Controls.Add(this.label1);
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogo.Location = new System.Drawing.Point(0, 0);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.Size = new System.Drawing.Size(170, 80);
            this.pnLogo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trung tâm ABC";
            // 
            // pnContent
            // 
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(170, 0);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1014, 661);
            this.pnContent.TabIndex = 1;
            this.pnContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnContent_Paint);
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.menuLeft);
            this.Name = "Form_Menu";
            this.Text = "Form1";
            this.menuLeft.ResumeLayout(false);
            this.pnLogo.ResumeLayout(false);
            this.pnLogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuLeft;
        private System.Windows.Forms.Button btnThiSinh;
        private System.Windows.Forms.Panel pnLogo;
        private System.Windows.Forms.Button btnNhapDiem;
        private System.Windows.Forms.Button btnXepPhong;
        private System.Windows.Forms.Button btnTaoPhong;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTraCuu;
    }
}

