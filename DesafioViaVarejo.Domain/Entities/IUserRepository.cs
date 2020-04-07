using DesafioViaVarejo.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Domain.Entities
{
    public interface IUserRepository
    {
        List<AuthUser> GetAll();
        AuthUser Get(string userName, string userPsw);
    }
}
