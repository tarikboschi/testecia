using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public class EnterpriseXUserRepository : BaseRepository<EnterpriseXUser>, IEnterpriseXUserRepository
    {
        public override void Save(EnterpriseXUser obj)
        {
            if (obj.IsNew())
            {
                Add(obj);
            }
            else
            {
                Update(obj);
            }
        }
    }
}
