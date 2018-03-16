using System.Collections.Generic;
using System.Linq;
using NHibernate;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;

namespace TesteSeusConhecimentos.Infra
{
    public class RelationshipRepository<T> : Repository<T> where T : DtoBase
    {
        public RelationshipRepository() { }

        public IList<I> GetFunc<I>(System.Linq.Expressions.Expression<System.Func<I, bool>> ex)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<I>().Where(ex) select e).ToList();
            }
        }
    }
}