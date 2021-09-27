using GG.Agro.Infra.Abstractions;
using GG.Agro.Infra.Contexts;
using GG.Agro.Infra.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GG.Agro.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private AgroContext AgroContext { get; }
        private Lazy<IContractRepository> ContractLazy { get; }
        public IContractRepository Contracts => ContractLazy.Value;

        public UnitOfWork(AgroContext agroContext)
        {
            AgroContext = agroContext;
            ContractLazy = new(() => new ContractRepository(agroContext));
        }

        public async Task Commit()
            => await AgroContext.SaveChangesAsync();
    }
}
