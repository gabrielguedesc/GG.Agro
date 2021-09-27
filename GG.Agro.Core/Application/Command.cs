using FluentValidation.Results;

namespace GG.Agro.Core.Application
{
    public abstract class Command
    {
        private ValidationResult ValidationResult;

        public abstract bool IsValid();

        public ValidationResult GetValidationResult()
            => ValidationResult;

        public void SetValidationResult(ValidationResult validationResult)
            => ValidationResult = validationResult;
    }
}
