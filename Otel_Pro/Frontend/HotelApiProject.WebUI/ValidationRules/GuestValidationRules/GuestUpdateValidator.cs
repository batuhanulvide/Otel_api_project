using FluentValidation;
using HotelApiProject.WebUI.Dtos.GuestDtos;

namespace HotelApiProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestUpdateValidator:AbstractValidator<GuestUpdateDto>
    {
        public GuestUpdateValidator()
        {
            RuleFor(x => x.TC).NotEmpty().WithMessage("TC bilgisi boş geçilemez").Length(11).WithMessage("TC 11 karakter olmak zorundadır");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Şehir bilgisi en az 3 karakter olmalıdır.").MaximumLength(14).WithMessage("Şehir bilgisi en fazla 14 karakter olabilir.");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage("Doğum tarihi bilgisi boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Ad bilgisi en az 3 karakter olmalıdır.").MaximumLength(30).WithMessage("Ad bilgisi en fazla 30 karakter olabilir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Soyad bilgisi en az 3 karakter olmalıdır.").MaximumLength(30).WithMessage("Soyad bilgisi en fazla 30 karakter olabilir.");
        }
    }
}
