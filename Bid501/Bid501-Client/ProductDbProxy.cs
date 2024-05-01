using System.Collections.Generic;
using System.Linq;
using Bid501_Shared;
using Bid501_Shared.dto;

namespace Bid501_Client
{
    public class ProductDbProxy
    {
        public List<ProductProxy> Products { get; }
        private int _selectedProductIdx;
        public Product SelectedProduct => Products[_selectedProductIdx];

        public ProductDbProxy(List<Product> products)
        {
            this.Products = products.Select(p => new ProductProxy(p)).ToList();
        }

        public void SelectProduct(ProductProxy p)
        {
            _selectedProductIdx = Products.IndexOf(p);
        }

        public void HandleNewProduct(Product product)
        {
            Products.Add(new ProductProxy(product));
        }

        public void HandleProductExpired(BidExpiredDTO bidExpired)
        {
            ProductProxy product = Products.Find(p => p.Id == bidExpired.Id);
            if (product != null)
            {
                product.IsExpired = true;
                product.IsWinning = bidExpired.IsWinning;
                product.MinBid = bidExpired.Bid;
            }
        }

        public void HandleProductUpdated(BidResponseDTO bidResponse)
        {
            ProductProxy product = Products.Find(p => p.Id == bidResponse.Id);
            if (product != null)
            {
                product.MinBid = bidResponse.Bid;
                product.BidCount++;
                product.IsWinning = bidResponse.IsWinning;
            }
        }
    }
}