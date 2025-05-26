using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml;

namespace ProductLibrary
{
    public class ProductCatalog
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(string id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p != null) products.Remove(p);
        }

        public Product SearchById(string id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void SaveToFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }
    }
}
