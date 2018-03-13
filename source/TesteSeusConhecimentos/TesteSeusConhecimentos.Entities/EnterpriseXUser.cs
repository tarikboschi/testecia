using System.Collections.Generic;

namespace TesteSeusConhecimentos.Entities
{
    public class EnterpriseXUser
    {
        public virtual int IdEnterpriseXUser { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; }

        public virtual IList<Enterprise> Enterprises { get; set; }
        public virtual IList<User> Users { get; set; }

        public EnterpriseXUser()
        {

        }

        public EnterpriseXUser(int idEnterpriseXUser, int idEnterprise, int idUser)
        {
            this.IdEnterpriseXUser = idEnterpriseXUser;
            this.IdEnterprise = idEnterprise;
            this.IdUser = idUser;
        }

        public virtual bool IsNew()
        {
            return this.IdEnterpriseXUser == 0;
        }
    }
}
