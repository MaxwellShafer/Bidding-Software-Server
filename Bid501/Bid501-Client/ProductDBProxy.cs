using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Client
{
    public class ProductDBProxy
    {
        public List<Product> products { get; private set; }

        public ProductDBProxy()
        {
        }

        public void loadInitialProducts(List<Product> products)
        {
            this.products = products;
        }

        public void handleNewProduct(Product product)
        {
            var alreadyHasProduct = products.Any(p => p.Id == product.Id);
            if (alreadyHasProduct)
            {
                products = products.Select(p => p.Id == product.Id ? product : p).ToList();
            }
            else
            {
                products.Add(product);
            }
        }
    }
}