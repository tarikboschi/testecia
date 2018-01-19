using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IRelationShipRepository
    {
        IList<RelationShip> GetAll();

        object GetView();

        RelationShip GetById(int IdCompany, int IdUser);
        
        void Delete(int IdCompany, int IdUser);

        void Save(RelationShip relationship);
    }
}
