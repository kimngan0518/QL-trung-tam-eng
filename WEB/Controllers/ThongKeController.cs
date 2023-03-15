using DAO.DAOService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    public class ThongKeController : Controller
    {
        DAOThongKe dao = new DAOThongKe();
        DAOTrinhDo daoTD = new DAOTrinhDo();

        public IActionResult ThongKe_PhongThi(string? tenTrinhDoTK)
        {
            ViewBag.DSTrinhDo = daoTD.GetAll();

            ViewBag.DSPhong = dao.GetPhongs();
            ViewBag.total = 0;
            if (!String.IsNullOrEmpty(tenTrinhDoTK)) // loc theo ten trinh do
            {

                var model = new Models.ThongKeModel()
                {
                    kq_TK_phongthi = dao.GetPhongTheoTrinhDo(tenTrinhDoTK.ToString()).ToList()
                };

                return View(model);

            }
            else
            {
                //hien thi tat ca sinh theo theo tat ca trinh do
                var model = new Models.ThongKeModel()
                {

                    kq_TK_phongthi = dao.GetPhongs().ToList()

                };

                return View(model);
            }


           
        }

        
        public IActionResult ThongKe_ThiSinh(string? tenTrinhDoTK)
        {
            ViewBag.DSTrinhDo = daoTD.GetAll();

            ViewBag.DSThiSinh = dao.GetThiSinhs();
            ViewBag.total = 0;

            if (!String.IsNullOrEmpty(tenTrinhDoTK)) // loc theo ten trinh do
            {

                var model = new Models.ThongKeModel()
                {
                    kq_TK_thisinh = dao.GetThiSinhTheoTrinhDo(tenTrinhDoTK.ToString()).ToList()
                };

                 return View(model);
              
            
            }
            else
            {
                //hien thi tat ca sinh theo theo tat ca trinh do
                var model = new Models.ThongKeModel()
                {

                    kq_TK_thisinh = dao.GetThiSinhs().ToList()


                };

                return View(model);
            }

        }

        public IActionResult ThongKe_KhoaThi(string? tenTrinhDoTK)
        {
            ViewBag.DSTrinhDo = daoTD.GetAll();

            ViewBag.DSKhoaThi = dao.GetKhoaThi();
            ViewBag.total = 0;

            if (!String.IsNullOrEmpty(tenTrinhDoTK)) // loc theo ten trinh do
            {
                
                var model = new Models.ThongKeModel()
                {
                  
                    kq_TK_khoathi = dao.GetKhoaThiTheoTrinhDo(tenTrinhDoTK.ToString()).ToList()
                };

                return View(model);

            }
            else
            {

                //hien thi tat ca sinh theo theo tat ca trinh do
                var model = new Models.ThongKeModel()
                {

                    kq_TK_khoathi = dao.GetKhoaThi().ToList()

                };

                return View(model);
            }



        }
    }
}
