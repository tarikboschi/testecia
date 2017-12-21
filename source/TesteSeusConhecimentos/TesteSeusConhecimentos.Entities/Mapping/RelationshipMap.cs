using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationshipMap : ClassMap<Relationship>
    {
        public RelationshipMap()
        {
            Id(c => c.IdRelationship);
            References(x => x.Enterprise, "IdEnterprise").ForeignKey().Not.LazyLoad();
            References(x => x.User, "IdUser").ForeignKey().Not.LazyLoad();

            Table("TesteSeusConhecimentos.RelationshipData");
        }
    }
}
