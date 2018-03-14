using System.Collections.Generic;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
   public interface IRelationshipRepository
    {

        IList<Relationship> GetAll();
        Relationship GetById(int id);
        void Delete(int id);
        void Save(Relationship relationship);
    }
}
