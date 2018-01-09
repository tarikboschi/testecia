using System.Collections.Generic;

namespace TesteSeusConhecimentos.Entities
{
    public class Enterprise
    {
        public virtual int IdEnterprise { get; set; }
        public virtual string Company { get; set; }
        public virtual string StreetAdress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CorporateActivity { get; set; }
        public virtual IList<User> Users { get; set; }

        public Enterprise()
        {

        }

        public Enterprise(int idEnterprise, string company, string streetAdress, string city, string state, string zipCode, string corporateActivity)
        {
            this.Company = company;
            this.IdEnterprise = idEnterprise;
            this.StreetAdress = streetAdress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.CorporateActivity = corporateActivity;

            Users = new List<User>();
        }

        public virtual bool IsNew()
        {
            return this.IdEnterprise == 0;
        }
    }
}

        