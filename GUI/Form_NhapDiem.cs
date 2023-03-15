using DAO.DAOService;
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

namespace GUI
{
    public partial class Form_NhapDiem : Form
    {
        public DAOPhongThi _daoPhongThi;
        public List<PhongThi> _dsPhongThi;
        int indexDgv = 0;

        public Form_NhapDiem()
        {
            InitializeComponent();
            _daoPhongThi = new DAOPhongThi();
            _dsPhongThi = _daoPhongThi.GetAll().ToList();
        }
        private void Form_NhapDiem_Load(object sender, EventArgs e)
        {
            LoadPhongThi();
        }

        private void LoadPhongThi()
        {
            dataGridView1.AutoGenerateColumns = false;
            //gắn cứng cho số cột của table là 4
            dataGridView1.ColumnCount = 4;
            List<String> propertyName = new List<string> { "tenPhong", "getCatThi", "getTrinhDo", "getKhoaThi" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }

            dataGridView1.DataSource = _dsPhongThi.ToArray();
        }

        private void textBoxPhongthi_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxPhongthi.Equals(""))
            {
                dataGridView1.DataSource = _dsPhongThi.Where(item => item.tenPhong.Contains(textBoxPhongthi.Text) || item.khoaThi.tenKhoaThi.Contains(textBoxPhongthi.Text) || item.trinhDo.tenTrinhDo.Contains(textBoxPhongthi.Text)).ToArray();
            }
            else
            {
                dataGridView1.DataSource = _dsPhongThi.ToArray();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            indexDgv = dataGridView1.CurrentRow.Index;

            var PhongThi = _dsPhongThi[indexDgv];
            Form_NhapDiemTheoPhong form = new Form_NhapDiemTheoPhong(PhongThi);
            form.Show();
        }
    }
}
