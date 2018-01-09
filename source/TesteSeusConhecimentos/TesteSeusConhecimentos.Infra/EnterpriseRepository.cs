using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public class EnterpriseRepository : IRepository<Enterprise>
    {
        public void Delete(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        Enterprise enterprise = session.Get<Enterprise>(id);
                        if (enterprise != null)
                        {
                            session.Delete(enterprise);
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

        public IList<Enterprise> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Enterprise>() select e).ToList();
            }
        }

        

        public Enterprise GetById(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Enterprise>(id);
            }
        }

        public void Save(Enterprise enterprise)
        {
            if (enterprise.IsNew())
                Add(enterprise);
            else
                Update(enterprise);
        }

        private void Update(Enterprise enterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(enterprise);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar empresa: " + e.Message);
                    }
                }
            }
        }

        private void Add(Enterprise enterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(enterprise);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir empresa: " + e.Message);
                    }
                }
            }
        }
    }

    
}
