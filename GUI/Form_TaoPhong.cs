using DAO.DAOService;
using DAO.Entities;
using GUI.Properties;
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
    public partial class Form_TaoPhong : Form
    {
        public DAOKhoaThi _daoKhoaThi;
        public DAOTrinhDo _daoTrinhDo;
        public DAOGiaoVien _daoGiaoVien;
        public DAOPhongThi _daoPhongThi;
        public ICollection<KhoaThi> _dsKhoaThi;
        public ICollection<TrinhDo> _dsTrinhDo;
        public ICollection<GiaoVien> _dsGiaoVien;
        public ICollection<PhongThi> _dsPhongThi;
        public List<CoiThi> _dsCoiThi;
        public List<GiaoVien> _dsGiaoVienCoiThi;
        public int selected = -1;

        public Form_TaoPhong()
        {
            InitializeComponent();
            _daoKhoaThi = new DAOKhoaThi();
            _daoTrinhDo = new DAOTrinhDo();
            _daoGiaoVien = new DAOGiaoVien();
            _daoPhongThi = new DAOPhongThi();
            _dsPhongThi = _daoPhongThi.GetAll();
            _dsCoiThi = new List<CoiThi>();
            _dsGiaoVienCoiThi = new List<GiaoVien>();
        }

        private void Form_TaoPhong_Load(object sender, EventArgs e)
        {
            LoadKhoaThi();
            LoadCaThi();
            LoadTrinhDo();
            LoadGiaoVien();
            LoadPhongThi();
        }

        private void LoadCaThi()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new String[] { "Sáng", "Chiều" });
        }


        private void LoadTrinhDo()
        {
            comboBox2.Items.Clear();
            _dsTrinhDo = _daoTrinhDo.GetAll();
            comboBox2.Items.AddRange(_dsTrinhDo.ToArray());
            comboBox2.DisplayMember = "tenTrinhDo";
            comboBox2.ValueMember = "maTrinhDo";
        }


        private void LoadKhoaThi()
        {
            comboBox3.Items.Clear();
            _dsKhoaThi = _daoKhoaThi.GetAll();
            comboBox3.Items.AddRange(_dsKhoaThi.ToArray());
            comboBox3.DisplayMember = "tenKhoaThi";
            comboBox3.ValueMember = "maKhoaThi";
        }

        private void LoadGiaoVien()
        {
            comboBox4.Items.Clear();
            _dsGiaoVien = _daoGiaoVien.GetAll();
            comboBox4.Items.AddRange(_dsGiaoVien.ToArray());
            comboBox4.DisplayMember = "tenGV";
        }

        private void LoadPhongThi()
        {
            dataGridView2.AutoGenerateColumns = false;
            //gắn cứng cho số cột của table là 4
            dataGridView2.ColumnCount = 4;
            List<String> propertyName = new List<string> { "tenPhong", "getCatThi", "getTrinhDo", "getKhoaThi" };
            //thay đổi header
            for (int index = 0; index < dataGridView2.ColumnCount; index++)
            {
                dataGridView2.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
           
            dataGridView2.DataSource = _dsPhongThi.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_TaoKhoaThi form = new Form_TaoKhoaThi(this, this._daoKhoaThi);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            String tenPhong = textBox1.Text;
            TrinhDo trinhDo = (TrinhDo)comboBox2.SelectedItem;
            var tenTrinhDo = trinhDo.tenTrinhDo;
            if (tenPhong.Contains("XX")==true){
                tenPhong = tenPhong.Replace("XX", tenTrinhDo);
            }else{
                tenPhong = tenTrinhDo + "PXX";
            }
            textBox1.Text = tenPhong;
        }


        private void ComboBox3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            String tenPhong = textBox1.Text;
            KhoaThi khoaThi = (KhoaThi)comboBox3.SelectedItem;
            var maKhoaThi = khoaThi.maKhoaThi;
            var dsPhongCuaKhoa = _dsKhoaThi.Where(item => item.maKhoaThi == maKhoaThi).FirstOrDefault().dsPhongThi;
            if (dsPhongCuaKhoa.Count()!=0){
                var max = 1;
                foreach(PhongThi item in dsPhongCuaKhoa){
                    var tmp = item.tenPhong.Split("P");
                    if (max < Int32.Parse(tmp[1])){
                        max = Int32.Parse(tmp[1]); 
                    }
                }
                String maPhong = "";
                max = max + 1;
                if (max < 10)
                    maPhong = "0" + max.ToString();
                else
                    maPhong = max.ToString();

                if (tenPhong.Contains("XX"))
                    tenPhong = tenPhong.Replace("XX", maPhong);
                else
                    tenPhong = "XXP" + maPhong.ToString();
            }
            else{
                if (tenPhong.Contains("XX") == true)
                    tenPhong = tenPhong.Replace("XX", "01");
                else
                    tenPhong = "XXP01";  
            }
            textBox1.Text = tenPhong;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tenPhong = textBox1.Text;
            var caThi = comboBox1.SelectedItem;
            var caThiReal = false;
            if (caThi == null)
            {
                MessageBox.Show("Ca thi không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                if (caThi.ToString().Equals("Sáng")) {
                    caThiReal = true;
                }else{
                    caThiReal = false;
                }
                TrinhDo trinhDo = (TrinhDo)comboBox2.SelectedItem;
                if(trinhDo == null){
                    MessageBox.Show("Trình độ không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else{
                    var maTrinhDo = trinhDo.maTrinhDo;
                    KhoaThi khoaThi = (KhoaThi)comboBox3.SelectedItem;
                    if (khoaThi == null){
                        MessageBox.Show("Khóa thi không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else {
                        var maKhoaThi = khoaThi.maKhoaThi;
                        var phongThi = new PhongThi();
                        phongThi.tenPhong = tenPhong;
                        phongThi.caThi = caThiReal;
                        phongThi.maKhoaThi = maKhoaThi;
                        phongThi.maTrinhDo = maTrinhDo;
                        if (_dsGiaoVienCoiThi.Count() < 2)
                        {
                            MessageBox.Show("Số lượng giáo viên một phòng là 2 người ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var add = _daoPhongThi.Add(phongThi);
                            if (add == true)
                            {
                                _dsPhongThi = _daoPhongThi.GetAll();
                                phongThi.dsCoiThi = new List<CoiThi>();
                                var max = _dsPhongThi.Where(item => item.maPhong == _dsPhongThi.Max(item => item.maPhong)).FirstOrDefault();
                                foreach (var item in _dsGiaoVienCoiThi)
                                {
                                    var coiThi = new CoiThi { maGV = item.maGV, maPhong = max.maPhong };
                                    phongThi.dsCoiThi.Add(coiThi);          
                                }
                                var update = _daoPhongThi.Update(phongThi);
                                if (update == true)
                                {
                                    MessageBox.Show("Thêm phòng thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    _daoPhongThi.Delete(phongThi);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thêm phòng thi thất bại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }     
                        }
                    }
                }
            }       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_ThemGiaoVien form = new Form_ThemGiaoVien(this);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GiaoVien giaoVien = (GiaoVien)comboBox4.SelectedItem;
            if (giaoVien != null)
            {
                if (!_dsCoiThi.Any(item => item.maGV==giaoVien.maGV) && _dsCoiThi.Count()<2)
                {
                    _dsGiaoVienCoiThi.Add(giaoVien);
                    List<String> propertyName = new List<string> { "maGV", "tenGV", "ngaySinh"};
                    //thay đổi header
                    for (int index = 0; index < dataGridView1.ColumnCount; index++)
                    {
                        dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
                    }
                    dataGridView1.DataSource = _dsGiaoVienCoiThi.ToList();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn giáo viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (selected == -1)
            {
                MessageBox.Show("Hãy chọn giáo viên để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                var id = dataGridView1.Rows[selected].Cells[0].Value.ToString();
                if (id != null)
                {
                    _dsCoiThi.Remove(_dsCoiThi.Where(item => item.maGV == Int32.Parse(id)).FirstOrDefault());
                    _dsGiaoVienCoiThi.Remove(_dsGiaoVienCoiThi.Where(item => item.maGV == Int32.Parse(id)).FirstOrDefault());

                    dataGridView1.DataSource = _dsGiaoVienCoiThi.ToList();
                }
                else
                {
                    MessageBox.Show("Không còn giáo viên trong danh sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Invalidate();
            LoadKhoaThi();
            LoadCaThi();
            LoadTrinhDo();
            LoadGiaoVien();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            selected = dataGridView1.Rows[e.RowIndex].Index;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var tenPhong = textBox1.Text;
            var caThi = comboBox1.SelectedItem;
            var caThiReal = false;
            if (caThi == null)
            {
                MessageBox.Show("Ca thi không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (caThi.ToString().Equals("Sáng"))
                {
                    caThiReal = true;
                }
                else
                {
                    caThiReal = false;
                }
                TrinhDo trinhDo = (TrinhDo)comboBox2.SelectedItem;
                if (trinhDo == null)
                {
                    MessageBox.Show("Trình độ không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var maTrinhDo = trinhDo.maTrinhDo;
                    KhoaThi khoaThi = (KhoaThi)comboBox3.SelectedItem;
                    if (khoaThi == null)
                    {
                        MessageBox.Show("Khóa thi không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (_dsGiaoVienCoiThi.Count() < 2)
                        {
                            MessageBox.Show("Số lượng giáo viên một phòng là 2 người ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var phongThi = _dsPhongThi.Where(item => item.tenPhong == tenPhong && item.maKhoaThi == khoaThi.maKhoaThi ).FirstOrDefault();
                            var maKhoaThi = khoaThi.maKhoaThi;
                            phongThi.tenPhong = tenPhong;
                            phongThi.caThi = caThiReal;
                            phongThi.maKhoaThi = maKhoaThi;
                            phongThi.maTrinhDo = maTrinhDo;
                            phongThi.dsCoiThi.Clear();
                            foreach (var item in _dsGiaoVienCoiThi)
                            {
                                var coiThi = new CoiThi { maGV = item.maGV, maPhong = phongThi.maPhong };
                                phongThi.dsCoiThi.Add(coiThi);
                            }
                            var update = _daoPhongThi.Update(phongThi);
                            if (update == true)
                            {
                                MessageBox.Show("Cập nhật phòng thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật phòng thi thất bại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.SelectedIndexChanged -= ComboBox2_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged -= ComboBox3_SelectedIndexChanged;
            dataGridView2.CurrentRow.Selected = true;
            selected = dataGridView2.Rows[e.RowIndex].Index;
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            KhoaThi khoaThi = (KhoaThi)comboBox3.SelectedItem;
            var tenPhong = textBox1.Text;
            var phongThi = _dsPhongThi.Where(item =>item.maKhoaThi == khoaThi.maKhoaThi && item.tenPhong.Equals(tenPhong)).FirstOrDefault();
            _dsGiaoVienCoiThi.Clear();
            foreach (var item in phongThi.dsCoiThi)
            {
                _dsGiaoVienCoiThi.Add(_dsGiaoVien.Where(x => x.maGV == item.maGV).FirstOrDefault());
            }
            List<String> propertyName = new List<string> { "maGV", "tenGV", "ngaySinh" };
            //thay đổi header
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
            }
            dataGridView1.DataSource = _dsGiaoVienCoiThi.ToList();
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            if (!textBox2.Equals(""))
            {
                dataGridView2.DataSource =  _dsPhongThi.Where(item => item.tenPhong.Contains(textBox2.Text)|| item.khoaThi.tenKhoaThi.Contains(textBox2.Text)||item.trinhDo.tenTrinhDo.Contains(textBox2.Text)).ToArray();
            }
            else
            {
                dataGridView2.DataSource = _dsPhongThi.ToArray();
            }
        }


    }
}
