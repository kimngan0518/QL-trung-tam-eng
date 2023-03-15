using DAO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Properties
{
    public partial class Form_ThemGiaoVien : Form
    {
        Form_TaoPhong _form;
        public Form_ThemGiaoVien()
        {
            InitializeComponent();
        }
        public Form_ThemGiaoVien(Form_TaoPhong form)
        {
            _form = form;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var hoTen = textBox1.Text;
            if (hoTen.Equals(""))
            {
                MessageBox.Show("Họ tên không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var ngaySinh = dateTimePicker1.Value;
                var now = DateTime.Now;
                //if (now.Date.Subtract(ngaySinh) < 0)
                //{
                //    MessageBox.Show("Họ tên không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                var giaoVien = new GiaoVien { tenGV = hoTen, ngaySinh = ngaySinh };
                var result = _form._daoGiaoVien.Add(giaoVien);
                if(result == true)
                {
                    MessageBox.Show("Thêm giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var tmp = _form._daoGiaoVien.GetAll();
                    dataGridView1.DataSource = tmp;
                    _form.Refresh();
                    this.Refresh();
                }
                else
                {
                    MessageBox.Show("Thêm giáo viên thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form_ThemGiaoVien_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            //gắn cứng cho số cột của table là 4
            dataGridView1.ColumnCount = 3;
            List<String> propertyName = new List<string> { "maGV", "tenGV", "ngaySinh"};
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }

            dataGridView1.DataSource = _form._daoGiaoVien.GetAll();
        }
    }
}
