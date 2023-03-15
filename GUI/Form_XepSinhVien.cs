using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.DAOService;
using DAO.Entities;
namespace GUI
{
    public partial class Form_XepSinhVien : Form
    {
        DAOThiSinh _daoThiSinh = null;
        List<ThiSinhPhong> thiSinhPhong = null;
        DAOPhongThi _daoTaoPhong = null;
        List<KetQua> listKetQua = null;
        

        public int idPhongThi = Form_PhongThiThiSinh.idP; // lấy mã bên phòng thi
        public String tPhong = Form_PhongThiThiSinh.tPhong;
        public Form_XepSinhVien()
        {
            InitializeComponent();
            _daoThiSinh = new DAOThiSinh();
            _daoTaoPhong = new DAOPhongThi();
           
            
            getListThiSinh(idPhongThi);
        }

        private void Form_XepSinhVien_Load(object sender, EventArgs e)
        {

        }
        public void getListThiSinh(int maPhongThi)
        {
            thiSinhPhong = _daoThiSinh.getAllThiSinhThamGia();
            PhongThi pt = _daoTaoPhong.GetById(maPhongThi);
            if (_daoThiSinh.getAllThiSinh(maPhongThi) != null)
            {
                dataGVXepSV.DataSource = _daoThiSinh.getAllThiSinh(maPhongThi);
            }
            if (thiSinhPhong.Count() > 0)
            {
                // lấy sv không trùng
                cbSinhVien.DataSource = thiSinhPhong.Select(ht => ht.hoTen).Distinct().ToList();
                ThiSinhPhong td = thiSinhPhong[cbSinhVien.SelectedIndex];
                txtSBD.Text = td.tenTrinhDo + idPhongThi;
            }
            txtTenPhong.Text = tPhong;
           
        }

        private void btnXepPhong_Click(object sender, EventArgs e)
        {
            
            try
            {
                KetQua kq = new KetQua();
                if(_daoThiSinh.countThiSinh(idPhongThi) > 35)
                {
                    MessageBox.Show("Phòng này đã đủ thí sinh. Vui lòng xếp phòng khác");
                }
                else
                {
                    if (cbSinhVien.SelectedItem != null && txtTenPhong != null && txtSBD != null)
                    {
                        ThiSinhPhong k = thiSinhPhong[cbSinhVien.SelectedIndex];
                        kq.ID = k.id;
                        kq.maPhong = idPhongThi;
                        kq.sbd = txtSBD.Text;
                        listKetQua = _daoTaoPhong.getListKetQuai();

                        _daoTaoPhong.themThiSinhVaoPhongThi(kq);
                        getListThiSinh(idPhongThi);
                        MessageBox.Show("Xếp phòng thành công!");
                        ThiSinh ts = _daoThiSinh.getById(kq.ID);
                        ts.status = "1";// 1 là xếp phòng rồi.....2 là chưa xếp
                        if( ts!= null)
                        {
                            _daoThiSinh.updateThiSinh(ts);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Không nhập đủ dữ liệu!!Xếp phòng không thành công!");
                    }
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Thí sinh này đã được xếp phòng hoặc chưa đăng ký!!!! .Xếp phòng không thành công!");

            }
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThiSinhPhong td = thiSinhPhong[cbSinhVien.SelectedIndex];
            txtSBD.Text = td.tenTrinhDo + idPhongThi; ;
        }
    }

    
    
}
