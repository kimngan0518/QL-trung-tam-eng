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
    public class DAOKhoaThi : DAOBase<KhoaThi>
    {
        ApplicationContext _context;

        public DAOKhoaThi()
        {
            _context = new ApplicationContext();
        }

        public bool Add(KhoaThi entity)
        {
            _context.KhoaThi.Add(entity);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(KhoaThi entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<KhoaThi> GetAll()
        {
            return _context.KhoaThi.Include("dsPhongThi").ToList();
        }

        public KhoaThi GetById(int id)
        {
            return _context.KhoaThi.Find(id);
        }

        public KhoaThi GetByMouth(DateTime date)
        {
            return _context.KhoaThi.Where(item => item.ngayThi.Month == date.Month).FirstOrDefault();
        }

        public bool Update(KhoaThi entity)
        {
            throw new NotImplementedException();
        }
    }
}
