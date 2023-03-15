using DAO.Context;
using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.DAOService
{
    public class DAOGiaoVien : DAOBase<GiaoVien>
    {
        ApplicationContext _context;

        public DAOGiaoVien()
        {
            _context = new ApplicationContext();
        }

        public bool Add(GiaoVien entity)
        {
            _context.GiaoVien.Add(entity);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(GiaoVien entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<GiaoVien> GetAll()
        {
            return _context.GiaoVien.ToList();
        }

        public GiaoVien GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(GiaoVien entity)
        {
            throw new NotImplementedException();
        }
    }
}
