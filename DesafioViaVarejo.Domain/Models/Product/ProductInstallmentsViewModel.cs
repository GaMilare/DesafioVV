using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Domain.Models.Product
{
    public class ProductInstallmentsViewModel
    {
        public ProductInstallmentsViewModel(int numeroParcela, decimal valor, decimal taxaJurosAoMes)
        {
            NumeroParcela = numeroParcela;
            Valor = valor;
            TaxaJurosAoMes = taxaJurosAoMes;
        }

        public int NumeroParcela { get; private set; }
        public decimal Valor { get; private set; }
        public decimal TaxaJurosAoMes { get; private set; }
    }
}
