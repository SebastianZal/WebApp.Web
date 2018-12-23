using FluentValidation;
using WebApp.Models;

namespace WebApp.Logic.Packagess
{
    public class PackageValidator : AbstractValidator<Package>
    {
        public PackageValidator()
        {
            //brązowy
            When(p => p.Type.Equals(0), () =>
             {
                 RuleFor(p => p.Topic).Null().WithMessage("Temat niedostępne w tym pakiecie");
                 RuleFor(p => p.InvitationQuantity).Null().WithMessage("Zaproszenia niedostępne w tym pakiecie");
                 RuleFor(p => p.Cake).Null().WithMessage("Tort niedostępny w tym pakiecie");
                 RuleFor(p => p.Piniata).Null().WithMessage("Piniata niedostępna w tym pakiecie");
             });
            //srebrny
            When(p => p.Type.Equals(1), () =>
            {
                RuleFor(p => p.Topic).NotEmpty().WithMessage("Proszę wprowadzić temat wydarzenia");
                RuleFor(p => p.InvitationQuantity).Null().WithMessage("Zaproszenia niedostępne w tym pakiecie");
                RuleFor(p => p.Cake).Null().WithMessage("Tort niedostępny w tym pakiecie");
                RuleFor(p => p.Piniata).Null().WithMessage("Piniata niedostępna w tym pakiecie");
            });
            //złoty
            When(p => p.Type.Equals(2), () =>
            {
                RuleFor(p => p.Topic).NotEmpty().WithMessage("Proszę wprowadzić temat wydarzenia");
                RuleFor(p => p.Piniata).Null().WithMessage("Piniata niedostępna w tym pakiecie");
            });
            //platynowy
            When(p => p.Type.Equals(3), () =>
            {
                RuleFor(p => p.Topic).NotEmpty().WithMessage("Proszę wprowadzić temat wydarzenia");
            });


        }
    }
}
