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
        private IMapper Mapper { get; }
        private IUnitOfWork UnitOfWork { get; }

        public UpdateContractHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.GetValidationResult();

            var contract = await UnitOfWork.Contracts.GetById(request.Id);

            if (contract is null)
            {
                request.GetValidationResult().Errors
                    .Add(new ValidationFailure("Id", "Contract not found"));

                return request.GetValidationResult();
            }

            Mapper.Map(request, contract);

            UnitOfWork.Contracts.Update(contract);

            await UnitOfWork.Commit();

            return request.GetValidationResult();
        }
    }
}
