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
    public partial class Form_XepPhong : Form
    {
        public DAOTrinhDo _daoTrinhDo;
        public DAOKhoaThi _daoKhoaThi;
        public DAOThiSinh _daoThiSinh;
        public int maKhoaThi ;
        public int maTrinhDo ;
        public bool caThiBool = true;
        public ICollection<ThiSinh> _dsThiSinh;
        public ICollection<KhoaThi> _dsKhoaThi;
        public ICollection<TrinhDo> _dsTrinhDo;
        public ICollection<ThiSinh> _dsFilter;
        public Form_XepPhong()
        {
            InitializeComponent();
            _daoThiSinh = new DAOThiSinh();
            _daoKhoaThi = new DAOKhoaThi();
            _daoTrinhDo = new DAOTrinhDo();
            _dsThiSinh = _daoThiSinh.GetAll();
            _dsKhoaThi = _daoKhoaThi.GetAll();
            _dsTrinhDo = _daoTrinhDo.GetAll();
            maKhoaThi = _dsKhoaThi.Last().maKhoaThi;
            maTrinhDo = _dsTrinhDo.Last().maTrinhDo;
            
            if (_dsThiSinh != null)
            {
                _dsFilter = _dsThiSinh.Where(item => !item.dsKetQua.Any(x => x.ID == item.ID)).ToList();
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<KetQua> listKetQua = new List<KetQua>();
            List<PhongThi> listPhongThi = _daoKhoaThi.GetById(maKhoaThi).dsPhongThi.Where(item => item.maTrinhDo==maTrinhDo&& item.caThi== caThiBool).ToList();
            MessageBox.Show((dataGridView1.RowCount % 30).ToString());
            if (dataGridView1.RowCount / 30 >= listPhongThi.Count())
            {
                MessageBox.Show("Không đủ phòng để thực hiện chia phòng");
            }
            else
            {
                if(_dsFilter.Any(item => item.dsThamGia.Any(x => x.maKhoaThi != maKhoaThi || x.maTrinhDo != maTrinhDo || x.trangThai != caThiBool)==true) ){
                    MessageBox.Show("Kiểm tra lại dữ liệu đi");
                }
                else
                {
                    for(int i = 1;i<= dataGridView1.RowCount; i++)
                    {

                    }   
                }
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form_XepPhong_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            //gắn cứng cho số cột của table là 4
            dataGridView1.ColumnCount = 8;
            comboBox1.Items.AddRange(_dsKhoaThi.ToArray());
            comboBox1.DisplayMember = "tenKhoaThi";
            comboBox1.ValueMember = "maKhoaThi";
            comboBox2.Items.AddRange(_dsTrinhDo.ToArray());
            comboBox2.DisplayMember = "tenTrinhDo";
            comboBox2.ValueMember = "maTrinhDo";
            comboBox3.Items.AddRange(new String[] { "Sáng", "Chiều" });
            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }

            dataGridView1.DataSource = _dsFilter;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var khoaThi = (KhoaThi)comboBox1.SelectedItem;
            maKhoaThi = khoaThi.maKhoaThi;
            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            dataGridView1.DataSource = _dsFilter.Where(item => item.dsThamGia.Any(x => x.maKhoaThi == maKhoaThi && x.maTrinhDo == maTrinhDo && x.trangThai == caThiBool)).ToArray();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var trinhDo = (TrinhDo)comboBox2.SelectedItem;
            maTrinhDo = trinhDo.maTrinhDo;
            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            dataGridView1.DataSource = _dsFilter.Where(item => item.dsThamGia.Any(x => x.maKhoaThi == maKhoaThi && x.maTrinhDo == maTrinhDo && x.trangThai == caThiBool)).ToArray();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var caThi = comboBox3.SelectedItem;
            List<String> propertyName = new List<string> { "ID", "hoTen", "getGioiTinh", "ngaySinh", "noiSinh", "ngayCap", "sdt", "email" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            var tmp = false;
            if (caThi.ToString().Equals("Sáng"))
                tmp = true;
            caThiBool = tmp;
            dataGridView1.DataSource = _dsFilter.Where(item => item.dsThamGia.Any(x => x.maKhoaThi == maKhoaThi && x.maTrinhDo == maTrinhDo && x.trangThai == caThiBool)).ToArray();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_TaoPhong form = new Form_TaoPhong();
            form.ShowDialog();
        }
    }
}
