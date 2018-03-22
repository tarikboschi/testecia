using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class EnterpriseUserVw
    {
        public virtual int IdEnterpriseUser { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual string EnterpriseName { get; set; }
        public virtual int IdUser { get; set; }
        public virtual string UserName { get; set; }


        public EnterpriseUserVw()
        {

        }

        public virtual bool IsNew()
        {
            return this.IdEnterpriseUser == 0;
        }
    }
}

