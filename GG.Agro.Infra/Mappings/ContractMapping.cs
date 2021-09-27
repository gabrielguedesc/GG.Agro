using GG.Agro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GG.Agro.Infra.Mappings
{
    internal class ContractMapping : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("contracts");

            builder.HasKey(x => x.Id);
        }
    }
}
