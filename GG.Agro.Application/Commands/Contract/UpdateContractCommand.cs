using FluentValidation;
using FluentValidation.Results;
using GG.Agro.Core.Application;
using MediatR;
using System;

namespace GG.Agro.Application.Commands.Contract
{
    public class UpdateContractCommand : Command, IRequest<ValidationResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override bool IsValid()
        {
            SetValidationResult(new UpdateContractCommandValidations().Validate(this));

            return GetValidationResult().IsValid;
        }
    }

    public class UpdateContractCommandValidations : AbstractValidator<UpdateContractCommand>
    {
        public UpdateContractCommandValidations()
        {
            RuleFor(r => r.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Contract Id was not provided");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Contract name was not provided");
        }
    }
}
