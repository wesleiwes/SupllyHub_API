using FluentValidation;
using FluentValidation.Results;
using SupllyHub.Business.Interfaces;
using SupllyHub.Business.Models;
using SupllyHub.Business.Notifications;

namespace SupllyHub.Business.Services;
public abstract class BaseService
{
    private readonly INotifier _notifier;

    protected BaseService(INotifier notifier) => _notifier = notifier;

    protected void Notifier(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }

    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected bool RunValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid)
        {
            return true;
        }

        foreach (var error in validator.Errors)
        {
            Notify(error.ErrorMessage);
        }

        return false;
    }
}
