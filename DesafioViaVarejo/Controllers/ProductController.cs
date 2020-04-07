using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioViaVarejo.Domain.AppServices;
using DesafioViaVarejo.Domain.Models.Product;
using DesafioViaVarejo.Domain.Notification.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioViaVarejo.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : MainController
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(INotification notificador, IProductApplicationService productApplicationService) : base(notificador)
        {
            _productApplicationService = productApplicationService;
        }

        [HttpGet("GetAllProducts")]
        [Authorize]
        public ActionResult<List<ProductModel>> GetAllProducts()
        {            
            return CustomResponse(_productApplicationService.GetAllProducts());
        }

        [HttpPost("GetInstallmentConditions")]
        [Authorize]
        public async Task<ActionResult<ProductInstallmentsViewModel>> GetInstallmentsCondictionsByProduct([FromBody] ProductInstallments model)
        {

            var result = await _productApplicationService.GetInstallmentsCondictionsByProduct(model);

            return CustomResponse(result);

        }
    }
}