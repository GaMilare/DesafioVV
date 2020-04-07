using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioViaVarejo.Domain.Models.Product
{
    //"condicaoPagamento": { "valorEntrada": 9999.99, "qtdeParcelas": 999 }
    public class PaymentCondition
    {

        public PaymentCondition(decimal valorEntrada, int qtdeParcelas)
        {
            ValorEntrada = valorEntrada;
            QtdeParcelas = qtdeParcelas;
        }

        [Required]
        public decimal ValorEntrada { get; set; }
        [Required]
        public int QtdeParcelas { get; set; }
    }
}
