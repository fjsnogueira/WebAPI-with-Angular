using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace APM.WebAPI.Models
{
    public class ProductRepository
    {
        internal Product Create()
        {
            Product product = new Product { ReleaseDate = DateTime.Now };
            return product; 
        }

        internal List<Product> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");
            var json = File.ReadAllText(filePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products; 
        }

        /// <summary>
        /// Saves a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Product Save(Product product)
        {
            //Get products
            var products = this.Retrieve();

            //Assign a new ID
            var maxID = products.Max(p => p.ProductId);
            product.ProductId = maxID++;
            products.Add(product);

            WriteData(products);
            return product;

        }

        internal Product Save(int id, Product product)
        {
            var products = this.Retrieve();

            //Locate and replace item
            var itemIndex = products.FindIndex(p => p.ProductId == id);
            if (itemIndex > 0)
            {
                products[itemIndex] = product;
            }
            else
            {
                return null;
            }

            WriteData(products);
            return product;
        }

        private bool WriteData(List<Product> products)
        {
            //Serialize JSON
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath, json);

            return true; 
        }
    }
}