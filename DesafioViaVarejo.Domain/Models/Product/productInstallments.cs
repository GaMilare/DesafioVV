using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Domain.Models.Product
{
    public class ProductInstallments
    {
        public ProductModel Produto { get; set; }
        public PaymentCondition CondicaoPagamento { get; set; }
    }
}
