using DesafioViaVarejo.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Domain.Services.Interface
{
    public interface IInstallmentService
    {
        ProductInstallmentsViewModel CalcInstallmentValue(PaymentCondition model, decimal valor, decimal tax);
    }
}
