namespace TesteSeusConhecimentos.Entities
{
    public class Relationship
    {
        #region Properies
        public virtual int IdRelationship { get; set; }
        public virtual int IdUser { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual User User { get; set; }
        public virtual Enterprise Enterprise { get; set; }


        public Relationship()
        {
        }



        public Relationship(int idRelationship, int idUser, int idEnterprise)
        {
            IdRelationship = idRelationship;
            IdUser = idUser;
            IdEnterprise = idEnterprise;
        }
        #endregion
        public virtual bool IsNew() => this.IdRelationship == 0;
    }
}
