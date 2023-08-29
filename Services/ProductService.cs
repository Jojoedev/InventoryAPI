using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Services
{
    public class ProductService
    {
        List<Products> products = new List<Products>()
        {
            new Products(){Id= 1, Name="Cornflakes", Quantity = 10},
            new Products(){Id = 2, Name="Sardines", Quantity = 14},
            new Products(){Id = 3, Name="Yoghurt", Quantity = 20}
        };


        public List<Products> GetProducts()
        {
            return products;
        }

        public Products GetProduct(Products product)
        {
            
            var prod = products[product.Id];
            return prod;   
            
        }

        public void Create(Products product)
        {
            products.Add(product);
        }
    }
}
