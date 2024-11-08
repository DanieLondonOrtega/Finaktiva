using FluentValidation;

namespace Finaktiva.API.Models.Validators
{
    public class EventLogsModelValidator : AbstractValidator<EventLogsModel>
    {
        public EventLogsModelValidator()
        {
            RuleFor(x => x.IdType)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Date)
                .NotEmpty()
                .NotNull();
        }
    }
}
