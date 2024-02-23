using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    internal class Product
    {
        public string name;
        public double price;
        public double quantity;
        public string brandName;
        public List<Product> products;

        public Product()
        {
        }

        public Product(string name, double price, double quantity, string brandName)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.brandName = brandName;
        }

        public int validProduct(List<Product> products, string name)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].name == name)
                    return i;
            }
            return 0;
        }

        public void deleteProduct(List<Product> products, int i)
        {
            products.RemoveAt(i);
        }
    }
}
