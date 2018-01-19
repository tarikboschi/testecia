using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;

namespace TesteSeusConhecimentos.Infra
{
    public class CompanyRepository : ICompanyRepository
    {
        //private static IList<Company> Companys;

        public CompanyRepository()
        {          
        }

        
        public IList<Company> GetAll()
        {
           using (ISession session = FluentSessionFactory.abrirSession())
           {             
               return (from e in session.Query<Company>() select e).ToList();
           }
        }

      
        public Company GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Company>(id);
            }
        }

       
        public void Delete(int id) 
        {           

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        Company company = session.Get<Company>(id);
                        if (company != null)
                        {
                            session.Delete(company);
                            transacao.Commit();
                        }                       
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar empresa: " + e.Message);
                    }
                }
            }
        }

        public void Save(Company company)
        {
            if (company.IsNew())
                Add(company);
            else
                Update(company);
        }

       
        private void Add(Company company)
        {
            using (ISession session = FluentSessionFactory.abrirSession()) 
            {
                using (ITransaction transacao = session.BeginTransaction()) 
                {
                    try
                    {
                        session.Save(company);
                        transacao.Commit();
                    }
                    catch (Exception e) 
                    {
                        if(!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir empresa: "+e.Message);
                    }
                }
            }
        }


        private void Update(Company company)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(company);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar usuário: " + e.Message);
                    }
                }
            }
        }
                       
    }
}
