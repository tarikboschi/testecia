using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationShipMap : ClassMap<RelationShip>
    {


        public RelationShipMap()
        {
            Id(c => c.IdUser);
            Id(c => c.IdCompany);
            
            CompositeId()
            .KeyProperty(c => c.IdUser, "IdUser")
            .KeyProperty(c => c.IdCompany, "IdCompany");

            Table("TesteSeusConhecimentos.RelationShipData");
        }


    }
}
