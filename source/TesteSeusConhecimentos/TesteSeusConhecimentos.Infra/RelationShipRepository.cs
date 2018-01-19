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
    public class RelationShipRepository : IRelationShipRepository
    {
        private static IList<RelationShip> RelationShips;

        public RelationShipRepository()
        {
        }


        public IList<RelationShip> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<RelationShip>() select e).ToList();
            }
        }

        public object GetView()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (
                    from e in session.Query<RelationShip>()
                    join c in session.Query<Company>() on e.IdCompany equals c.IdCompany
                    join u in session.Query<User>() on e.IdUser equals u.IdUser
                    select new
                    {
                        iduser = e.IdUser, // or pc.ProdId
                        nameUser = u.Name,
                        idcompany = e.IdCompany,
                        nameCompany = c.Name
                        // other assignments
                    }).ToList();
            }
        }

        public RelationShip GetById(int IdCompany, int IdUser)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<RelationShip>() select e)
                        .Where(c => c.IdCompany == IdCompany && c.IdUser == IdUser).First();
            }
        }


        public void Delete(int IdCompany, int IdUser)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        RelationShip RelationShip = this.GetById(IdCompany, IdUser);

                        if (RelationShip != null)
                        {
                            session.Delete(RelationShip);
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

        public void Save(RelationShip RelationShip)
        {
            //if (RelationShip.IsNew())
            Add(RelationShip);
            //else
            //Update(RelationShip);
        }


        private void Add(RelationShip RelationShip)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(RelationShip);
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


        //private void Update(RelationShip RelationShip)
        //{
        //    using (ISession session = FluentSessionFactory.abrirSession())
        //    {
        //        using (ITransaction transacao = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Update(RelationShip);
        //                transacao.Commit();
        //            }
        //            catch (Exception e)
        //            {
        //                if (!transacao.WasCommitted)
        //                {
        //                    transacao.Rollback();
        //                }
        //                throw new Exception("Erro ao atualizar Relacionamento: " + e.Message);
        //            }
        //        }
        //    }
        //}

    }
}
