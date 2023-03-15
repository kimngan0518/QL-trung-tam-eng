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
    public partial class Form_ThiSinh : Form
    {
        public DAOThiSinh _daoThiSinh;
        public DAOKhoaThi _daoKhoaThi;
        public DAOTrinhDo _daoTrinhDo;
        public ICollection<ThiSinh> _dsThiSinh;
        public ICollection<KhoaThi> _dsKhoaThi;
        public ICollection<TrinhDo> _dsTrinhDo;
        public Form_ThiSinh()
        {
            InitializeComponent();
            _daoThiSinh = new DAOThiSinh();
            _daoKhoaThi = new DAOKhoaThi();
            _daoTrinhDo = new DAOTrinhDo();
            _dsThiSinh = _daoThiSinh.GetAll();
            _dsKhoaThi = _daoKhoaThi.GetAll();
            _dsTrinhDo = _daoTrinhDo.GetAll();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void LoadKhoaThi()
        {

            if(_dsKhoaThi.Where(item => item.ngayThi > DateTime.Now).ToArray().Count() != 0)
            {
                
                comboBox2.Items.AddRange(_dsKhoaThi.Where(item => item.ngayThi > DateTime.Now).ToArray());
                comboBox2.DisplayMember = "tenKhoaThi";
                comboBox2.ValueMember = "maKhoaThi";
                comboBox5.Text = _dsKhoaThi.Last().tenKhoaThi;
                comboBox5.Items.AddRange(_dsKhoaThi.ToArray());
                comboBox5.DisplayMember = "tenKhoaThi";
                comboBox5.ValueMember = "maKhoaThi";
            }

         

         
        }

        private void LoadTrinhDo()
        {
            comboBox4.Items.Clear();
            _dsTrinhDo = _daoTrinhDo.GetAll();
            comboBox4.Items.AddRange(_dsTrinhDo.ToArray());
            comboBox4.DisplayMember = "tenTrinhDo";
            comboBox4.ValueMember = "maTrinhDo";
        }

        private void LoadThiSinh()
        {
            dataGridView1.AutoGenerateColumns = false;
            //gắn cứng cho số cột của table là 4
            dataGridView1.ColumnCount = 8;
            List<String> propertyName = new List<string> { "ID", "hoTen","getGioiTinh", "ngaySinh", "noiSinh", "ngayCap","sdt","email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            dataGridView1.DataSource = _dsThiSinh.ToArray();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            var thiSinh = _dsThiSinh.Where(item => item.ID == textBox2.Text).FirstOrDefault();

            var khoaThi = _dsKhoaThi.Where(item => item.tenKhoaThi == comboBox5.Text).FirstOrDefault();
            comboBox2.Text = khoaThi.tenKhoaThi.ToString();
            var catThi = thiSinh.dsThamGia.Where(item => item.maKhoaThi == khoaThi.maKhoaThi).FirstOrDefault().trangThai;
            var tmp = "Sáng";
            if (catThi == false)
                tmp = "Chiều";
            comboBox3.Text = tmp;
            var maTrinhDo = thiSinh.dsThamGia.Where(item => item.maKhoaThi == khoaThi.maKhoaThi).FirstOrDefault().maTrinhDo;
            comboBox4.Text = _dsTrinhDo.Where(item => item.maTrinhDo == maTrinhDo).FirstOrDefault().tenTrinhDo;      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hoten = textBox1.Text;
            var combo1 = comboBox1.Text;
            var gioiTinh = false;
            if (combo1.Equals("Nam"))
                gioiTinh = true;
            var ngaySinh = dateTimePicker1.Value;
            var id = textBox2.Text;
            var ngayCap = dateTimePicker2.Value;
            var noiSinh = textBox3.Text;
            var sdt = textBox4.Text;
            var email = textBox5.Text;
            var khoaThi = comboBox2.Text;
            var maKhoaThi = _dsKhoaThi.Where(item => item.tenKhoaThi == khoaThi).FirstOrDefault().maKhoaThi;
            var ngayThi = _dsKhoaThi.Where(item => item.tenKhoaThi == khoaThi).FirstOrDefault().ngayThi;
            if (ngayThi < DateTime.Now)
            {
                MessageBox.Show("Khóa thi này đã thi");
            }
            else
            {
                var cathi = comboBox3.Text;
                var trinhDo = comboBox4.Text;
                var maTrinhDo = _dsTrinhDo.Where(item => item.tenTrinhDo == trinhDo).FirstOrDefault().maTrinhDo;
                var thiSinh = new ThiSinh { ID = id, hoTen = hoten, gioiTrinh = gioiTinh, ngaySinh = ngaySinh, noiSinh = noiSinh, ngayCap = ngayCap, email = email, sdt = sdt };
                var boolCaThi = false;
                if (cathi.Equals("Sáng"))
                    boolCaThi = true;

                ValidationContext context = new ValidationContext(thiSinh, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                StringBuilder stringBuilder = new StringBuilder();
                if (!Validator.TryValidateObject(thiSinh, context, errors, true))
                {
                    foreach (ValidationResult error in errors)
                        stringBuilder.Append(error + "\n");
                    MessageBox.Show(stringBuilder.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var duplicate = _daoThiSinh.GetById(thiSinh.ID);
                    if (duplicate != null)
                    {
                        if (duplicate.dsThamGia.Any(item => item.maKhoaThi == maKhoaThi))
                        {
                            MessageBox.Show("Thí sinh này đã đăng kí thi khóa này ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            duplicate.dsThamGia.Add(new ThamGia { maKhoaThi = maKhoaThi, ID = id, maTrinhDo = maTrinhDo, trangThai = boolCaThi });
                            _daoThiSinh.Update(duplicate);
                        }
                    }
                    else
                    {
                        thiSinh.dsThamGia = new List<ThamGia>();
                        thiSinh.dsThamGia.Add(new ThamGia { maKhoaThi = maKhoaThi, ID = id, maTrinhDo = maTrinhDo, trangThai = boolCaThi });
                        var add = _daoThiSinh.Add(thiSinh);
                        if (cathi.Equals("Sáng"))
                            boolCaThi = true;
                        if (add == true)
                        {
                            MessageBox.Show("Thêm thí sinh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
                            //thay đổi header
                            for (int index = 0; index < dataGridView1.ColumnCount; index++)
                            {
                                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
                            }

                            dataGridView1.DataSource = _dsThiSinh.ToArray();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thí sinh thất bại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            
        }

        private void Form_ThiSinh_Load(object sender, EventArgs e)
        {
            LoadThiSinh();
            LoadKhoaThi();
            LoadTrinhDo();
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(new String[] { "Sáng", "Chiều" });
            comboBox1.Items.AddRange(new String[] { "Nam", "Nữ" });
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hello = (KhoaThi)comboBox5.SelectedItem;
            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            dataGridView1.DataSource = _dsThiSinh.Where(item => item.dsThamGia.Any(x => x.maKhoaThi == hello.maKhoaThi)).ToArray();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            var hello = textBox6.Text;
            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            dataGridView1.DataSource = _dsThiSinh.Where(item => item.hoTen.Contains(hello)).ToArray();
        }
    }
}
