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
    public class RelationshipRepository : IRelationshipRepository
    {
        public RelationshipRepository() { }

        public IList<Relationship> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Relationship>() select e).ToList();
            }
        }

        public Relationship GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Relationship>(id);
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
                        Relationship relationShip = session.Get<Relationship>(id);
                        if (relationShip != null)
                        {
                            session.Delete(relationShip);
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

        public void Save(Relationship relationShip)
        {
            if (relationShip.IsNew())
                Add(relationShip);
            else
                Update(relationShip);
        }

        private void Add(Relationship relationShip)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(relationShip);
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

        private void Update(Relationship relationShip)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(relationShip);
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
    }
}
