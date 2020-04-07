using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Domain.Models.Authentication
{
    public class AuthUser
    {
        public AuthUser(int id, string userName, string userPsw)
        {
            Id = id;
            UserName = userName;
            UserPsw = userPsw;
        }

        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string UserPsw { get; private set; }
    }
}
