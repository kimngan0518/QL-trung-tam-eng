using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class CoiThi
    {
        public int maGV {get;set;}
        [ForeignKey(nameof(maGV))]
        public virtual GiaoVien giaoVien { get; set; }

        public int maPhong { get; set; }
        [ForeignKey(nameof(maPhong))]
        public virtual PhongThi phongThi { get; set; }

    }
}
