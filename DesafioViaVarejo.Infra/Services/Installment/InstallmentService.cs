using DesafioViaVarejo.Domain.Models.Product;
using DesafioViaVarejo.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Infra.Services.Installment
{
    public class InstallmentService : IInstallmentService
    {
        public ProductInstallmentsViewModel CalcInstallmentValue(PaymentCondition model, decimal valor, decimal tax)
        {
            double valorParcela;
            tax = model.QtdeParcelas >= 6
                    ? tax
                    : 0M;
            valor -= model.ValorEntrada;
            if (valor > 0)
            {
                if (model.QtdeParcelas >= 6)
                {
                    valorParcela = AddTaxToInstallment(model.QtdeParcelas, tax, valor);
                }
                else
                {
                    valorParcela = (double)valor / model.QtdeParcelas;
                }
            }
            else
            {
                valorParcela = 0;
            }

            return new ProductInstallmentsViewModel(model.QtdeParcelas, decimal.Round(Convert.ToDecimal(valorParcela), 2), decimal.Round(tax, 2));
        }

        private double AddTaxToInstallment(int qtdParcela, decimal tax, decimal valor)
        {
            var x = Math.Pow((double)(1 + (tax / 100)), qtdParcela);
            var x1 = x * (double)(tax / 100);
            var x2 = x - 1;
            return (double)valor * (x1 / x2);
        }
    }
}

