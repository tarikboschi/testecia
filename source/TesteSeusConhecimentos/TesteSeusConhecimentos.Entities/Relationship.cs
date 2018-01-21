namespace TesteSeusConhecimentos.Entities
{
    public class Relationship
    {
        public virtual int IdRelationship { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual User User { get; set; }

        public Relationship()
        {

        }

        public Relationship(int idRelationship, Enterprise enterprise, User user)
        {
            this.IdRelationship = idRelationship;
            this.Enterprise = enterprise;
            this.User = user;
        }

        public virtual bool IsNew()
        {
            return this.IdRelationship == 0;
        }
    }
}
