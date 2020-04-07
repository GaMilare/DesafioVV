using DesafioViaVarejo.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioViaVarejo.Domain.AppServices
{
    public interface IProductApplicationService 
    {
        List<ProductModel> GetAllProducts();
        Task<ProductInstallmentsViewModel> GetInstallmentsCondictionsByProduct(ProductInstallments model);
    }
}
