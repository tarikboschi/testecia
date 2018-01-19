using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Company
    {
        public virtual int IdCompany { get; set; }
        public virtual string Name { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CorporateActivity { get; set; }

        //public virtual IList<User> Users { get; set; }

        public Company()
        {

        }

        public Company(
            int idcompany,
            string name, 
            string streetaddress, 
            string city, 
            string state, 
            string zipcode, 
            string corporateactivity)
        {
            this.IdCompany = idcompany;
            this.Name = name;
            this.StreetAddress = streetaddress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;
            this.CorporateActivity = corporateactivity;
        }

        public virtual bool IsNew()
        {
            return this.IdCompany == 0;
        }
    }
}
