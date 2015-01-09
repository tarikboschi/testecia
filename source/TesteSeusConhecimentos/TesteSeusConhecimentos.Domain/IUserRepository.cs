using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User GetById(int id);
        void Delete(int id);
        /// <summary>
        /// Cria ou altera as informações do usuário
        /// </summary>
        /// <param name="user"></param>
        void Save(User user);
    }
}
