using DAO.Context;
using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOService
{
    public class DAOTrinhDo : DAOBase<TrinhDo>
    {
        ApplicationContext _context;

        public DAOTrinhDo()
        {
            _context = new ApplicationContext();
        }

        public bool Add(TrinhDo entity)
        {
            _context.TrinhDo.Add(entity);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(TrinhDo entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<TrinhDo> GetAll()
        {
            return _context.TrinhDo.ToList();
        }

        public TrinhDo GetById(int id)
        {
            throw new NotImplementedException();
        }


        public bool Update(TrinhDo entity)
        {
            throw new NotImplementedException();
        }
    }
}
