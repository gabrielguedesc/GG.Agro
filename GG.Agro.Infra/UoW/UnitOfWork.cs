using GG.Agro.Infra.Abstractions;
using GG.Agro.Infra.Contexts;
using GG.Agro.Infra.Repositories;
using System;
using System.Threading.Tasks;

namespace GG.Agro.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private AgroContext agroContext;
        private Lazy<IContractRepository> contractLazy;
        public IContractRepository Contracts => contractLazy.Value;

        public UnitOfWork(AgroContext agroContext)
        {
            this.agroContext = agroContext;
            contractLazy = new(() => new ContractRepository(agroContext));
        }

        public async Task Commit()
            => await agroContext.SaveChangesAsync();
    }
}
