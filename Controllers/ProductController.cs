using InventoryAPI.DTOs;
using InventoryAPI.Extension;
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
        public IEnumerable<ProductsDTO> Allproducts()
        {
            var prod = _service.GetProducts().Select(x => x.ASDTO());

           /*.Select(X => new ProductsDTO
            * {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity
            });*/
            return prod;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductsDTO> GetProd(int? id)
        {
            var prod = _service.GetProduct(id);
            if (prod == null)
            {
                return NotFound();
            }
            return prod.ASDTO();
                
            /*    new ProductsDTO
            {
                Id = prod.Id,
                Name = prod.Name,
                Quantity = prod.Quantity
            };*/
        }


        [HttpPost]
        public ActionResult<ProductsDTO> CreateNew(ProductsDTO prodDTO)
        {
            //Here, the client is creating ProductDTO object and assigning the properties to the domain
            //entity Products

            Products product = new Products()
            {
                Id = prodDTO.Id,
                Name = prodDTO.Name,
                Quantity = prodDTO.Quantity
            };

            _service.Create(product);
            return CreatedAtAction(nameof(GetProd), new { id = product.Id },product.ASDTO());

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int? id)
        {
            var Delitem = _service.GetProduct(id);
            if (Delitem == null)
            {
                return NotFound();
            }

            _service.Delete(Delitem.Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(ProductsDTO productDTO, int? id)
        {

            var product = _service.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            // Here, you have created Server domain entity and updated it with ProductsDTO objects
            Products prod = product;
            prod.Name = productDTO.Name;
            prod.Quantity = productDTO.Quantity;

            return NoContent();
            
        }
       
    }

}
