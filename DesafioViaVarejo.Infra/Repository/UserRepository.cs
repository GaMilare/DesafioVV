using DesafioViaVarejo.Domain.Entities;
using DesafioViaVarejo.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViaVarejo.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<AuthUser> GetAll()
        {
            var users = new List<AuthUser>
            {
                new AuthUser(1, "ViaVarejo", "123456"),
                new AuthUser(2, "Gabriel", "123456")
            };
            return users.ToList();
        }

        public AuthUser Get(string userName, string userPsw)
        {
            var users = GetAll();

            return users.Where(x => x.UserName.ToLower() == userName.ToLower() && x.UserPsw == userPsw).FirstOrDefault();
        }
    }
}
