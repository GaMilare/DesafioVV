using DesafioViaVarejo.Domain.Models.Product;
using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Domain.Services.Interface;
using DesafioViaVarejo.Infra.Services.Installment;
using DesafioViaVarejo.Infra.Services.Notify;
using DesafioViaVarejo.Infra.Services.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioViaVarejo.Tests
{
    [TestClass]
    public class ProductTests
    {
        private INotification _notification;
        private IProductService _productService;
        private IInstallmentService _installmentService;
        public ProductTests()
        {

        }

        [TestInitialize]
        public void Initalize()
        {
            _notification = new Notificador();
            _productService = new ProductService(_notification);
            _installmentService = new InstallmentService();


        }

        [TestMethod]
        public void Test_Get_All_Products()
        {
            var result = _productService.GetAllProducts();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Test_Calc_Installment_With_Tax()
        {
            var result = _installmentService.CalcInstallmentValue(
                new PaymentCondition(100, 10), 2100M, 1.49M);

            Assert.IsTrue(result.Valor > 0);
            Assert.IsTrue(result.TaxaJurosAoMes > 0);
            Assert.IsTrue(result.NumeroParcela == 10);
        }

        [TestMethod]
        public void Test_Calc_Installment_Ignoring_Tax()
        {
            var result = _installmentService.CalcInstallmentValue(
                new PaymentCondition(100, 5), 2100M, 1.49M);

            Assert.IsTrue(result.Valor > 0);
            Assert.IsTrue(result.TaxaJurosAoMes == 0);
            Assert.IsTrue(result.NumeroParcela == 5);
        }


    }
}
