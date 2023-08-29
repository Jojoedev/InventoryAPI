using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly ProductService _service;
        public ProductController()
        {
            _service = new ProductService();
        }


        [HttpGet]
        public ActionResult<List<Products>> Allproducts()
        {
           var prod = _service.GetProducts();
            return Ok(prod);
            
        }

        [HttpGet("{id}")]
        public ActionResult GetProd(int? id)
        {
          var prod=  _service.GetProducts().FirstOrDefault(x => x.Id == id);
            if(id == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }


        [HttpPost]
        public ActionResult<Products> CreateNew(Products prod)
        {
            _service.Create(prod);
            return CreatedAtAction(nameof(GetProd), new { id = prod.Id }, prod);


        }
    }

}
