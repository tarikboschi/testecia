using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Enterprise
    {
        public virtual int IdEnterprise { get; set; }
        public virtual string StreetAdress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CorporateActivy { get; set; }
        public virtual IList<User> Users { get; set; }

        public Enterprise()
        {
            this.Users = new List<User>();
        }

        public Enterprise(int idCod, string end, string cid, string est, string cep, string ativ)
        {
            this.IdEnterprise = idCod;
            this.StreetAdress = end;
            this.City = cid;
            this.State = est;
            this.ZipCode = cep;
            this.CorporateActivy = ativ;
        }

        public virtual bool IsNew()
        {
            return this.IdEnterprise == 0;
        }

    }
}
