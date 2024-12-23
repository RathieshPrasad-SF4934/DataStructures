using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartFileManagement
{
    public static class FileManagement
    {
        public static void Create()
        {
            //creating synCart Folder 
            if (!Directory.Exists("SynCart"))
            {
                Console.WriteLine("Creating Folder SynCart for File Management...");
                Directory.CreateDirectory("SynCart");
            }
            else
            {
                System.Console.WriteLine("Folder Already Exists...");
            }

            //Creating CustomerDetails CSV
            if (!File.Exists("SynCart/CustomerDetails.csv"))
            {
                System.Console.WriteLine("Creating File for CustomerDetails...");
                File.Create("SynCart/CustomerDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File Already Exists...");
            }

            //Creating OrderDetails CSV
            if (!File.Exists("SynCart/OrderDetails.csv"))
            {
                System.Console.WriteLine("Creating File for OrderDetails...");
                File.Create("SynCart/OrderDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File Already Exists...");
            }

            //Creating ProductDetails CSV
            if (!File.Exists("SynCart/ProductDetails.csv"))
            {
                System.Console.WriteLine("Creating File for ProductDetails...");
                File.Create("SynCart/ProductDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File Already Exists...");
            }
        }

        public static void WriteToCSV()
        {
            //writing customer details into csv
            string[] customers = new string[Operations.customers.Count];

            for (int i = 0; i < Operations.customers.Count; i++)
            {
                customers[i] = Operations.customers[i].CustomerID + "," + Operations.customers[i].CustomerName + "," + Operations.customers[i].City + "," + Operations.customers[i].MobileNumber + "," + Operations.customers[i].WalletBalance + "," + Operations.customers[i].EmailID;
            }

            File.WriteAllLines("SynCart/CustomerDetails.csv", customers);

            //writing order details into csv
            string[] orders = new string[Operations.orders.Count];

            for (int i = 0; i < Operations.orders.Count; i++)
            {
                orders[i] = Operations.orders[i].OrderID + "," + Operations.orders[i].CustomerID + "," + Operations.orders[i].ProductID + "," + Operations.orders[i].TotalPrice + "," + Operations.orders[i].PurchaseDate.ToString("dd/MM/yyyy") + "," + Operations.orders[i].Quantity + "," + Operations.orders[i].Status;
            }

            File.WriteAllLines("SynCart/OrderDetails.csv", orders);

            //writing Product details into csv
            string[] products = new string[Operations.products.Count];

            for (int i = 0; i < Operations.products.Count; i++)
            {
                products[i] = Operations.products[i].ProductID + "," + Operations.products[i].ProductName + "," + Operations.products[i].Stock + "," + Operations.products[i].Price + "," + Operations.products[i].ShippingDuration;

                File.WriteAllLines("SynCart/ProductDetails.csv", products);
            }
        }
    }
}