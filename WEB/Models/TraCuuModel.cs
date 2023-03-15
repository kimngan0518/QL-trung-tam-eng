using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DAO.DAOService.DAOTraCuu;

namespace WEB.Models
{
    public class TraCuuModel
    {
        public List<KetQuaViewModel> listKetQuaTraCuu { get; set; }
        public int makhoathi { get; set; }
        public string sbd { get; set; }

        public List<ThiSinhByPhong> thiSinhByPhongs { get; set; }
        public int maPhong { get; set; }

    }
}
