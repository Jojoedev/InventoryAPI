namespace InventoryAPI.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string CreditCard { get; set; }
        public string SocialSecuityNo { get; set; }
    }
}
