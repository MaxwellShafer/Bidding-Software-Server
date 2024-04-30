using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;
using Bid501_Shared.dto;

namespace Bid501_Client
{
    public class ProductDBProxy
    {
        public List<ProductProxy> Products { get; private set; }
        private int selectedProductIdx = 0;
        public Product SelectedProduct => Products[selectedProductIdx];

        public ProductDBProxy(List<Product> products)
        {
            this.Products = products.Select(p => new ProductProxy(p)).ToList();
        }

        public void selectProduct(ProductProxy p)
        {
            selectedProductIdx = Products.IndexOf(p);
        }

        public void handleNewProduct(Product product)
        {
            Products.Add(new ProductProxy(product));
        }

        public void handleProductUpdated(BidResponseDTO bidResponse)
        {
            ProductProxy product = Products.Find(p => p.Id == bidResponse.Id);
            if (product != null)
            {
                product.MinBid = bidResponse.Bid;
                product.BidCount++;
                product.Winning = bidResponse.IsWinning;
            }
        }
    }
}