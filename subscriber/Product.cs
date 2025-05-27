using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTransport
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }

        public Product(string id, string name, string category, string description, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = quantity;
            LastUpdated = DateTime.Now;
        }
    }
}
