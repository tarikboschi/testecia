using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class ViewRelationShip
    {
        public virtual int IdUser { get; set; }
        public virtual string NameUser { get; set; }
        public virtual int IdCompany { get; set; }
        public virtual string NameCompany { get; set; }
        public ViewRelationShip()
        {

        }
    }
}
