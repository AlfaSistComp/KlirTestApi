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
    public class ProductController : ControllerBase {
        ProductApp app;
        public ProductController(ProductApp _app) {
            app = _app;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var result = await app.GetAsync();
                if (result == null) {
                    return BadRequest(new { Error = true, Message = "No Product Found." });
                }
                return Ok(result);
            } catch {
                return StatusCode(500, "Error in get products.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            try {
                var result = await app.GetAsync(id);
                if (result == null) {
                    return BadRequest(new { Error = true, Message = "Product Not Found." });
                }
                return Ok(result);
            } catch {
                return StatusCode(500, "Error in get product.");
            }
        }

    }
}
