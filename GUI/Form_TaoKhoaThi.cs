using DAO.DAOService;
using DAO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_TaoKhoaThi : Form
    {
        public Form_TaoPhong _form;
        public DAOKhoaThi _daoKhoaThi;
        public Form_TaoKhoaThi(Form_TaoPhong form,DAOKhoaThi daoKhoaThi)
        {
            _form = form;
            _daoKhoaThi = daoKhoaThi;
            InitializeComponent();
        }

        public Form_TaoKhoaThi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ngayDuThi = dateTimePicker1.Value;
            var tenKhoaThi = textBox1.Text;
            var khoaThi = new KhoaThi { tenKhoaThi = tenKhoaThi, ngayThi = ngayDuThi };

            ValidationContext context = new ValidationContext(khoaThi, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            StringBuilder stringBuilder = new StringBuilder();
            if (!Validator.TryValidateObject(khoaThi, context, errors, true))
            {
                foreach (ValidationResult error in errors)
                    stringBuilder.Append(error + "\n");
                MessageBox.Show(stringBuilder.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var duplicate = _daoKhoaThi.GetByMouth(ngayDuThi);
                if (duplicate != null)
                {
                    MessageBox.Show("Tháng này đã có khóa thi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var result = _daoKhoaThi.Add(khoaThi);
                    if(result == true)
                    {
                        MessageBox.Show("Thêm khóa thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm khóa thi thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }   
        }

      
    }
}
