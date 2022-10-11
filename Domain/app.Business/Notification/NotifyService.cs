using app.Business.Extensions;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace app.Business.Notification
{
    public abstract class NotifyService
    {
        private readonly INotify _notify;

        protected NotifyService(INotify notification) => _notify = notification;

        protected bool HasNotification() => _notify.HasNotification();
        protected void Notify(string mensagem) => _notify.Handle(new NotificationLite(mensagem));


        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }
        protected void Notify(List<string> messages)
        {
            foreach (var mensagem in messages)
                _notify.Handle(new NotificationLite(mensagem));
        }

        protected bool ExecuteValidate<TV, TE>(TV validacao, TE entidade)
        where TV : AbstractValidator<TE> where TE : CustomIdExtension
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }

}