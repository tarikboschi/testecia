using System.Collections.Generic;

namespace TesteSeusConhecimentos.Domain
{
    public interface IBaseRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        void Delete(int id);

        /// <summary>
        /// Cria ou altera as informações da entidade
        /// </summary>
        /// <param name="enterprise"></param>
        void Save(T enterprise);
    }
}
