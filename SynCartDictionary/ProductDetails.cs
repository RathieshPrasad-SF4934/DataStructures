using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartDictionary
{
    /// <summary>
    /// ProductDetails class for creating and storing the Product information of each product
    /// </summary> 
    public class ProductDetails
    {
        /// <summary>
        /// Product Id used for unique identification of the prodct in the list mapping them to specific order
        /// </summary>
        private static int s_productId = 2000;
        /// <summary>
        /// Method ProductID for getting and updating the Product ID for calculations
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// ProductName Field Stating the product name of the specified product.
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Stock Property stating the quantity of the property in the warehouse which is available
        /// </summary>
        /// <value></value>
        public int Stock { get; set; }
        /// <summary>
        /// Price Property stating the price for the property that was selected
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Shipping duration stating the number of days it will take for the product to arrive
        /// </summary>
        /// <value></value>
        public double ShippingDuration{get; set;}

        /// <summary>
        /// ProductDetails constructor for creating the Product with the specified fields
        /// </summary>
        /// <param name="productName">The Name of the product</param>
        /// <param name="stock">The quantity of the product available in the warehouse</param>
        /// <param name="price">The specific price for each of the product</param>
        /// <param name="shippingDuration">The duration for the order to reach the customer</param>
        public ProductDetails(string productName, int stock, double price, double shippingDuration)
        {
            ProductID = $"PID{++s_productId}";
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;
        }

    }
}