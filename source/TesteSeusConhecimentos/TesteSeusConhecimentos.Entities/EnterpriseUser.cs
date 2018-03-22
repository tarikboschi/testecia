using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class EnterpriseUser
    {
        public virtual int IdEnterpriseUser { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; } 


        public EnterpriseUser()
        {

        }

        public EnterpriseUser(int IdEnterpriseUser, int IdEnterprise, int IdUser)
        {
            this.IdEnterpriseUser = IdEnterpriseUser;
            this.IdEnterprise = IdEnterprise;
            this.IdUser = IdUser; 
        }

        public virtual bool IsNew()
        {
            return this.IdEnterpriseUser == 0;
        }
    }
}
