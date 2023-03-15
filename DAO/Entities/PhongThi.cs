using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class PhongThi
    {
        [Key]
        public int maPhong { get; set; }
        public string tenPhong { get; set; }
        // true - thi sáng, false - thi chiều
        public bool caThi { get; set; }
       
        public int maTrinhDo { get; set; }

        [ForeignKey(nameof(maTrinhDo))]
        public virtual TrinhDo trinhDo { get; set; }

        public int maKhoaThi { get; set; }
        [ForeignKey(nameof(maKhoaThi))]
        public virtual KhoaThi khoaThi { get; set; }

        public List<CoiThi> dsCoiThi { get; set; }

        public virtual List<KetQua> dsKetQua { get; set; }

        public String getKhoaThi { get { return khoaThi.tenKhoaThi; }}
        public String getTrinhDo { get { return trinhDo.tenTrinhDo; } }
        public String getCatThi { get { return caThi == true ? "Sáng" : "Chiều"; } }
    }
}
