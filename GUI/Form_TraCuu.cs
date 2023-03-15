using DAO.DAOService;
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
    public partial class Form_TraCuu : Form
    {
        public DAOTraCuu daoTraCuu;
        public Form_TraCuu()
        {
            InitializeComponent();
            daoTraCuu = new DAOTraCuu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtHoten.Text.Trim();
            string sdt = txtSdt.Text.Trim();          

            if(String.IsNullOrEmpty(ten) || String.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Nhập thiếu thông tin!", "Lưu ý");
            }    
            else
            {
                if(daoTraCuu.tracuuTheoTenSDT(ten, sdt) == null)
                //Clear the binding.
                dgvKQTraCuu.DataSource = null;
                //không cho nó tự generate
                dgvKQTraCuu.AutoGenerateColumns = false;
                //gắn cứng cho số cột của table là 8
                dgvKQTraCuu.ColumnCount = 8;
                //danh sách các thuộc tính cần hiển thị trên table
                List<String> propertyName = 
                    new List<string> { "hoTen","tenkhoathi", "tenphongthi", "sbd", "diemnghe", "diemnoi", "diemdoc", "diemviet" };

                for (int index = 0; index < dgvKQTraCuu.ColumnCount; index++)
                {
                    dgvKQTraCuu.Columns[index].DataPropertyName = propertyName.ToArray().GetValue(index).ToString();
                }

                dgvKQTraCuu.DataSource = daoTraCuu.tracuuTheoTenSDT(ten, sdt);               
            }    
        }
     
    }
}
