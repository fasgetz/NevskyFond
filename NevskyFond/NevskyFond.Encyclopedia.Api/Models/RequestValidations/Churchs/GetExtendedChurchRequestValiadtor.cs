using FluentValidation;
using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;

namespace NevskyFond.Encyclopedia.Api.Models.RequestValidations.Churchs
{
    public class GetExtendedChurchCommentsFilterValidator : AbstractValidator<GetExtendedChurchRequestCommentsFilter>
    {
        public GetExtendedChurchCommentsFilterValidator()
        {
            RuleFor(e => e.PageNumber)
                .NotNull()
                .WithMessage("Параметр должен быть заполнен");

            RuleFor(e => e.PageSize)
                .NotNull()
                .WithMessage("Параметр должен быть заполнен");

            RuleFor(e => e.PageNumber)
                .GreaterThan(0)
                .WithMessage("Параметр должен быть положительным числом");

            RuleFor(e => e.PageSize)
                .GreaterThan(0)
                .WithMessage("Параметр должен быть положительным числом");

            RuleFor(e => e.PageSize)
                .LessThanOrEqualTo(20)
                .WithMessage("Вы не можете получить больше 20 комментариев за один раз");
        }
    }

    public class GetExtendedChurchRequestValiadtor : AbstractValidator<GetExtendedChurchRequest>
    {
        public GetExtendedChurchRequestValiadtor()
        {
            RuleFor(e => e.CommentsFilter)
                .SetValidator(new GetExtendedChurchCommentsFilterValidator())
                .When(e => e.CommentsFilter != null);
        }
    }
}
