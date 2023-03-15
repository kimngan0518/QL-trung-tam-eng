using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOService
{
    public interface DAOBase<T> where T : class
    {
        public ICollection<T> GetAll();
        public T GetById(int id);
        public bool Add(T entity);
        public bool Delete(T entity);
        public bool Update(T entity);
    }
}
