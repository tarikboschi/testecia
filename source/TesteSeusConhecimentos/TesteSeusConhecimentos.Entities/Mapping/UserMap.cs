using FluentNHibernate.Mapping;

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