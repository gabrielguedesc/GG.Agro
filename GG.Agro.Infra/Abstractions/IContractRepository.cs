using GG.Agro.Core.Abstractions.Data;
using GG.Agro.Domain.Entities;

namespace GG.Agro.Infra.Abstractions
{
    public interface IContractRepository : IReadRepository<Contract>, IWriteRepository<Contract>
    {

    }
}
