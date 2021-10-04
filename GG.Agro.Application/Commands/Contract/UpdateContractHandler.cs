using AutoMapper;
using FluentValidation.Results;
using GG.Agro.Infra.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GG.Agro.Application.Commands.Contract
{
    public class UpdateContractHandler : IRequestHandler<UpdateContractCommand, ValidationResult>
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;

        public UpdateContractHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.GetValidationResult();

            var contract = await unitOfWork.Contracts.GetById(request.Id);

            if (contract is null)
            {
                request.GetValidationResult().Errors
                    .Add(new ValidationFailure("Id", "Contract not found"));

                return request.GetValidationResult();
            }

            mapper.Map(request, contract);

            unitOfWork.Contracts.Update(contract);

            await unitOfWork.Commit();

            return request.GetValidationResult();
        }
    }
}
