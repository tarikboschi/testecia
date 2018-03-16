using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;

namespace TesteSeusConhecimentos.Infra
{
    public class Repository<T> : IRepository<T> where T : DtoBase
    {
        public Repository() { }

        public IList<I> GetAll<I>()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<I>() select e).ToList();
            }
        }


        public I GetById<I>(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<I>(id);
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
                        throw new Exception("Erro ao deletar usuário: " + e.Message);
                    }
                }
            }
        }

        public void Save(T obj)
        {
            if (obj.IsNew())
                Add(obj);
            else
                Update(obj);
        }


        private void Add(T obj)
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
                        throw new Exception("Erro ao inserir usuário: " + e.Message);
                    }
                }
            }
        }


        private void Update(T obj)
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
                        throw new Exception("Erro ao atualizar usuário: " + e.Message);
                    }
                }
            }
        }

        public void Dispose()
        {
            /*TODO: need imp ...*/
        }
    }
}