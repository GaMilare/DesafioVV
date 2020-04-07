using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Domain.Services.Interface;
using DesafioViaVarejo.Domain.Services.Response;
using DesafioViaVarejo.Shared;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioViaVarejo.Infra.ExternalServices.Tax
{
    public class TaxService : BaseService, ITaxService
    {
        private readonly IConfiguration _config;

        public TaxService(IConfiguration configuration, INotification notification) : base(notification)
        {
            _config = configuration;
        }

        public async Task<decimal> GetCurrentSelicTax()
        {
            try
            {
                var urlBase = _config != null
                    ? _config["Keys:getCurrentSelicTaxUrl"]
                    : Settings.GetCurrentSelicTaxUrl;

                var url = string.Format(_config["Keys:getCurrentSelicTaxUrl"], DateTime.Now.AddDays(-30).Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"));

                var response = await url.
                WithHeader("User-Agent", "PostmanRuntime/7.6.0").
                GetAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Notificar("Falha ao consultar valor da SELIC");
                    return 0M;
                }

                var result = HttpResponseExtensios.ContentAsType<List<SelicTaxResponse>>(response);

                if (result.Count > 0)
                {
                    return result.Sum(x=>x.Valor);
                }

                    Notificar("Falha ao consultar valor da SELIC");
                    return 0M;
            }
            catch
            {
                //Salvaria o erro nos logs;

                Notificar("Falha ao consultar valor da SELIC");
                return 0M;
            }

        }
    }
}
