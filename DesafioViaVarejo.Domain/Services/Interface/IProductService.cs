using DesafioViaVarejo.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioViaVarejo.Domain.Services.Interface
{
    public interface IProductService
    {
        List<ProductModel> GetAllProducts();
    }
}
