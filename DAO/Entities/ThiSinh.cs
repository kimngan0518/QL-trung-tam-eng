using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class ThiSinh
    {
        [Key]
        [MaxLength(12,ErrorMessage ="Số CMND/CCCD không hợp lệ")]
        public string ID { get; set; }
        [Required(ErrorMessage ="Họ tên không được bỏ trống")]
        public string hoTen { get; set; }
        // Nam - true, Nữ - false
        public bool gioiTrinh { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ngaySinh { get; set; }
        [Required(ErrorMessage ="Nơi sinh không được bỏ trống")]
        public string noiSinh { get; set; }
        [Required(ErrorMessage ="Ngày cấp không được bỏ trống")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ngayCap { get; set; }
        [MaxLength(10, ErrorMessage = "Số điện thoại không hợp lệ")]
        [Phone(ErrorMessage ="Số điện thoại không hợp lệ")]
        public string sdt { get; set; }
        [Required(ErrorMessage ="Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email { get; set; }
        public string status { get; set; }

        public virtual List<KetQua> dsKetQua { get; set; }
        public virtual List<ThamGia> dsThamGia { get; set; }

        public String getGioiTinh { get { return gioiTrinh == true ? "Nam" : "Nữ"; } }
    }
}
