using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class EnterpriseMap : ClassMap<Enterprise>
    {
        public EnterpriseMap()
        {
            Id(x => x.IdEnterprise);
            Map(x=> x.StreetAdress);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.ZipCode);
            Map(x => x.CorporateActivity);
            Table("TesteSeusConhecimentos.EnterpriseData");

            HasManyToMany(x => x.Users)
                .Cascade.All()
                .Table("TesteSeusConhecimentos.EnterpriseXUserData");
        }
    }
}
