using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;
using NHibernate.Transform;


namespace TesteSeusConhecimentos.Infra
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        public EnterpriseRepository()
        { }

        public IList<Enterprise> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Enterprise>() select e).ToList();
            }
        }

        public System.Collections.IList GetRelationchip()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                string q = @"select e.CorporateActivy,rtrim(u.Name + ' ' + u.LastName) as Name,
                                Convert(varchar,e.IdEnterprise) +';'+ Convert(varchar,u.IdUser) as Chave
                                from TesteSeusConhecimentos.EnterpriseData as e 
                                inner join EnterprisesToUsers eu
                                on e.IdEnterprise = eu.Enterprise_id
								inner join TesteSeusConhecimentos.UserData as u
								on u.IdUser = eu.User_id";
                var x = (session.CreateSQLQuery(q)).List();
                return x;
            }
        }

        public void DeleteRelationchip( string idEnterprise, string idUser)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        if (idEnterprise != null || idUser != null)
                        {
                            string q = @"delete from EnterprisesToUsers where Enterprise_id = :idEmp and User_id = :idUsu";
                            session.CreateSQLQuery(q).SetParameter("idEmp", idEnterprise).SetParameter("idUsu", idUser).ExecuteUpdate();
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

        public Enterprise GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Enterprise>(id);
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
                        throw new Exception("Erro ao deletar empreendimento: " + e.Message);
                    }
                }
            }
        }

        public void Save(Enterprise enterprise)
        {
            if (enterprise.IsNew())
                Add(enterprise);
            else
                Update(enterprise);
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
                        throw new Exception("Erro ao inserir empreendimento: " + e.Message);
                    }
                }
            }
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
                        throw new Exception("Erro ao atualizar empreendimento: " + e.Message);
                    }
                }
            }
        }
    }
}
