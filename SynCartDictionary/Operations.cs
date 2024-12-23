using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using SynCartDictionary;


namespace SynCartDictionary
{
    public static class Operations
    {
        //Creating Object Lists for customer, products and orders
        public static CustomDictionary<string,CustomerDetails> customers = new CustomDictionary<string,CustomerDetails>();
        public static CustomDictionary<string,ProductDetails> products = new CustomDictionary<string,ProductDetails>();
        public static CustomDictionary<string,OrderDetails> orders = new CustomDictionary<string,OrderDetails>();
        //Creating Grid Objects for prouct and order
        public static Grid<string,ProductDetails> productGrid = new Grid<string,ProductDetails>();
        public static Grid<string,OrderDetails> orderGrid = new Grid<string,OrderDetails>();

        //Populating default data
        public static void DefaultData()
        {
            CustomerDetails customer1 = new("Ravi", "Chennai", "9885858588", 50000, "ravi@gmail.com");
            customers.Add(customer1.CustomerID,customer1);
            CustomerDetails customer2 = new("Baskaran", "Chennai", "9888475757", 60000, "baskaran@gmail.com");
            customers.Add(customer2.CustomerID,customer2);

            ProductDetails product1 = new("Mobile (Samsung)", 10, 10000, 3);
            products.Add(product1.ProductID,product1);
            ProductDetails product2 = new("Tablet (Lenovo)", 5, 15000, 2);
            products.Add(product2.ProductID,product2);
            ProductDetails product3 = new("Camara (Sony)", 3, 20000, 4);
            products.Add(product3.ProductID,product3);
            ProductDetails product4 = new("iPhone", 5, 50000, 6);
            products.Add(product4.ProductID,product4);
            ProductDetails product5 = new("Laptop (Lenovo I3)", 3, 40000, 3);
            products.Add(product5.ProductID,product5);
            ProductDetails product6 = new("HeadPhone (Boat)", 5, 1000, 2);
            products.Add(product6.ProductID,product6);
            ProductDetails product7 = new("Speakers (Boat)", 4, 500, 2);
            products.Add(product7.ProductID,product7);

            OrderDetails order1 = new("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            orders.Add(order1.OrderID,order1);
            OrderDetails order2 = new("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered);
            orders.Add(order2.OrderID,order2);
        }
        //Regitering a customer
        public static void CustomerRegistration()
        {
            System.Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter Your City: ");
            string city = Console.ReadLine();

            System.Console.Write("Enter Your Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            System.Console.Write("Enter Your Inital Wallet Balance: ");
            double balance;
            while(!double.TryParse(Console.ReadLine(),out balance) || balance<0){
                System.Console.Write("Enter a valid value");
                System.Console.Write("Enter Your Inital Wallet Balance: ");
            }

            System.Console.Write("Enter Your Email ID: ");
            string emailId = Console.ReadLine();

            CustomerDetails newCustomer = new CustomerDetails(name, city, mobileNumber, balance, emailId);

            customers.Add(newCustomer.CustomerID,newCustomer);

            System.Console.WriteLine($"\nA New Account Has Been Created ! Your Customer ID is {newCustomer.CustomerID}");

        }
        //Purchasing  
        public static void Purchase(CustomerDetails customer)
        {
            try
            {
                //show the table
                productGrid.ShowTable(products);

                //get product id
                System.Console.Write("\nEnter The Product ID you want to purchase: ");
                string choice = Console.ReadLine();

                bool flag = true;
                foreach (KeyValue<string,ProductDetails> product in products)
                {
                    //finding the product
                    if (product.Key.Equals(choice.ToUpper()))
                    {
                        flag = false;
                        System.Console.Write("Enter The Quantity: ");
                        int stock = int.Parse(Console.ReadLine());

                        //checking if required quantity is available
                        if (stock <= product.Value.Stock)
                        {
                            //checking if the customer has sufficient balance
                            double totalAmount = (stock * product.Value.Price) + 50;
                            if (customer.WalletBalance >= totalAmount)
                            {
                                customer.DeductBalance(totalAmount);
                                product.Value.Stock -= stock;

                                //placing order
                                OrderDetails newOrder = new OrderDetails(customer.CustomerID, product.Value.ProductID, totalAmount, DateTime.Now, stock, OrderStatus.Ordered);
                                orders.Add(newOrder.OrderID,newOrder);
                                System.Console.WriteLine($"\nOrder Placed Successfully. Order ID : {newOrder.OrderID}");
                                System.Console.WriteLine($"\nYour Order will be delivered on {newOrder.PurchaseDate.AddDays(product.Value.ShippingDuration).ToString("dd/MM/yyyy")}");

                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("\nInsufficient Wallet Balance. Please Recharge Your wallet !");
                                break;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine($"\nCurrent Count Not Available. Current Availability is {product.Value.Stock}");
                            break;
                        }
                    }

                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid Product ID.");
                }
            }
            catch
            {
                System.Console.WriteLine("An Error Has occurred in Purchasing ! Please Try again");
            }

        }
        public static void OrderHistory(CustomerDetails customer)
        {
            try
            {
                CustomDictionary<string,OrderDetails> orderHistory = new CustomDictionary<string,OrderDetails>();
                foreach (KeyValue<string,OrderDetails> order in orders)
                {
                    if (order.Value.CustomerID.Equals(customer.CustomerID))
                    {
    
                        orderHistory.Add(order.Key,order.Value);
                    }
                }
                orderGrid.ShowTable(orderHistory);
            }
            catch
            {
                System.Console.WriteLine("An Error has occurred in showing order History ! Please Try again");
            }
        }

        public static void CancelOrder(CustomerDetails customer)
        {
            try
            {
                //showing order history
                OrderHistory(customer);
                System.Console.Write("\nEnter the Order ID to be cancelled: ");
                string cancelOrder = Console.ReadLine().ToUpper();
                bool flag = true;
                //checking for order
                foreach (KeyValue<string,OrderDetails> order in orders)
                {
                    if (order.Key.Equals(cancelOrder))
                    {
                        flag = false;
                        //updating the product quantity
                        foreach (KeyValue<string,ProductDetails> product in products)
                        {
                            if (order.Value.ProductID.Equals(product.Key))
                            {
                                product.Value.Stock += order.Value.Quantity;
                                //Adding money to customer wallet
                                customer.WalletRecharge(order.Value.TotalPrice);
                                order.Value.Status = OrderStatus.Cancelled;
                                System.Console.WriteLine($"\nOrder ID : {order.Key} Has been cancelled successfully.");
                                break;
                            }
                        }
                    }


                }
                if (flag)
                {
                    System.Console.WriteLine("\nInvalid Order Id");
                }
            }
            catch
            {
                System.Console.WriteLine("An Error has occurred Try again !");
            }
        }
        public static void Login()
        {
            try
            {
                bool flag = true;
                bool isPresent = false;
                System.Console.Write("\nEnter The Customer ID: ");
                string customerId = Console.ReadLine().ToUpper();

                //checking for valid customer
                foreach (KeyValue<string,CustomerDetails>customer in customers)
                {
                    if (customer.Key.Equals(customerId))
                    {
                        isPresent = true;
                        do
                        {
                            //Sub Menu
                            System.Console.WriteLine("\nWelcome To SynCart Portal");
                            System.Console.WriteLine("a. Purchase");
                            System.Console.WriteLine("b. Order History");
                            System.Console.WriteLine("c. Cancel Order");
                            System.Console.WriteLine("d. Wallet Balance");
                            System.Console.WriteLine("e. Wallet Recharge");
                            System.Console.WriteLine("f. Exit");

                            System.Console.Write("\nEnter Your choice: ");

                            char c = char.Parse(Console.ReadLine());

                            switch (c)
                            {
                                case 'a':
                                    {
                                        Purchase(customer.Value);
                                        break;
                                    }
                                case 'b':
                                    {
                                        OrderHistory(customer.Value);
                                        break;
                                    }
                                case 'c':
                                    {
                                        CancelOrder(customer.Value);
                                        break;
                                    }
                                case 'd':
                                    {
                                        customer.Value.ShowWalletBalance();
                                        break;
                                    }
                                case 'e':
                                    {
                                        System.Console.Write("\nDo you wish to Recharge your wallet?(yes/no): ");
                                        string choice = Console.ReadLine();

                                        if (choice == "yes")
                                        {
                                            System.Console.Write("Enter the amount you wish to Recharge: ");
                                            double rechargeAmount = double.Parse(Console.ReadLine());
                                            customer.Value.WalletRecharge(rechargeAmount);
                                            System.Console.WriteLine($"Your walled has been Recharged !");
                                        }
                                        break;
                                    }
                                case 'f':
                                    {
                                        flag = false;
                                        break;
                                    }
                                default:
                                    {
                                        System.Console.WriteLine("Enter A Valid Choice !");
                                        break;
                                    }
                            }
                        }
                        while (flag);
                    }

                }
                if (!isPresent)
                {
                    System.Console.WriteLine("Invalid Customer ID");
                }
            }
            catch
            {
                System.Console.WriteLine("An Error has occurred Try again !");
            }
        }
        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Main Menu
                    System.Console.WriteLine("\nWelcome to SynCart !");
                    System.Console.WriteLine("1. Customer Registration");
                    System.Console.WriteLine("2. Login");
                    System.Console.WriteLine("3. Exit");

                    System.Console.Write("\nEnter Your choice : ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                CustomerRegistration();
                                break;
                            }
                        case 2:
                            {
                                Login();
                                break;
                            }
                        case 3:
                            {
                                System.Console.WriteLine("Thank You for using SynCart !");
                                flag = false;
                                break;
                            }
                        default:
                            {
                                System.Console.WriteLine("Invalid Choice Provided");
                                break;
                            }
                    }

                } while (flag);
            }
            catch
            {
                System.Console.WriteLine("An error has occurred Please try again !");
            }


        }
    }

    
}