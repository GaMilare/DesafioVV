using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Domain.Notification.Notes
{
    public class Note
    {
        public Note(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem
        {
            get; set;
        }
    }
}
