using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class RelationShip
    {
        public virtual int IdUser { get; set; }
        public virtual int IdCompany { get; set; }

        public RelationShip()
        {

        }

        public RelationShip(int iduser, int idcompany)
        {
            this.IdCompany = idcompany;
            this.IdUser = iduser;
        }

        public virtual bool IsNew()
        {
            bool rt = false;

            if (this.IdUser == 0 && this.IdCompany == 0)
            {
                rt = true;
            }
            return rt;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            RelationShip relationship = obj as RelationShip;
            if (relationship == null)
                return false;
            if (IdCompany == relationship.IdCompany && IdUser == relationship.IdUser)
                return true;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (IdUser + "|" + IdCompany).GetHashCode();
        }
    }
}
