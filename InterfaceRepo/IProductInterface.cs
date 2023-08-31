using InventoryAPI.Models;

namespace InventoryAPI.InterfaceRepo
{
    public interface IProductInterface
    {
        IEnumerable<Products> GetProducts();
        Products GetProduct(int? id);
        void Create(Products product);
        void Update(int? id);
        void Delete(int? id);
        
    }
}
