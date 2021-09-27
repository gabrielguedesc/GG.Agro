using FluentValidation;
using FluentValidation.Results;
using GG.Agro.Core.Application;
using MediatR;

namespace GG.Agro.Application.Commands.Contract
{
    public class CreateContractCommand : Command, IRequest<ValidationResult>
    {
        public string Name { get; set; }

        public CreateContractCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            SetValidationResult(new CreateContractCommandValidations().Validate(this));

            return GetValidationResult().IsValid;
        }
    }

    public class CreateContractCommandValidations : AbstractValidator<CreateContractCommand>
    {
        public CreateContractCommandValidations()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Contract name is required");
        }
    }
}
