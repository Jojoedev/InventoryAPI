using InventoryAPI.InterfaceRepo;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Services
{
    public class ProductService: IProductInterface
    {
      private readonly List<Products> products = new List<Products>()
        {
            new Products(){Id= 1, Name="Cornflakes", Quantity = 10},
            new Products(){Id = 2, Name="Sardines", Quantity = 14},
            new Products(){Id = 3, Name="Yoghurt", Quantity = 20}
        };


        public List<Products> GetProducts()
        {
            return products;
        }

        public Products GetProduct(int? id)
        {
            var prod = products.Where(products => products.Id == id).FirstOrDefault();
            return prod; 
            
        }

        public void Create(Products product)
        {
            products.Add(product);
        }

        public void Update(int? id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
