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
        public List<ProductProxy> products { get; private set; }
        private int selectedProductIdx = 0;
        public Product selectedProduct => products[selectedProductIdx];

        public ProductDBProxy(List<Product> products)
        {
            this.products = products.Select(p => new ProductProxy(p)).ToList();
        }

        public void selectProduct(ProductProxy p)
        {
            selectedProductIdx = products.IndexOf(p);
        }

        public void handleNewProduct(Product product)
        {
            products.Add(new ProductProxy(product));
        }

        public void handleProductUpdated(decimal price, string id, bool winning)
        {
            ProductProxy product = products.Find(p => p.Id == id);
            if (product != null)
            {
                product.MinBid = price;
                product.BidCount++;
                product.Winning = winning;
            }
        }
    }
}