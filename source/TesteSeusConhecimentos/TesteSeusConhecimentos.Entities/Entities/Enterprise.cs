using System.Collections;


namespace TesteSeusConhecimentos.Entities
{
    public class Enterprise
    {

        #region Properties
        public virtual int IdEnterprise { get; set; }
        public virtual string StreetAdress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CorporateActivity { get; set; }
        public virtual IList Users { get; set; }

        public Enterprise()
        {

        }
        public Enterprise(int idInterprise, string streetAdress, string city, string state, string zipCode, string corporateActivity)
        {
            IdEnterprise = idInterprise;
            StreetAdress = streetAdress;
            City = city;
            State = state;
            ZipCode = zipCode;
            CorporateActivity = corporateActivity;
        }
        #endregion

        public virtual bool IsNew() => this.IdEnterprise == 0;
    }
}
