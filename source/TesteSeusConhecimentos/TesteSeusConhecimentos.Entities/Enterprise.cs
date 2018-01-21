using System.Collections.Generic;
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
            this.Users = new List<User>();
        }

        public Enterprise(int identerprise, string streetAdress, string city, string state, string zipcode, string corporateActivity)
        {
            this.IdEnterprise = identerprise;
            this.StreetAdress = streetAdress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;
            this.CorporateActivity = corporateActivity;
        }
        
        public virtual bool IsNew()
        {
            return this.IdEnterprise == 0;
        }
    }
}
