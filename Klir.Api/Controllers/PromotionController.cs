using Klir.Application.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase {
        PromotionApp app;
        public PromotionController(PromotionApp _app) {
            app = _app;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var result = await app.GetAsync();
                if (result == null) {
                    return BadRequest(new { Error = true, Message = "No Promotion Found." });
                }
                return Ok(result);
            } catch {
                return StatusCode(500, "Error in get promotions.");
            }
        }

    }
}
