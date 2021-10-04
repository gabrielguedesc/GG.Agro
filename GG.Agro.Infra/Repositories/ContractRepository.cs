using GG.Agro.Domain.Entities;
using GG.Agro.Infra.Abstractions;
using GG.Agro.Infra.Contexts;

namespace GG.Agro.Infra.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        private AgroContext agroContext;

        public ContractRepository(AgroContext agroContext) : base(agroContext)
        {

        }
    }
}
