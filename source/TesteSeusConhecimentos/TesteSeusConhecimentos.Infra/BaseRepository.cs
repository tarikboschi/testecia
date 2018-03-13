using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public abstract class BaseRepository<T> where T : class
    {
        public void Delete(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        T obj = session.Get<T>(id);
                        if (obj != null)
                        {
                            session.Delete(obj);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar o registro: " + e.Message);
                    }
                }
            }
        }

        public IList<T> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<T>() select e).ToList();
            }
        }

        public T GetById(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<T>(id);
            }
        }

        public void Add(T obj)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(obj);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir o registro: " + e.Message);
                    }
                }
            }
        }

        public void Update(T obj)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(obj);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar o registro: " + e.Message);
                    }
                }
            }
        }

        public abstract void Save(T obj);
    }
}
