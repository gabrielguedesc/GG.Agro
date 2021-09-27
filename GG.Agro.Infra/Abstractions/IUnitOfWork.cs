using System.Threading;
using System.Threading.Tasks;

namespace GG.Agro.Infra.Abstractions
{
    public interface IUnitOfWork
    {
        IContractRepository Contracts { get; }

        Task Commit();
    }
}
