using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Domain
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Delete(int id);
        void Save(T obj);
    }
}
