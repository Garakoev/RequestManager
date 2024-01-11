using FluentValidation;
using RequestManager.API.DTOs;
using System.Text.RegularExpressions;

namespace RequestManager.API.Validators;

public partial class RequestValidator : AbstractValidator<RequestDTO>
{
    private readonly Regex _regex = MyRegex();

    public RequestValidator()
    {
        RuleFor(x => x.RecipientsPassport).NotNull().WithMessage("Passport is required!");
        RuleFor(x => x.RecipientsPassport).Matches(_regex).WithMessage("Passport must contain only numbers");
        RuleFor(x => x.RecipientsPassport).Length(10).WithMessage("Passport must be of length 10");
        RuleFor(x => x.SendersPassport).NotNull().WithMessage("Passport is required!");
        RuleFor(x => x.SendersPassport).Matches(_regex).WithMessage("Passport must contain only numbers");
        RuleFor(x => x.SendersPassport).Length(10).WithMessage("Passport must be of length 10");

        RuleFor(x => x.RecipientsName).NotNull().WithMessage("Recipient's name is required!");
        RuleFor(x => x.SendersName).NotNull().WithMessage("Sender's name is required!");
        RuleFor(x => x.RecipientsPhoneNumber).NotNull().WithMessage("Recipient's phone number is required!");
        RuleFor(x => x.SendersPhoneNumber).NotNull().WithMessage("Sender's phone number is required!");
        RuleFor(x => x.RegistrationDate).NotNull().WithMessage("Registration date is required!");
        RuleFor(x => x.RegistrationDate).GreaterThan(DateTime.Now).WithMessage("Registration date is invalid!");
        RuleFor(x => x.Status).NotNull().WithMessage("Status is required!");
    }

    [GeneratedRegex("^[0-9]+$")]
    private static partial Regex MyRegex();
}