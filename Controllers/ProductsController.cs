﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.Helpers;
using Shopbridge_base.Responses;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

       
        [HttpGet("Exist/{existing}/BeginIndex/{begin}/offset/{offset}")]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct([FromRoute]bool existing,
            [FromRoute]int begin,[FromRoute]int offset)
        {
            return Ok(Factory.GetResponse<Response>(await productService.Get(x=>x.Status  == existing)));
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productService.FirstOrDefault(x => x.Product_Id == id);

            if (product == null)
                return NotFound();

            return Ok(Factory.GetResponse<Response>(product));
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest(Factory.GetResponse<ServerErrorResponse>(null, 400, "Invalid request", false,
                    validation: ModelState.Values.SelectMany(y => y.Errors.Select(x => $"{x.ErrorMessage}"))
                    ));
            }

            if(id == 0)
            {
                return BadRequest(Factory.GetResponse<ServerErrorResponse>(null, 400, "Invalid request", false,
                    validation: new[] { "id can't be 0" })
                    );
            }

            var found = await productService.Exist(x => x.Product_Id == id);
            if(!found)
            {
                return NotFound(Factory.GetResponse<ServerErrorResponse>(null, 404, "Invalid request", false,
                    validation: new[] {"Not found"}
                    ));
            }

            var res = await productService.Update(id,product);
            return Ok(Factory.GetResponse<Response>(res));
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Factory.GetResponse<ServerErrorResponse>(null,400,"Invalid request",false,
                    validation: ModelState.Values.SelectMany(y=>y.Errors.Select(x=>$"{x.ErrorMessage}"))
                    ));
            }
            var res = await productService.Add(product);
            return Ok(Factory.GetResponse<Response>(res));
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var del = await productService.Delete(x => x.Product_Id == id && x.Status==true);
            return Ok(Factory.GetResponse<Response>(del));
        }

        [HttpGet("Exist/{id}")]
        private async Task<IActionResult> ProductExists([FromRoute]int id)
        {
            return Ok(Factory.GetResponse<Response>(await productService.Exist(x=>x.Product_Id==id && x.Status)));
        }
    }
}
