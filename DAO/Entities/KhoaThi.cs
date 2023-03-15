using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class KhoaThi
    {
        [Key]
        public int maKhoaThi { get; set; }
        [Required(ErrorMessage = "Tên khóa thi không được bỏ trống")]
        public string tenKhoaThi { get; set; }
        [Required(ErrorMessage = "Ngày thi không được bỏ trống")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ngayThi { get; set; }
        public virtual List<ThamGia> dsThamGia { get; set; }

        public virtual List<PhongThi> dsPhongThi { get; set; }

    }
}
