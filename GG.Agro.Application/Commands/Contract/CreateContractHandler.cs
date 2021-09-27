using AutoMapper;
using FluentValidation.Results;
using GG.Agro.Infra.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GG.Agro.Application.Commands.Contract
{
    public class CreateContractHandler : IRequestHandler<CreateContractCommand, ValidationResult>
    {
        private IMapper Mapper { get; }
        private IUnitOfWork UnitOfWork { get; }

        public CreateContractHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.GetValidationResult();

            var contract = Mapper.Map<Domain.Entities.Contract>(request);

            await UnitOfWork.Contracts.Add(contract);
            await UnitOfWork.Commit();

            return request.GetValidationResult();
        }
    }
}
