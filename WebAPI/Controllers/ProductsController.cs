using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entities.Concrete;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        //Inversion of Controll -> like list of memory
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/values
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            //Thread.Sleep(5000);

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET: api/values
        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET: api/values
        [HttpGet("getByCategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // POST: api/values
        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // PUT: api/values
        [HttpPut("update")]
        public IActionResult Put(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // DELETE: api/values
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}

