using DAO.Context;
using DAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOService
{
    public class DAOPhongThi : DAOBase<PhongThi>
    {
        ApplicationContext _context;

        public DAOPhongThi()
        {
            _context = new ApplicationContext();
        }

        public bool Add(PhongThi entity)
        {
           
            _context.PhongThi.Add(entity);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(PhongThi entity)
        {
            _context.PhongThi.Remove(entity);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public ICollection<PhongThi> GetAll()
        {
            return _context.PhongThi.Include("dsCoiThi").Include("trinhDo").Include("khoaThi").ToList();

                    
        }

        public PhongThi GetById(int id)
        {
           
            return _context.PhongThi.Find(id);
            // return _context.PhongThi.Find(id);
        }

        public bool Update(PhongThi entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }
        // lấy ds phòng thi kèm sbd
        public List<DataPhongThi> getAllPhongThis()
        {
            List<DataPhongThi> listPhongs = new List<DataPhongThi>();
            // lay phong kem sbd trong table kq=> join table PhongThi va KetQua
            var phongs = (from k in _context.KhoaThi
                          join p in _context.PhongThi on k.maKhoaThi equals p.maKhoaThi
                          join td in _context.TrinhDo on p.maTrinhDo equals td.maTrinhDo
                          where (p.maKhoaThi == k.maKhoaThi) && (p.maTrinhDo == td.maTrinhDo)
                          select new
                          {
                              maPhong = p.maPhong,
                              tenPhong = p.tenPhong,
                              caThi = p.caThi,
                              tenTrinhDo = td.tenTrinhDo,
                              tenKhoaThi = k.tenKhoaThi,
                          }).ToList();
            foreach (var ttPhong in phongs)
            {
                DataPhongThi data = new DataPhongThi();
                data.maPhong = ttPhong.maPhong;
                data.tenPhong = ttPhong.tenPhong;
                if (ttPhong.caThi == true)
                {
                    data.caThi = "Sáng";
                }
                else
                {
                    data.caThi = "Chiều";
                }
                data.tenTrinhDo = ttPhong.tenTrinhDo;
                data.tenKhoaThi = ttPhong.tenKhoaThi;
                listPhongs.Add(data);
            }
            return listPhongs;
        }
        //  // lấy list Kết quả để lên GUI check cái ID thí sinh trong Ketqua
        public List<KetQua> getListKetQuai()
        {
            return _context.KetQua.ToList();
        }
        // thêm thí sinh vao phòng
        public void themThiSinhVaoPhongThi(KetQua kq)
        {

            KetQua ketQua = new KetQua()
            {
                ID = kq.ID,
                maPhong = kq.maPhong,
                sbd = kq.sbd
              
            };
            _context.Add(ketQua);
            _context.SaveChanges();
        }
        public class DataPhongThi
        {
            public int maPhong { get; set; }
            public String tenPhong { get; set; }
            // true thi sáng - false thi chiều
            public String caThi { get; set; }
            public String tenTrinhDo { get; set; }
            public String tenKhoaThi { get; set; }
        }
    }
}
