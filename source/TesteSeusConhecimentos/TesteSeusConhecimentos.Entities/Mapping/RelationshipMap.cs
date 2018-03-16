using FluentNHibernate.Mapping;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationshipMap : ClassMap<Relationship>
    {
        public RelationshipMap()
        {
            Id(c => c.IdRelationship);
            Map(c => c.IdUser);
            Map(c => c.IdEnterprise);
            Table("TesteSeusConhecimentos.RelationshipData");
        }
    }
}