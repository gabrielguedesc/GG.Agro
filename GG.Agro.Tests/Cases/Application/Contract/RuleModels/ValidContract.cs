using Bogus;
using GG.Agro.Application.Commands.Contract;
using GG.Agro.Tests.Core;

namespace GG.Agro.Tests.Cases.Application.Contract.RuleModels
{
    public class ValidContract : RuleModel<CreateContractCommand>
    {
        public ValidContract(Faker bogus) 
            : this(bogus, _name: null) { }

        protected ValidContract(Faker bogus, string _name = null)
            : base(new CreateContractCommand(name: _name ?? bogus.Name.FullName())) { }
    }
}
