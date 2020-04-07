using DesafioViaVarejo.Domain.AppServices;
using DesafioViaVarejo.Domain.Models.Product;
using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Domain.Services.Interface;
using DesafioViaVarejo.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioViaVarejo.ApplicationService
{
    public class ProductApplicationService : BaseService, IProductApplicationService
    {
        public readonly IProductService _productService;
        public readonly ITaxService _taxService;
        public readonly IInstallmentService _installmentService;

        public ProductApplicationService(IProductService productService,
            ITaxService taxService,
            IInstallmentService installmentService,
            INotification notification) : base(notification)
        {
            _productService = productService;
            _taxService = taxService;
            _installmentService = installmentService;
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        public async Task<ProductInstallmentsViewModel> GetInstallmentsCondictionsByProduct(ProductInstallments model)
        {
            var result = new ProductInstallmentsViewModel(0, 0, 0);
            var product = GetAllProducts().FirstOrDefault(x => x.Codigo == model.Produto.Codigo);
            if (product == null)
            {
                Notificar("Não foi possivel encontrar o produto informado, favor verificar os dados inseridos");
                return result;
            }

            if(model.CondicaoPagamento.ValorEntrada >= model.Produto.Valor)
            {
                Notificar("O Valor de entrada é maior ou igual ao valor registrado do produto.");
                return result;
            }
            //Busca valor da taxa SELIC dos ultimos 30 dias
            var monthlyTax = await _taxService.GetCurrentSelicTax();

            result = _installmentService.CalcInstallmentValue(model.CondicaoPagamento, model.Produto.Valor, monthlyTax);

            return result;

        }
    }
}
