using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface ICompanyRepository
    {
        IList<Company> GetAll();
        Company GetById(int id);
        void Delete(int id);
        /// <summary>
        /// Cria ou altera as informações da empresa
        /// </summary>
        /// <param name="company"></param>
        void Save(Company company);
    }
}
