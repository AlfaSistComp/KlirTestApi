using Klir.Application.Data;
using Klir.Domain.Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase {
        CheckoutApp app;
        public CheckoutController(CheckoutApp _app) {
            app = _app;
        }
        [HttpPost]
        public IActionResult CheckoutCart([FromBody] List<ProductCartViewModel> _body) {
            app.CalculateCart(ref _body);
            return Ok(_body);
        }
    }
}
