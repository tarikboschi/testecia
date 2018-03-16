namespace TesteSeusConhecimentos.Entities
{
    public class Relationship : DtoBase
    {
        public virtual int IdRelationship { get; set; }
        public virtual int IdUser { get; set; }
        public virtual int IdEnterprise { get; set; }

        public Relationship() { }

        public Relationship(int idUser, int idEnterprise)
        {
            this.IdUser = idUser;
            this.IdEnterprise = idEnterprise;
        }
    }
}