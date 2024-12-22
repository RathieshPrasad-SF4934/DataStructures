using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SynCart
{
    /// <summary>
    /// CustomerDetails class for creating and storing the Customer information of each customer
    /// </summary> 
    public class CustomerDetails
    {
        /// <summary>
        /// Order Id used for unique identification of the orders in the list mapping them to specific customers
        /// </summary>
        private static int s_customerId = 3000;
        /// <summary>
        /// The wallet balance of the unique customer
        /// </summary> 
        private double _walletBalance =0;
        /// <summary>
        /// Method CustomerID for getting and updating the Customer ID for calculations
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// Customer Name stating the name of the customer
        /// </summary>
        /// <value></value>
        public string CustomerName { get; set; }
        /// <summary>
        /// City Property stating the city of the customer
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Mobile Number Property stating the Mobile Number of the customer
        /// </summary> 
        public string MobileNumber { get; set; }
        // private double WalletBalance { get(return _walletBalance;)}
        /// <summary>
        /// EmailID stating the email id of the customer
        /// </summary>
        public string EmailID { get; set; }
        /// <summary>
        /// Get Method for WalletBalance to get the data of thw wallet balance
        /// </summary>
        public double WalletBalance { get{return _walletBalance;} }
        /// <summary>
        /// WalletRecharge Method to update or increase the walletBalance of the customer
        /// </summary>
        /// <param name="amount">The amount to be recharged</param>
        public void WalletRecharge(double amount)
        {
            _walletBalance+=amount;
        }
        /// <summary>
        /// DeductBalance Method to update or decrease the walletBalance of the customer
        /// </summary>
        /// <param name="amount">The amount to be Deducted</param>
        public void DeductBalance(double amount)
        {
            if(amount>_walletBalance)
            {
                System.Console.WriteLine("Insufficient Funds to Deduct");
            }
            else
            {
                _walletBalance-=amount;
            }
        }
        /// <summary>
        /// ShowWalletBalance Method for showing the current walletBalance of the customer
        /// </summary>
        public void ShowWalletBalance()
        {
            System.Console.WriteLine($"Hello {CustomerName} ! Your Wallet Balance is {_walletBalance}");
        }
        /// <summary>
        /// OrderDetails constructor for creating the Order with the specified fields

        /// </summary>
        /// <param name="name">Name of the customer</param>
        /// <param name="city">City of the customer</param>
        /// <param name="mobileNumber">Mobile number of the customer</param>
        /// <param name="walletBalance">Wallet balance of the customer</param>
        /// <param name="emailId">email id of the customer</param>
        public CustomerDetails(string name, string city, string mobileNumber, double walletBalance,string emailId)
        {
            CustomerID = $"CID{++s_customerId}";
            CustomerName= name;
            City = city;
            MobileNumber = mobileNumber;
            _walletBalance = walletBalance;
            EmailID = emailId;
        }
    }
}