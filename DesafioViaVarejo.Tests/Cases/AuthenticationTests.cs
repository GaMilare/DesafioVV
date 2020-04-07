using DesafioViaVarejo.ApplicationService;
using DesafioViaVarejo.Domain.AppServices.Authentication;
using DesafioViaVarejo.Domain.Entities;
using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Infra.Repository;
using DesafioViaVarejo.Infra.Services.Notify;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioViaVarejo.Tests.Cases
{
    [TestClass]
    public class AuthenticationTests
    {
        private IAuthenticationApplicationService _authenticationApplicationService;
        private INotification _notification;
        private IUserRepository _userRepository;

        public AuthenticationTests()
        {

        }

        [TestInitialize]
        public void Initalize()
        {
            _notification = new Notificador();
            _userRepository = new UserRepository();
            _authenticationApplicationService = new AuthenticationApplicationService(_notification, _userRepository);
        }
        [TestMethod]
        public void Test_Get_All_Users()
        {
            var result = _authenticationApplicationService.GetAllUsers();

            Assert.IsTrue(result.Count > 1);
        }

        [TestMethod]
        public void Test_Get_Valid_User()
        {
            var result = _authenticationApplicationService.GetUser("Gabriel", "123456");

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Test_Get_Valid_User_2()
        {
            var result = _authenticationApplicationService.GetUser("ViaVarejo", "123456");

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Test_Get_Invalid_User()
        {
            var result = _authenticationApplicationService.GetUser("a", "123456");

            Assert.IsFalse(result != null);
        }

    }
}
