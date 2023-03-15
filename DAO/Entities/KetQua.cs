using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class KetQua
    {
      
        [MaxLength(12, ErrorMessage = "Số CMND/CCCD không hợp lệ")]
        public string ID { get; set; }
        [ForeignKey(nameof(ID))]
        public virtual ThiSinh thiSinh {get;set;}

       
        public int maPhong { get; set; }
        [ForeignKey(nameof(maPhong))]
        public virtual PhongThi phongThi { get; set; }

        public string sbd { get; set; }
        public float diemNghe { get; set; }
        public float diemNoi { get; set; }
        public float diemDoc { get; set; }
        public float diemViet { get; set; }
    }
}
