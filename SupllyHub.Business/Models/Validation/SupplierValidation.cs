using FluentValidation;
using SupllyHub.Business.Models.Validation.Document;

namespace SupllyHub.Business.Models.Validation;
public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(f => f.Name)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(f => Equals(f.SupplierType, SupplierType.NaturalPerson), () =>
        {
            RuleFor(f => f.Document!.Length).Equal(CPFValidation.CpfSize)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CPFValidation.Validate(f.Document!)).Equal(toCompare: true)
                .WithMessage("O documento fornecido é inválido.");
        });

        When(f => Equals(f.SupplierType, SupplierType.LegalPerson), () =>
        {
            RuleFor(f => f.Document!.Length).Equal(CPFValidation.CpfSize)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CPFValidation.Validate(f.Document!)).Equal(toCompare: true)
                .WithMessage("O documento fornecido é inválido.");
        });
    }
}
