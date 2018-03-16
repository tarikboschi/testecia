using System;
using System.Collections.Generic;

namespace TesteSeusConhecimentos.Domain
{
    public interface IRepository<T> : IDisposable
    {
        IList<I> GetAll<I>();
        I GetById<I>(int id);
        void Delete(int id);
        void Save(T user);
    }
}