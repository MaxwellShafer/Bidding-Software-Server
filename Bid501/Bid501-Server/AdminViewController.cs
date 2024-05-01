using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// A class to control the admin view
    /// </summary>
    internal class AdminViewController
    {
        /// <summary>
        /// a private field to hold the database
        /// </summary>
        private ProductDB _productDB;

        /// <summary>
        /// a delegate to hold the send product method
        /// </summary>
        public SendProductDEL SendProductDEL { get; set; }

        /// <summary>
        /// a delegate to hold the update state method
        /// </summary>
        public UpdateStateDEL UpdateStateDEL { get; set; }

        /// <summary>
        /// Constructs the AdminViewController
        /// </summary>
        /// <param name="productDB"></param>
        /// <param name="sendProductDEL"></param>
        /// <param name="updateStateDEL"></param>
        public AdminViewController(ProductDB productDB, SendProductDEL sendProductDEL, UpdateStateDEL updateStateDEL)
        {
            _productDB = productDB;
            this.SendProductDEL = sendProductDEL;
            this.UpdateStateDEL = updateStateDEL;
            
        }

        /// <summary>
        /// Generates an id for the new products
        /// </summary>
        /// <returns></returns>
        private string GenerateUUID()
        {
            bool flag = false;
            string newId = "";
            while (!flag)
            {
                newId = Convert.ToString(((DateTimeOffset)DateTime.UtcNow).ToUnixTimeMilliseconds());
                flag = true;
                foreach(IProduct product in _productDB.Products)
                {
                    if(product.Id == newId) 
                    { 
                        flag = false; 
                        break; 
                    }
                }
            }
            return newId;
        }

        /// <summary>
        /// a method to handle when a product is added
        /// </summary>
        /// <param name="product">the product handled</param>
        public void handleAddProduct(IProduct product)
        {
            product.Id = GenerateUUID();
            _productDB.Products.Add(product);
            UpdateStateDEL(AdminState.ADDEDNEW);
        }

        /// <summary>
        /// Handles expiring the bid
        /// </summary>
        /// <param name="product"></param>
        public void handleExpireProduct(IProduct product)
        {
            foreach(IProduct p in _productDB.Products)
            {
                if(p.Id == product.Id)
                {
                    p.IsExpired = true;
                    UpdateStateDEL(AdminState.EXPIREDBID);

                    break;
                }
            }
        }
    }
}
