using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using BUS;
using DAO;
using DAO.Entities;
using System.Text.RegularExpressions;
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
    public partial class Form_PhongThiThiSinh : Form
    {
        DAOPhongThi _daoTaoPhong = null;
        
        // lưu lại id phòng khi double click vào
        public static int idP = 0;
        public static String tPhong = null;
        public Form_PhongThiThiSinh()
        {
            InitializeComponent();
            _daoTaoPhong = new DAOPhongThi();
            getListPhongThi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void getListPhongThi()
        {
            if (_daoTaoPhong.getAllPhongThis() != null)
            {
                dataGVPhong.DataSource = _daoTaoPhong.getAllPhongThis();
            }
        }

        private void dataGVPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idP = Convert.ToInt32(dataGVPhong.CurrentRow.Cells["maPhong"].Value);
            tPhong = Convert.ToString(dataGVPhong.CurrentRow.Cells["tenPhong"].Value);
            Form_XepSinhVien fThiSinh = new Form_XepSinhVien();
            fThiSinh.Show();
        }
    }
}
