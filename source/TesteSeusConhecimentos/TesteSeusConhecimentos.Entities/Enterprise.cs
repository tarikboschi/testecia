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
        public virtual string CorporateActivity { get; set; }

        public virtual IList<User> Users { get; set; }

        public Enterprise()
        {

        }

        public Enterprise(int idEnterprise, string streetAdress, string city, string state, string zipCode, string corporateActivity)
        {
            this.IdEnterprise = idEnterprise;
            this.StreetAdress = streetAdress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.CorporateActivity = corporateActivity;
        }

        public virtual bool IsNew()
        {
            return this.IdEnterprise == 0;
        }
    }
}
