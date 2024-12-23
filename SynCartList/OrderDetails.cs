using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    /// <summary>
    /// OrderDetails class for creating and storing the order information of each customer
    /// </summary> 
    public class OrderDetails
    {
        /// <summary>
        /// Order Id used for unique identification of the orders in the list mapping them to specific customers
        /// </summary>
        private static int s_orderId = 1000;
        /// <summary>
        /// Method OrderID for getting and updating the order ID for calculations
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// Customer ID Property used as a foreign key for mapping the order with the unique customer
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// Product ID Property used as a foreign key for mapping the order with the unique property
        /// </summary>
        /// <value></value>
        public string ProductID { get; set; }
        /// <summary>
        /// TotalPrice Property stating the price for the order that was placed
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// PurchaseDate Property stating the purchase date for the order that was placed
        /// </summary>
        /// <value></value>
        public DateTime PurchaseDate{get; set;}
        /// <summary>
        /// Quantity Property stating the quantity of the property in the order that was placed
        /// </summary>
        /// <value></value>
        public int Quantity { get; set; }
        /// <summary>
        /// OrderStatus Property stating whether the status of the order is either cancelled or booked.
        /// </summary> 
        public OrderStatus Status{get; set;}
        /// <summary>
        /// OrderDetails constructor for creating the Order with the specified fields
        /// </summary>
        /// <param name="customerId">The unique customer id of the customer who placed the order</param>
        /// <param name="productId">The unique product id of the product in the order</param>
        /// <param name="totalPrice">The total price of the order which was placed</param>
        /// <param name="purchaseDate"></param>
        /// <param name="quantity">The quantity of the product that was placed</param>
        /// <param name="status">The order status of the current order placed by the customer</param>
        public OrderDetails(string customerId, string productId, double totalPrice, DateTime purchaseDate, int quantity, OrderStatus status)
        {
            OrderID = $"OID{++s_orderId}";
            CustomerID = customerId;
            ProductID = productId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            Status = status;

        }
    }
}