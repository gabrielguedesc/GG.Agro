using Bogus;

namespace GG.Agro.Tests.Cases.Application.Contract.RuleModels
{
    public class ContractWithInvalidName : ValidContract
    {
        public ContractWithInvalidName(Faker bogus)
            : base(bogus, _name: string.Empty) { }
    }
}
