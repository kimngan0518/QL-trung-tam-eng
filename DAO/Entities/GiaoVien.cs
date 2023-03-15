using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class GiaoVien
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int maGV { get; set; }
        [Required(ErrorMessage = "Tên nhân viên không được bỏ trống")]
        public string tenGV { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ngaySinh { get; set; }

        public List<CoiThi> dsCoiThi { get; set; }

    }
}
