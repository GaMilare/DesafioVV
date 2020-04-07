using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.Shared
{
    public class Settings
    {
        public static string Secret = "3417494ea62ce829a1e343ff7f307c4dd8cb3894;";
        public static string GetCurrentSelicTaxUrl = "https://api.bcb.gov.br/dados/serie/bcdata.sgs.11/dados?formato=json&dataInicial={0}&dataFinal={1}";
    }
}
