using FluentValidation;
using WebApp.Models;

namespace WebApp.Logic.Events
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Proszę wprowadzić imię");
            RuleFor(e => e.Age).NotNull().WithMessage("Proszę wprowadzić wiek"); ;
            RuleFor(e => e.Age).NotEqual(0).WithMessage("Wiek nie może wynosić 0");
            RuleFor(e => e.Start).NotNull().WithMessage("Proszę wprowadzić datę rozpoczęcia wydarzenia"); 
            RuleFor(e => e.End).NotNull().WithMessage("Proszę wprowadzić datę zakończenia wydarzenia");
            RuleFor(e => e.PhoneNumber).NotEmpty().WithMessage("Proszę wprowadzić numer telefonu"); 
            RuleFor(e => e.KidsQuantity).NotNull().WithMessage("Proszę wprowadzić ilość dzieci"); 
        }
    }
}
