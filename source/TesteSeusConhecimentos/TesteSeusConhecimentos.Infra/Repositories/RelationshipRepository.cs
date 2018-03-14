using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra.Repositories
{
    public class RelationshipRepository : IRelationshipRepository
    {
        public void Delete(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        Relationship relationship = session.Get<Relationship>(id);
                        if (relationship != null)
                        {
                            session.Delete(relationship);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar relacionamento: " + e.Message);
                    }
                }
            }
        }

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

        public void Save(Relationship relationship)
        {
            if (relationship.IsNew())
                Add(relationship);
            else
                Update(relationship);
        }


        private void Add(Relationship relationship)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(relationship);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir relacionamento: " + e.Message);
                    }
                }
            }
        }


        private void Update(Relationship relationship)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(relationship);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar relacionamento: " + e.Message);
                    }
                }
            }
        }
    }
}
