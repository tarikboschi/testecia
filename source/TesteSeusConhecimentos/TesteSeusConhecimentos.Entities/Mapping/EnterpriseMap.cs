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
            Id(c => c.IdEnterprise);
            Map(c => c.Company);
            Map(c => c.StreetAdress);
            Map(c => c.City);
            Map(c => c.State);
            Map(c => c.ZipCode);
            Map(c => c.CorporateActivity);
            Table("TesteSeusConhecimentos.EnterpriseData");

            HasManyToMany(c => c.Users)
                .Cascade.AllDeleteOrphan()
                .ParentKeyColumn("IdEnterprise")
                .ChildKeyColumn("IdUser")
                .Table("TesteSeusConhecimentos.EmployeeData");
        }
    }
}
