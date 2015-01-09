using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class UserMap: ClassMap<User>
    {


        public UserMap()
        {            
            Id(c => c.IdUser);
            Map(c => c.Name);
            Map(c => c.LastName);
            Map(c => c.Email);
            Table("TesteSeusConhecimentos.UserData");
        }
       
    }
}
