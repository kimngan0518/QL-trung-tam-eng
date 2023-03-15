using DAO.DAOService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Entities;
using System.Threading.Tasks;
using static DAO.DAOService.DAOTraCuu;

namespace WEB.Controllers
{
    public class TraCuuController : Controller
    {
        DAOTraCuu daoTraCuu = new DAOTraCuu();
        DAOKhoaThi daoKhoaThi = new DAOKhoaThi();
        DAOPhongThi daoPhongThi = new DAOPhongThi();

        public IActionResult tracuuThongTin(string hoten, string sdt)
        {           
                var model = new Models.TraCuuModel()
                {
                    listKetQuaTraCuu = daoTraCuu.tracuuTheoTenSDT(hoten, sdt)                    
                };
                return View(model);                 
        }

        public IActionResult xemGiayChungNhan(string sbd, int makhoathi)
        {
            ViewBag.DSKhoathi = daoKhoaThi.GetAll().ToList();

               // int makhoathiSearch = (int)makhoathi;
                var model = new Models.TraCuuModel()
                {
                    listKetQuaTraCuu = daoTraCuu.tracuuTheoSBD(sbd, makhoathi)
                };
                return View(model);   
                

                

        }

        public IActionResult TraCuuDanhSachThiSinh( int makhoathi, int maPhong)
        {
            ICollection<KhoaThi> khoaThis = daoKhoaThi.GetAll().ToList();
            ViewBag.khoaThis = khoaThis;
            ViewBag.phongThis = daoPhongThi.GetAll().ToList();

            var model = new Models.TraCuuModel()
            {
                thiSinhByPhongs = daoTraCuu.traCuuThiSinhByPhong(makhoathi, maPhong)
            };
            return View(model);
        }

    }
}
