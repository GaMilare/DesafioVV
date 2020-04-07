using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioViaVarejo.Domain.Services.Interface
{
    public interface ITaxService
    {
        Task<decimal> GetCurrentSelicTax();
    }
}
