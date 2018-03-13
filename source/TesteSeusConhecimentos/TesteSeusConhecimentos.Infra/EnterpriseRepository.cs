using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public class EnterpriseRepository : BaseRepository<Enterprise>, IEnterpriseRepository
    {
        public override void Save(Enterprise enterprise)
        {
            if (enterprise.IsNew())
            {
                Add(enterprise);
            }
            else
            {
                Update(enterprise);
            }
        }
    }
}