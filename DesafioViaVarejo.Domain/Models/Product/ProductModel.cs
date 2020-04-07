using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioViaVarejo.Domain.Models.Product
{
    // { "codigo": 123, "nome": "Nome do Produto", "valor": 9999.99 }
    public class ProductModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Favor informar um codigo maior que zero")]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Favor informar um valor maior que zero")]
        public decimal Valor { get; set; }
    }
}
