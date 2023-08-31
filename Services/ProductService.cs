using InventoryAPI.InterfaceRepo;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Services
{
    public class ProductService: IProductInterface
    {
      private readonly List<Products> products = new List<Products>()
        {
            new Products(){Id= 1, Name="Cornflakes", Quantity = 10, CreditCard="1234wq", SocialSecuityNo="we323" },
            new Products(){Id = 2, Name="Sardines", Quantity = 14, CreditCard="5434mo", SocialSecuityNo="Year093"},
            new Products(){Id = 3, Name="Yoghurt", Quantity = 20, CreditCard="9854wq", SocialSecuityNo="kl23"},
            new Products(){Id = 4, Name="Rice", Quantity = 12, CreditCard="Ywahh", SocialSecuityNo="poad423"}
        };


        public IEnumerable<Products> GetProducts()
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
            var UpdateItem = products.Where(products => products.Id == id).FirstOrDefault();
            
        }

        public void Delete(int? id)
        {
            var DelItem = products.FindIndex(x => x.Id == id);
            products.RemoveAt(DelItem);
            
        }
    }
}

