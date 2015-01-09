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
    public class UserRepository : IUserRepository
    {
        //private static IList<User> users;

        public UserRepository()
        {          
        }

        
        public IList<User> GetAll()
        {
           using (ISession session = FluentSessionFactory.abrirSession())
           {             
               return (from e in session.Query<User>() select e).ToList();
           }
        }

      
        public User GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<User>(id);
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
                        User user = session.Get<User>(id);
                        if (user != null)
                        {
                            session.Delete(user);
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

        public void Save(User user)
        {
            if (user.IsNew())
                Add(user);
            else
                Update(user);
        }

       
        private void Add(User user)
        {
            using (ISession session = FluentSessionFactory.abrirSession()) 
            {
                using (ITransaction transacao = session.BeginTransaction()) 
                {
                    try
                    {
                        session.Save(user);
                        transacao.Commit();
                    }
                    catch (Exception e) 
                    {
                        if(!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir usuário: "+e.Message);
                    }
                }
            }
        }


        private void Update(User user)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(user);
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
