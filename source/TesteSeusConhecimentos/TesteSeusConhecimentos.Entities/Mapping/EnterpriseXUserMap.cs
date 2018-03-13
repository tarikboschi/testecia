using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class EnterpriseXUserMap : ClassMap<EnterpriseXUser>
    {
        public EnterpriseXUserMap()
        {
            Id(x => x.IdEnterpriseXUser);
            Map(x => x.IdEnterprise);
            Map(x => x.IdUser);
            Table("TesteSeusConhecimentos.EnterpriseXUserData");
        }
    }
}
