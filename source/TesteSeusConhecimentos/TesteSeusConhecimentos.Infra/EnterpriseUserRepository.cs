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
    public class EnterpriseUserRepository : IEnterpriseUserRepository
    {
        private static IList<EnterpriseUser> enterprisesUsers;

        public EnterpriseUserRepository()
        {
        }


        public IList<EnterpriseUserVw> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (
                     
                    from e in session.Query<EnterpriseUserVw>() 
                    select e 
                    ).ToList();
            }
        }


        public EnterpriseUser GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<EnterpriseUser>(id);
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
                        EnterpriseUser enterpriseUser = session.Get<EnterpriseUser>(id);
                        if (enterpriseUser != null)
                        {
                            session.Delete(enterpriseUser);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar Relacionamento: " + e.Message);
                    }
                }
            }
        }

        public void Save(EnterpriseUser enterpriseUser)
        {
            if (enterpriseUser.IsNew())
                Add(enterpriseUser);
            else
                Update(enterpriseUser);
        }


        private void Add(EnterpriseUser enterpriseUser)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(enterpriseUser);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Relacionamento: " + e.Message);
                    }
                }
            }
        }


        private void Update(EnterpriseUser enterpriseUser)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(enterpriseUser);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar Relacionamento: " + e.Message);
                    }
                }
            }
        }

    }
}
