using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IEnterpriseUserRepository
    {
        IList<EnterpriseUserVw> GetAll();
        EnterpriseUser GetById(int id);
        void Delete(int id);
        /// <summary>
        /// Cria ou altera as informações do relacionamento
        /// </summary>
        /// <param name="enterpriseUser"></param>
        void Save(EnterpriseUser enterpriseUser);
    }
}
