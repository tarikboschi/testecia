using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class CompanyMap : ClassMap<Company>
    {


        public CompanyMap()
        {
            Id(c => c.IdCompany);
            Map(c => c.Name);
            Map(c => c.StreetAddress);
            Map(c => c.City);
            Map(c => c.State);
            Map(c => c.ZipCode);
            Map(c => c.CorporateActivity);

            //HasManyToMany(x => x.Users)
            //.Table("UserCompany")
            //.ParentKeyColumn("IdCompany")
            //.ChildKeyColumn("IdUser")
            //.LazyLoad()
            //.Cascade.SaveUpdate();

            
            Table("TesteSeusConhecimentos.CompanyData");


        }

    }
}
