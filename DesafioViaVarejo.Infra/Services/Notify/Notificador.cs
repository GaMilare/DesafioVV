using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Domain.Notification.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViaVarejo.Infra.Services.Notify
{
    public class Notificador : INotification
    {
        private readonly List<Note> _notificacoes;

        public Notificador()
        {
            this._notificacoes = new List<Note>();
        }

        public void Handle(Note notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Note> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}

