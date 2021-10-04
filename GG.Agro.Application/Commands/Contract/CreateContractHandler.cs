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
        private IMapper mapper;
        private IUnitOfWork unitOfWork;

        public CreateContractHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.GetValidationResult();

            var contract = mapper.Map<Domain.Entities.Contract>(request);

            await unitOfWork.Contracts.Add(contract);
            await unitOfWork.Commit();

            return request.GetValidationResult();
        }
    }
}
