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
using System.Data.SqlClient;



namespace GUI
{
    public partial class Form_NhapDiemTheoPhong : Form
    {
        public List<KetQua> _ketqua;
        public DAOKetQua _daoKetQua;
        public PhongThi phong;
        int indexDgv = 0;
        
        public Form_NhapDiemTheoPhong(PhongThi phong)
        {
            this.phong = phong;
            _daoKetQua = new DAOKetQua();
            _ketqua = _daoKetQua.getKetQuaTheoPhong(phong).ToList();
           
            InitializeComponent();
        }
        public Form_NhapDiemTheoPhong()
        {
            InitializeComponent();
        }

        private void Form_NhapDiemTheoPhong_Load(object sender, EventArgs e)
        {
            _daoKetQua = new DAOKetQua();
            var ketqua = _daoKetQua.getKetQuaTheoPhong(phong).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 7;

            List<String> lName = new List<string> { "ID", "maPhong","sbd", "diemNghe", "diemNoi", "diemDoc", "diemViet" };
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = lName.ToArray().GetValue(index).ToString();
            }

            dataGridView1.DataSource = ketqua;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            indexDgv = dataGridView1.CurrentRow.Index;
            var rs = _ketqua[indexDgv];

            textBox1.Text = rs.ID;
            textBox2.Text = rs.sbd;
            textBox3.Text = rs.diemNghe.ToString();
            textBox4.Text = rs.diemNoi.ToString();
            textBox5.Text = rs.diemDoc.ToString();
            textBox6.Text = rs.diemViet.ToString();

            textBox1.Enabled = false;
            textBox2.Enabled = false;

          /*  if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns.IndexOf(dataGridView1.Columns[indexDgv]))
                {
                    DataGridViewCell cell = dataGridView1[indexDgv, e.RowIndex];
                    dataGridView1.CurrentCell = cell;
                    dataGridView1.BeginEdit(true);
                }
            }*/
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            indexDgv = dataGridView1.CurrentRow.Index;
            var rs = _ketqua[indexDgv];

            if(rs.diemNghe== float.Parse(textBox3.Text) && rs.diemNoi == float.Parse(textBox4.Text)
                && rs.diemDoc == float.Parse(textBox5.Text) && rs.diemViet == float.Parse(textBox6.Text))
            {
                MessageBox.Show("Không có gì để cập nhật", "Thông báo");
            }
            else {
                rs.ID = textBox1.Text;
                rs.sbd = textBox2.Text;
                rs.diemNghe = float.Parse(textBox3.Text);
                rs.diemNoi = float.Parse(textBox4.Text);
                rs.diemDoc = float.Parse(textBox5.Text);
                rs.diemViet = float.Parse(textBox6.Text);

                _daoKetQua.Update(rs);
                var ketqua = _daoKetQua.getKetQuaTheoPhong(phong).ToList();
                dataGridView1.DataSource = ketqua;
                dataGridView1.Update();
                dataGridView1.Refresh();
            }

        }

        // button luu bang
        private void button1_Click(object sender, EventArgs e)
        {
                     
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    
                    var rs = _ketqua[i];
                    rs.diemNghe = float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    rs.diemNoi = float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    rs.diemDoc = float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    rs.diemViet = float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    _daoKetQua.Update(rs);

                }

                var ketqua = _daoKetQua.getKetQuaTheoPhong(phong).ToList();
                dataGridView1.DataSource = ketqua;
                dataGridView1.Update();
                dataGridView1.Refresh();
                MessageBox.Show("Thanh cong");
            
        }
    }
}
