using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class TrinhDo
    {
        [Key]
        public int maTrinhDo { get; set; }
        [Required(ErrorMessage = "Tên trình độ không được bỏ trống")]
        public string tenTrinhDo { get; set; }

        
    }
}
