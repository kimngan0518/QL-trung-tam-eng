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
    public class DAOThiSinh : DAOBase<ThiSinh>
    {
        ApplicationContext _context;
        public ThiSinh thiSinh = null;
        public DAOThiSinh()
        {
          
            _context = new ApplicationContext();
            thiSinh = new ThiSinh();

        }
        public bool Add(ThiSinh entity)
        {
            _context.ThiSinh.Add(entity);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(ThiSinh entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<ThiSinh> GetAll()
        {
            return _context.ThiSinh.Include("dsThamGia").Include("dsKetQua").ToList();
        }

        public ThiSinh GetById(int id)
        {
            return _context.ThiSinh.Find(id);
        }

        public ThiSinh GetById(String id)
        {
            return _context.ThiSinh.Find(id);
        }

        public bool Update(ThiSinh entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }
        public List<DataThiSinh> getAllThiSinh(int maPhong)
        {
            List<DataThiSinh> listThiSinhs = new List<DataThiSinh>();
            // lay phong kem sbd trong table kq=> join table phongd thi va KetQua và thí sinh
            var phongs = (from p in _context.PhongThi
                          join kq in _context.KetQua on p.maPhong equals kq.maPhong
                          join ts in _context.ThiSinh on kq.ID equals ts.ID
                          where (p.maPhong == kq.maPhong) && (kq.ID == ts.ID) && (p.maPhong == maPhong)
                          select new
                          {
                              ID = ts.ID,
                              hoTen = ts.hoTen,
                              gioiTinh = ts.gioiTrinh,
                              ngaySinh = ts.ngaySinh,
                              noiSinh = ts.noiSinh,
                              ngayCap = ts.ngayCap,
                              sdt = ts.sdt,
                              email = ts.email,
                              sbd = kq.sbd
                          }).ToList();
            foreach (var ttThiSinh in phongs)
            {
                DataThiSinh data = new DataThiSinh();
                data.id = ttThiSinh.ID;
                data.hoTen = ttThiSinh.hoTen;
                if (ttThiSinh.gioiTinh == true)
                {
                    data.gioiTinh = "Nữ";
                }
                else
                {
                    data.gioiTinh = "Nam";
                }
                data.ngaySinh = ttThiSinh.ngaySinh;
                data.noiSinh = ttThiSinh.noiSinh;
                data.ngayCap = ttThiSinh.ngayCap;
                data.sdt = ttThiSinh.sdt;
                data.email = ttThiSinh.email;
                data.sbd = ttThiSinh.sbd;
                listThiSinhs.Add(data);
            }
            return listThiSinhs;
        }
        // count student of permanent
        public int countThiSinh(int maPhong)
        {
           
            // lay phong kem sbd trong table kq=> join table phongd thi va KetQua và thí sinh
            var soLuongThiSinh = (from p in _context.PhongThi
                          join kq in _context.KetQua on p.maPhong equals kq.maPhong
                          join ts in _context.ThiSinh on kq.ID equals ts.ID
                          where (p.maPhong == kq.maPhong) && (kq.ID == ts.ID) && (p.maPhong == maPhong)
                          select new
                          {
                              ID = ts.ID,
                              hoTen = ts.hoTen,
                              gioiTinh = ts.gioiTrinh,
                              ngaySinh = ts.ngaySinh,
                              noiSinh = ts.noiSinh,
                              ngayCap = ts.ngayCap,
                              sdt = ts.sdt,
                              email = ts.email,
                              sbd = kq.sbd
                          }).Count();
           
            return soLuongThiSinh;
        }
        // laay tất cả sinh viên trong bảng tham gia
        public List<ThiSinhPhong> getAllThiSinhThamGia()
        {
            List<ThiSinhPhong> listThiSinhs = new List<ThiSinhPhong>();
            // lay phong kem sbd trong table kq=> join table phongd thi va KetQua và thí sinh
            var phongs = (from ts in _context.ThiSinh
                          join tg in _context.ThamGia on ts.ID equals tg.ID
                          join td in _context.TrinhDo on tg.maTrinhDo equals td.maTrinhDo
                          where (ts.ID == tg.ID) && (tg.maTrinhDo == td.maTrinhDo) && ts.status.Equals("2")
                          select new
                          {
                              ID = ts.ID,
                              hoTen = ts.hoTen,
                              tenTrinhDo = td.tenTrinhDo
                          }).ToList();
            foreach (var ttThiSinh in phongs)
            {
                ThiSinhPhong data = new ThiSinhPhong();
                data.id = ttThiSinh.ID;
                data.hoTen = ttThiSinh.hoTen;
                data.tenTrinhDo = ttThiSinh.tenTrinhDo;
                listThiSinhs.Add(data);
            }
            
            return listThiSinhs;
        }

        public ThiSinh getById(String id)
        {
            return _context.ThiSinh.Find(id);
        }
        // update thí sinh trangjthais =1
        public void updateThiSinh(ThiSinh ts)
        {

            // lay thông tin Phòng cần update theo id(Phải lấy được id thì mới update đc)
            var ptUpdate = _context.ThiSinh.SingleOrDefault
                    (x => x.ID == ts.ID);
            // nếu phòng này có thì cập nhật lại thông tin phòng lấy được từ db này thành 
            if (ptUpdate != null)
            {
                ptUpdate.hoTen = ts.hoTen;
                ptUpdate.gioiTrinh = ts.gioiTrinh;
                ptUpdate.ngaySinh = ts.ngaySinh;
                ptUpdate.noiSinh = ts.noiSinh;
                ptUpdate.ngayCap = ts.ngayCap;
                ptUpdate.sdt = ts.sdt;
                ptUpdate.email = ts.email;
                ptUpdate.status = ts.status;
            }
            _context.SaveChanges();
        }
    }
    
   
    public class DataThiSinh
    {
        public String id { get; set; }
        public String hoTen { get; set; }
        // true thi sáng - false thi chiều
        public String gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public String noiSinh { get; set; }
        public DateTime ngayCap { get; set; }
        public String sdt { get; set; }
        public String email { get; set; }
        public String sbd { get; set; }
    }
    // thêm thí sinh vào phòng
    public class ThiSinhPhong
    {
        public String id { get; set; }
        public String hoTen { get; set; }
        // true thi sáng - false thi chiều
       public String tenTrinhDo { get; set; }


    }

}
