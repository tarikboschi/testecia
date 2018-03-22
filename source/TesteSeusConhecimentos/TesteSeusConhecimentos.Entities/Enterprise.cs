using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Enterprise
    {
        public virtual int IdEnterprise { get; set; }
        public virtual string Name { get; set; }
        public virtual string StreetAdress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CorporateActivity { get; set; }

        public Enterprise()
        {

        }

        public Enterprise(int IdEnterprise, string Name, string StreetAdress, string city, string state, string zipCode, string CorporateActivity)
        {
            this.IdEnterprise = IdEnterprise;
            this.Name = Name;
            this.StreetAdress = StreetAdress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.CorporateActivity = CorporateActivity; 
        }

        public virtual bool IsNew()
        {
            return this.IdEnterprise == 0;
        }
    }
}
