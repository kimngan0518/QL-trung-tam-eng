using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_Menu : Form
    {
        private Button currentButton;
        private Form activeForm;
        private Color colorBackgroundMenu = Color.FromArgb(0, 82, 54); //xanh lá cây đậm
        private Color colorBackgroundMenuSelected = Color.FromArgb(254, 152, 42); // màu vàng
        private Color colorBackgroundContent = Color.FromArgb(242, 242, 197); // màu be
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void activateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button) btnSender)
                {
                    disableButton();
                    //button nào được chọn thì sẽ định dạng như dưới
                    currentButton = (Button) btnSender;
                    currentButton.BackColor = colorBackgroundMenuSelected;
                    currentButton.ForeColor = Color.White;                   

                }    
            }    
        }

        //tô lại màu cho tất cả button trong menu
        private void disableButton()
        {
            foreach (Control btn in menuLeft.Controls)
            {
                if(btn.GetType() == typeof(Button))
                {
                    btn.BackColor = colorBackgroundMenu;
                    btn.ForeColor = Color.WhiteSmoke;
                }    
            }
               
        }
        private void openChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.BackColor = colorBackgroundContent;
            this.pnContent.Controls.Add(childForm);
            this.pnContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //MENU BÊN TRÁI
        //xứ lý khi chọn Thí Sinh
        private void btnThiSinh_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_ThiSinh(),sender);
        }

        //xứ lý khi chọn Tạo phòng thi
        private void btnTaoPhong_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_TaoPhong(), sender);
        }

        //xứ lý khi chọn Xếp phòng thi
        private void btnXepPhong_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_PhongThiThiSinh(), sender);
        }

        //xứ lý khi chọn Nhập điểm
        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_NhapDiem(), sender);
        }


        private void pnContent_Paint(object sender, PaintEventArgs e)
        {
        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_TraCuu(), sender);

        }
    }
}
