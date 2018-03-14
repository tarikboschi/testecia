using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    class RelationshipMap : ClassMap<Relationship>
    {

        public RelationshipMap()
        {
            Id(r => r.IdRelationship);
            Map(r => r.IdUser);
            Map(r => r.IdEnterprise);
        
            Table("[TesteSeusConhecimentos].[RelationshipData]");

           

        }
    }
}
