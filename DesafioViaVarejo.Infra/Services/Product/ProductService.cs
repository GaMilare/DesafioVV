using DesafioViaVarejo.Domain.Services.Interface;
using DesafioViaVarejo.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DesafioViaVarejo.Domain.Notification.Interfaces;

namespace DesafioViaVarejo.Infra.Services.Product
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService( INotification notification) : base(notification)
        {
        }

        public List<ProductModel> GetAllProducts()
        {
            var allProducts = new List<ProductModel>();
            try
            {
                decimal valor = 100M;
                int codigo = 10;
                string nome = "Produto A";
                while (allProducts.Count <= 5)
                {
                    var product = new ProductModel()
                    {
                        Codigo = codigo,
                        Nome = nome,
                        Valor = valor
                    };

                    allProducts.Add(product);

                    #region Mock New Product
                    valor += 500;
                    codigo += 1;
                    nome = "Produto A" + codigo;
                    #endregion
                }

                return allProducts;
            }
            catch (Exception ex)
            {
                Notificar("Ocorreu um erro na busca de todos os produtos. erro: " + ex.Message);

                return allProducts;
            }
        }
    }
}
