using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SynCart
{
    public static class Operations
    {
        //Creating Object Lists for customer, products and orders
        public static CustomList<CustomerDetails> customers = new CustomList<CustomerDetails>();
        public static CustomList<ProductDetails> products = new CustomList<ProductDetails>();
        public static CustomList<OrderDetails> orders = new CustomList<OrderDetails>();
        //Creating Grid Objects for prouct and order
        public static Grid<ProductDetails> productGrid = new Grid<ProductDetails>();
        public static Grid<OrderDetails> orderGrid = new Grid<OrderDetails>();

        //Populating default data
        public static void DefaultData()
        {
            customers.Add(new("Ravi", "Chennai", "9885858588", 50000, "ravi@gmail.com"));
            customers.Add(new("Baskaran", "Chennai", "9888475757", 60000, "baskaran@gmail.com"));

            products.Add(new("Mobile (Samsung)", 10, 10000, 3));
            products.Add(new("Tablet (Lenovo)", 5, 15000, 2));
            products.Add(new("Camara (Sony)", 3, 20000, 4));
            products.Add(new("iPhone", 5, 50000, 6));
            products.Add(new("Laptop (Lenovo I3)", 3, 40000, 3));
            products.Add(new("HeadPhone (Boat)", 5, 1000, 2));
            products.Add(new("Speakers (Boat)", 4, 500, 2));

            orders.Add(new("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered));
            orders.Add(new("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered));
        }
        //Binary search for CustomerDetails
        public static int BinarySearch(CustomList<CustomerDetails> list, string key, out CustomerDetails foundCustomer)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start <= end)
            {

                int mid = start + (end - start) / 2;
                if (list[mid].CustomerID.Equals(key))
                {
                    foundCustomer = list[mid];
                    return mid;
                }
                else if (list[mid].CustomerID.CompareTo(key) < 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            foundCustomer = default(CustomerDetails);
            return -1;

        }
        //Binary Search for ProductDetails
        public static int BinarySearch(CustomList<ProductDetails> list, string key, out ProductDetails foundProduct)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start <= end)
            {

                int mid = start + (end - start) / 2;
                if (list[mid].ProductID.Equals(key))
                {
                    foundProduct = list[mid];
                    return mid;
                }
                else if (list[mid].ProductID.CompareTo(key) < 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            foundProduct = default(ProductDetails);
            return -1;

        }
        //Binary Search for Order Details
        public static int BinarySearch(CustomList<OrderDetails> list, string key, out OrderDetails foundOrder)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start <= end)
            {

                int mid = start + (end - start) / 2;
                if (list[mid].OrderID.Equals(key))
                {
                    foundOrder = list[mid];
                    return mid;
                }
                else if (list[mid].OrderID.CompareTo(key) < 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            foundOrder = default(OrderDetails);
            return -1;

        }
        public static int BinarySearchOrderHistory(CustomList<OrderDetails> list, string key, out OrderDetails foundOrder)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start <= end)
            {

                int mid = start + (end - start) / 2;
                if (list[mid].CustomerID.Equals(key))
                {
                    foundOrder = list[mid];
                    return mid;
                }
                else if (list[mid].CustomerID.CompareTo(key) < 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            foundOrder = default(OrderDetails);
            return -1;

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
            while (!double.TryParse(Console.ReadLine(), out balance) || balance < 0)
            {
                System.Console.Write("Enter a valid value");
                System.Console.Write("Enter Your Inital Wallet Balance: ");
            }

            System.Console.Write("Enter Your Email ID: ");
            string emailId = Console.ReadLine();

            CustomerDetails newCustomer = new CustomerDetails(name, city, mobileNumber, balance, emailId);

            customers.Add(newCustomer);

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
                string choice = Console.ReadLine().ToUpper();

                bool flag = true;
                if (BinarySearch(products, choice, out ProductDetails foundProduct) >= 0)
                {
                    //finding the product
                    if (foundProduct.ProductID.Equals(choice.ToUpper()))
                    {
                        flag = false;
                        System.Console.Write("Enter The Quantity: ");
                        int stock = int.Parse(Console.ReadLine());

                        //checking if required quantity is available
                        if (stock <= foundProduct.Stock)
                        {
                            //checking if the customer has sufficient balance
                            double totalAmount = (stock * foundProduct.Price) + 50;
                            if (customer.WalletBalance >= totalAmount)
                            {
                                customer.DeductBalance(totalAmount);
                                foundProduct.Stock -= stock;

                                //placing order
                                OrderDetails newOrder = new OrderDetails(customer.CustomerID, foundProduct.ProductID, totalAmount, DateTime.Now, stock, OrderStatus.Ordered);
                                orders.Add(newOrder);
                                System.Console.WriteLine($"\nOrder Placed Successfully. Order ID : {newOrder.OrderID}");
                                System.Console.WriteLine($"\nYour Order will be delivered on {newOrder.PurchaseDate.AddDays(foundProduct.ShippingDuration).ToString("dd/MM/yyyy")}");
                            }
                            else
                            {
                                System.Console.WriteLine("\nInsufficient Wallet Balance. Please Recharge Your wallet !");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine($"\nCurrent Count Not Available. Current Availability is {foundProduct.Stock}");
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
                CustomList<OrderDetails> orderHistory = new CustomList<OrderDetails>();
                foreach (OrderDetails order in orders)
                {
                    if (BinarySearchOrderHistory(orders, customer.CustomerID, out OrderDetails foundOrder) >= 0)
                    {

                        orderHistory.Add(foundOrder);

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

                if (BinarySearch(orders, cancelOrder, out OrderDetails foundOrder) >= 0)
                {
                    flag = false;
                    //updating the product quantity
                    foreach (ProductDetails product in products)
                    {
                        if (foundOrder.ProductID.Equals(product.ProductID))
                        {
                            product.Stock += foundOrder.Quantity;
                            //Adding money to customer wallet
                            customer.WalletRecharge(foundOrder.TotalPrice);
                            foundOrder.Status = OrderStatus.Cancelled;
                            System.Console.WriteLine($"\nOrder ID : {foundOrder.OrderID} Has been cancelled successfully.");
                            break;
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
                // bool isPresent = false;
                System.Console.Write("\nEnter The Customer ID: ");
                string customerId = Console.ReadLine().ToUpper();

                //checking for valid customer
                if (BinarySearch(customers, customerId, out CustomerDetails foundCustomer) >= 0)
                {
                    if (foundCustomer.CustomerID.Equals(customerId))
                    {
                        // isPresent = true;
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
                                        Purchase(foundCustomer);
                                        break;
                                    }
                                case 'b':
                                    {
                                        OrderHistory(foundCustomer);
                                        break;
                                    }
                                case 'c':
                                    {
                                        CancelOrder(foundCustomer);
                                        break;
                                    }
                                case 'd':
                                    {
                                        foundCustomer.ShowWalletBalance();
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
                                            foundCustomer.WalletRecharge(rechargeAmount);
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
                else
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