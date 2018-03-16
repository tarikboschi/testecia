using System.Collections.Generic;

namespace TesteSeusConhecimentos.Entities
{
    public class User : DtoBase
    {
        public virtual int IdUser { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual ICollection<Enterprise> Enterprises { get; set; }

        public User() { Enterprises = new List<Enterprise> { }; }

        public User(int idUser, string name, string lastName, string email)
        {
            this.IdUser = idUser;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
        }

        public override bool IsNew()
        {
            return this.IdUser == 0;
        }
    }
}