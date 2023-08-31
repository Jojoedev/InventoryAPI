using InventoryAPI.DTOs;
using InventoryAPI.Models;

namespace InventoryAPI.Extension
{
    public static class AsDto
    {
        public static ProductsDTO ASDTO(this Products products)
        {
          return  new ProductsDTO
            {
                Id = products.Id,
                Name = products.Name,   
                Quantity  = products.Quantity,
            };
            
        }
    }
}
