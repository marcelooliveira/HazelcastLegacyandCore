using System;

namespace SampleLegacy.Models
{
    [Serializable]
    public class CartItem
    {
        public CartItem()
        {

        }

        public CartItem(int productId, string description, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Quantity * UnitPrice; } } 
    }

}
