using DAO.Entities;
using System.Collections.Generic;
using static DAO.DAOService.DAOThongKe;


namespace WEB.Models
{
    public class ThongKeModel
    {
        //--------------- TK thi sinh
        public string tenTrinhDoTK { get; set; }
        public List<thisinh> kq_TK_thisinh { get; set; }

        //--------------- TK phong thi
        public List<phongthi> kq_TK_phongthi { get; set; }

        //-------------- Tk khoa thi
        public List<khoathi> kq_TK_khoathi { get; set; }
    }
}
