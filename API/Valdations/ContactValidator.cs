using DataModels;
using FluentValidation;

namespace API.Valdations
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş olamaz");
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100'denb büyük olamaz");
        }
    }
}
