using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class EnterpriseUserVwMap : ClassMap<EnterpriseUserVw>
    {


        public EnterpriseUserVwMap()
        {

            Id(c => c.IdEnterpriseUser);
            Map(c => c.EnterpriseName);
            Map(c => c.IdEnterprise);
            Map(c => c.UserName);
            Map(c => c.IdUser);

            Table("TesteSeusConhecimentos.vw_EnterprisesUsers");
        }

    }
}
