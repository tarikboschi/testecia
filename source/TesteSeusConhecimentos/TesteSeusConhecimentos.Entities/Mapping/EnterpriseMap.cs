using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class EnterpriseMap : ClassMap<Enterprise>
    {
        public EnterpriseMap()
        {
            Id(c => c.IdEnterprise);
            Map(c => c.StreetAdress);
            Map(c => c.City);
            Map(c => c.State);
            Map(c => c.ZipCode);
            Map(c => c.CorporateActivy);
            HasManyToMany(c => c.Users).Cascade.SaveUpdate().Table("EnterprisesToUsers");
            Table("TesteSeusConhecimentos.EnterpriseData");
        }
    }
}
