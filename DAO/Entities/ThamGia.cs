using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class ThamGia
    {
        
        public int maKhoaThi { get; set; }
        [ForeignKey(nameof(maKhoaThi))]
        public virtual KhoaThi khoaThi { get; set; }

     
        [MaxLength(12, ErrorMessage = "Số CMND/CCCD không hợp lệ")]
        public string ID { get; set; }
        [ForeignKey(nameof(ID))]
        public virtual ThiSinh thiSinh { get; set; }

        public DateTime ngayThamGia { get; set; }
        
        public int maTrinhDo { get; set; }
        [ForeignKey(nameof(maTrinhDo))]
        public virtual TrinhDo trinhDo { get; set; }

        public bool trangThai { get; set; }
    }
}
