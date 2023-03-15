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
    public class DAOKetQua : DAOBase<KetQua>
    {
        ApplicationContext _context;

        public DAOKetQua()
        {
            _context = new ApplicationContext();
        }
        public bool Update(KetQua entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Add(KetQua entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(KetQua entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<KetQua> GetAll()
        {
            throw new NotImplementedException();
        }

        public KetQua GetById(int maphong) // lay theo ma phong
        {

            return _context.KetQua.Find(maphong);

        }
        public List<KetQua> getKetQuaTheoPhong(PhongThi phong)
        {
            List<KetQua> rs = (from phongthi in _context.PhongThi
                               join kq in _context.KetQua on phongthi.maPhong equals kq.maPhong
                               where kq.maPhong == phong.maPhong
                               select new KetQua
                               {
                                   ID = kq.ID,
                                   maPhong = kq.maPhong,
                                   sbd = kq.sbd,
                                   diemNghe = kq.diemNghe,
                                   diemNoi = kq.diemNoi,
                                   diemDoc = kq.diemDoc,
                                   diemViet = kq.diemViet
                               }).ToList();

            return rs;
        }


    }
}
