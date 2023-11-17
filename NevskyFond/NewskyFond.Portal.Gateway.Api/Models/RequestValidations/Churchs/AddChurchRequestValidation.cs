using FluentValidation;
using NewskyFond.Portal.Gateway.Api.Models.Requests.Churchs;

namespace NewskyFond.Portal.Gateway.Api.Models.RequestValidations.Churchs
{
    public class AddChurchRequestValidation : AbstractValidator<AddChurchRequest>
    {
        public AddChurchRequestValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Наименование религиозного учреждения должно быть заполнено");

            RuleFor(e => e.DateCreation)
                .NotEmpty()
                .WithMessage("Дата создания религиозного учреждения должна быть заполнена")
                .Must(e => e <= DateTime.Now).WithMessage("Дата создания не может быть в будущем"); ;
        }
    }
}