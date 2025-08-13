using FluentValidation;
using HotelApiProject.WebUI.Dtos.SendMessageDtos;

namespace HotelApiProject.WebUI.ValidationRules.SendMessageValidationRules
{
    public class SendMessageAddValidator:AbstractValidator<SendMessageAddDto>
    {
        public SendMessageAddValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu bilgisi boş geçilemez").MaximumLength(50).WithMessage("Konu bilgisi en fazla 50 karakter olabilir");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik bilgisi boş geçilemez").MaximumLength(20000).WithMessage("İçerik bilgisi en fazla 20000 karakter olabilir");

            RuleFor(x => x.ReceiverName).NotEmpty().WithMessage("Alıcı ad bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Alıcı ad bilgisi en az 3 karakter olmalıdır.").MaximumLength(30).WithMessage("Alıcı ad bilgisi en fazla 30 karakter olabilir.");
            RuleFor(x => x.ReceiverSurname).NotEmpty().WithMessage("Alıcı soyad bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Alıcı soyad bilgisi en az 3 karakter olmalıdır.").MaximumLength(30).WithMessage("Alıcı soyad bilgisi en fazla 30 karakter olabilir.");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı e-posta bilgisi boş geçilemez").EmailAddress().WithMessage("Alıcı e-posta bilgisi doğru formatta yazılmalıdır. Örn: xyz@gmail.com");

            RuleFor(x => x.SenderName).NotEmpty().WithMessage("Gönderici ad bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Gönderici ad bilgisi en az 3 karakter olmalıdır.").MaximumLength(30).WithMessage("Alıcı ad bilgisi en fazla 30 karakter olabilir.");
            RuleFor(x => x.SenderSurname).NotEmpty().WithMessage("Gönderici soyad bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Gönderici soyad bilgisi en az 3 karakter olmalıdır.").MaximumLength(30).WithMessage("Alıcı soyad bilgisi en fazla 30 karakter olabilir.");
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici e-posta bilgisi boş geçilemez").EmailAddress().WithMessage("Gönderici e-posta bilgisi doğru formatta yazılmalıdır. Örn: xyz@gmail.com");
        }
    }
}
