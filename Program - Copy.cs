using System;
using System.Collections.Generic;

namespace SydneyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring N and allocating a value
            int n = 2;

            // declaring lists to store data
            List<string> name = new List<string>();
            List<int> quantity = new List<int>();
            List<string> reseller = new List<string>();
            List<double> charge = new List<double>();
            double price;
            double min = 9999999;
            string minName = "";
            double max = -1;
            string maxName = "";

            // Welcome message
            Console.WriteLine("\t\t\t\tWelcome to use Sydney Coffee Program\n");

            // Loop to get the inputs
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter customer name: ");
                name.Add(Console.ReadLine());

                int currentQuantity = 0;
                // The loop will continue whenever the entered value is out of range
                do
                {
                    Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
                    currentQuantity = Convert.ToInt32(Console.ReadLine());

                    if (currentQuantity < 1 || currentQuantity > 200)
                    {
                        Console.WriteLine("Invalid Input!\nCoffee bags between 1 and 200 can be ordered.");
                    }
                } while (currentQuantity < 1 || currentQuantity > 200);
                
                quantity.Add(currentQuantity);

                // determining the price
                if (currentQuantity <= 5)
                {
                    price = 36 * currentQuantity;
                }
                else if (currentQuantity <= 15)
                {
                    price = 34.5 * currentQuantity;
                }
                else
                {
                    price = 32.7 * currentQuantity;
                }

                Console.Write("Enter yes/no to indicate whether you are a reseller: ");
                reseller.Add(Console.ReadLine());

                if (reseller[i] == "yes")
                {
                    // 20% discount
                    charge.Add(price * 0.8);
                }
                else
                {
                    charge.Add(price);
                }
                Console.WriteLine($"The total sales value from {name[i]} is ${charge[i]}");
                Console.WriteLine("-----------------------------------------------------------------------------");

                // finding max min value
                if (min > charge[i])
                {
                    min = charge[i];
                    minName = name[i];
                }

                if (max < charge[i])
                {
                    max = charge[i];
                    maxName = name[i];
                }
            }

            // summary heading
            Console.WriteLine("\t\t\t\t\tSummary of sales\n");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");

            // displaying table header
            Console.WriteLine($"{"Name",15}{"Quantity",10}{"Reseller",10}{"Charge",10}");

            // displaying table data
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{name[i],15}{quantity[i],10}{reseller[i],10}{charge[i],10}");
            }
            
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"The customer spending most is {maxName} ${max}");
            Console.WriteLine($"The customer spending least is {minName} ${min}");
        }
    }
}
