using DAO.Context;
using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOService
{
    public class DAOTraCuu
    {
        public ApplicationContext context = new ApplicationContext();

        public DAOTraCuu()
        {

        }

        public List<KetQuaViewModel> tracuuTheoTenSDT(string Ten, string SDT)
        {
            List<KetQuaViewModel> list = new List<KetQuaViewModel>();
            List<KetQua> ketquaList = context.KetQua.ToList();
            List<ThiSinh> thisinhList = context.ThiSinh.ToList();
            List<PhongThi> phongList = context.PhongThi.ToList();
            List<KhoaThi> khoaList = context.KhoaThi.ToList();

            var results = from ts in thisinhList
                          where ts.sdt == SDT && ts.hoTen == Ten
                          join kq in ketquaList on ts.ID equals kq.ID
                          join ph in phongList on kq.maPhong equals ph.maPhong
                          join kh in khoaList on ph.maKhoaThi equals kh.maKhoaThi
                          select new KetQuaViewModel
                          {
                              hoten = ts.hoTen,
                              tenkhoathi = kh.tenKhoaThi,
                              tenphongthi = ph.tenPhong,
                              sbd = kq.sbd,
                              diemnghe = kq.diemNghe,
                              diemnoi = kq.diemNoi,
                              diemdoc = kq.diemDoc,
                              diemviet = kq.diemViet
                          };

            return list = results.ToList();
        }

        public List<KetQuaViewModel> tracuuTheoSBD(string sbd, int makhoathi)
        {
            List<KetQuaViewModel> list = new List<KetQuaViewModel>();
            List<KetQua> ketquaList = context.KetQua.ToList();
            List<ThiSinh> thisinhList = context.ThiSinh.ToList();
            List<PhongThi> phongList = context.PhongThi.ToList();
            List<KhoaThi> khoaList = context.KhoaThi.ToList();

            var result = from kh in khoaList
                         where kh.maKhoaThi == makhoathi
                         join ph in phongList on kh.maKhoaThi equals ph.maKhoaThi
                         join kq in ketquaList on ph.maPhong equals kq.maPhong
                         join ts in thisinhList on kq.ID equals ts.ID
                         where kq.sbd == sbd
                         select new KetQuaViewModel
                         {
                             hoten = ts.hoTen,
                             tenkhoathi = kh.tenKhoaThi,
                             tenphongthi = ph.tenPhong,
                             sbd = kq.sbd,
                             diemnghe = kq.diemNghe,
                             diemnoi = kq.diemNoi,
                             diemdoc = kq.diemDoc,
                             diemviet = kq.diemViet
                         };
            return list = result.ToList();

        }

        public List<ThiSinhByPhong> traCuuThiSinhByPhong(int maKT, int maphong)
        {
            var result = (from p in context.PhongThi
                          join kq in context.KetQua on p.maPhong equals kq.maPhong
                          join ts in context.ThiSinh on kq.ID equals ts.ID
                          join td in context.TrinhDo on p.maTrinhDo equals td.maTrinhDo
                          where p.maPhong == maphong && p.maKhoaThi == maKT
                          select new ThiSinhByPhong
                          {
                              maPhong = p.maPhong,
                              maKT = p.maKhoaThi,
                              hoten = ts.hoTen,
                              gioitinh = ts.gioiTrinh,
                              ngaysinh = ts.ngaySinh,
                              noisinh = ts.noiSinh,
                              trinhdo = td.tenTrinhDo,
                              sbd = kq.sbd,
                              sdt = ts.sdt
                          });
            return result.ToList();
        }
        public class KetQuaViewModel
        {
            public string hoten { get; set; }
           
            public string tenkhoathi { get; set; }
            public string tenphongthi { get; set; }
            public string sbd { get; set; }
            public float diemnghe { get; set; }
            public float diemnoi { get; set; }
            public float diemdoc { get; set; }
            public float diemviet { get; set; }
        }

        public class ThiSinhByPhong
        {
            public String hoten { get; set; }
            public bool gioitinh { get; set; }
            public DateTime ngaysinh { get; set; }
            public string noisinh { get; set; }
            public String trinhdo { get; set; }
            public String sdt { get; set; }
            public int maPhong { get; set; }
            public int maKT { get; set; }
            public String sbd { get; set; }

        }
    }
}
