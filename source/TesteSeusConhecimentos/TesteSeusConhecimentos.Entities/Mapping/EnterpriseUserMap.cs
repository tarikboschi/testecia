using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class EnterpriseUserMap : ClassMap<EnterpriseUser>
    {


        public EnterpriseUserMap()
        {
            Id(c => c.IdEnterpriseUser);
            Map(c => c.IdEnterprise);
            Map(c => c.IdUser); 

            Table("TesteSeusConhecimentos.EnterpriseUserData");
        }

    }





}
