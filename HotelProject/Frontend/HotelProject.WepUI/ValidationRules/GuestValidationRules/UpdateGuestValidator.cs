using FluentValidation;
using HotelProject.WepUI.Dtos.GuestDto;

namespace HotelProject.WepUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpgradeGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Lütfen en fazla 40 karakter girişi yapınız.");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapınız.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız.");
        }
    }
}
