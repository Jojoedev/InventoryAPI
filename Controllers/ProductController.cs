using InventoryAPI.InterfaceRepo;
using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductInterface _service;
        public ProductController(IProductInterface service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult<List<Products>> Allproducts()
        {
            var prod = _service.GetProducts();
            return prod;
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetProd(int? id)
        {
            var prod = _service.GetProduct(id);
            if (prod == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }


        [HttpPost]
        public IActionResult CreateNew(Products prod)
        {
            _service.Create(prod);
            return CreatedAtAction(nameof(GetProd), new { id = prod.Id }, prod);

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int? id)
        {
            var Delitem = _service.GetProduct(id);
            if(Delitem == null)
            {
                return NotFound();   
            }

            _service.Delete(Delitem.Id);
            return NoContent();
        }
    }

}
