using FluentValidation;
using LibraryManagementAPI.Contracts.V1.Requests;

namespace LibraryManagementAPI.Validators
{
    public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");

            RuleFor(x => x.Credits)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.Quantities)
                .GreaterThan(0);
        }
    }
}
