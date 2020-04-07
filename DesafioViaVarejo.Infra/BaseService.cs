using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Domain.Notification.Notes;
using FluentValidation.Results;

namespace DesafioViaVarejo.Infra
{
    public abstract class BaseService
    {
        INotification _notification;

        public BaseService(INotification notification)
        {
            _notification = notification;
        }

        #region VALIDATION

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notification.Handle(new Note(mensagem));
        }

        #endregion
    }
}