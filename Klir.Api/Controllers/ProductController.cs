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
    public class ProductController : ControllerBase {
        ProductApp app;
        public ProductController(ProductApp _app) {
            app = _app;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var result = await app.GetAsync();
                if (result is null) {
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
                if (result is null) {
                    return BadRequest(new { Error = true, Message = "Product Not Found." });
                }
                return Ok(result);
            } catch {
                return StatusCode(500, "Error in get product.");
            }
        }
        [HttpPut("{id}/{idpromotion}")]
        public IActionResult Put(int id, int idpromotion) {
            try {
                var result = app.BindProductPromotion(id, idpromotion);
                if (!result) {
                    return BadRequest(new { Erro = true});
                }
                return Ok(new { Erro = false });
            } catch {
                return StatusCode(500, new { Erro = true });
            }
        }
    }
}
