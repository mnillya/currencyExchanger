using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Transactions;

namespace CLLIGNT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputGrivnesInWallet;
            string inputDollarsInWallet;

            float grivnesInWallet;
            float dollarsInWallet;

            int griToUsd = 50, usdToGri = 52;

            float exchangeCurrenceCount;

            string desiredOperation;

            Console.WriteLine("welcome to currency exchanger");

            Console.Write("enter to balance hryvnias: ");

            inputGrivnesInWallet = Console.ReadLine();
            if (!Single.TryParse(inputGrivnesInWallet, out grivnesInWallet))
            {
                Console.WriteLine("unavailable amount of hryvnias, we set it automatically to 0");
                grivnesInWallet = 0;
            }

            Console.Write("enter to balance dollars: ");
            inputDollarsInWallet = Console.ReadLine();
            if (!Single.TryParse(inputDollarsInWallet, out dollarsInWallet))
            {
                Console.WriteLine("unavailable amount of dollars, we set it automatically to 0");
                dollarsInWallet = 0;
            }

            Console.WriteLine("select an operation");
            Console.WriteLine("1 - will exchange hryvnias on dollars");
            Console.WriteLine("2 - will exchange dollars on hryvnias");
            Console.Write("your choice: ");
            desiredOperation = Console.ReadLine();

            switch (desiredOperation)
            {
                case "1":
                    Console.WriteLine("exchange hryvnias for dollars");
                    Console.Write("how much you want to exchange: ");

                    exchangeCurrenceCount = Convert.ToSingle(Console.ReadLine());

                    if (grivnesInWallet >= exchangeCurrenceCount)
                    {
                        grivnesInWallet -= exchangeCurrenceCount;
                        dollarsInWallet += exchangeCurrenceCount / griToUsd;
                    }
                    else
                    {
                        Console.WriteLine("unavailable amount of hryvnias");
                    }

                    break;


                case "2":
                    Console.WriteLine("exchange dollars for hryvnias");
                    Console.Write("how much you want to exchange: ");

                    exchangeCurrenceCount = Convert.ToSingle(Console.ReadLine());

                    if (dollarsInWallet >= exchangeCurrenceCount)
                    {
                        dollarsInWallet -= exchangeCurrenceCount;
                        grivnesInWallet += exchangeCurrenceCount * usdToGri;
                    }
                    else
                    {
                        Console.WriteLine("dollar amount not available");
                    }
                    break;
                default:
                    Console.WriteLine("the wrong operation was selected");
                    break;
            }

            Console.WriteLine($"your balance: {grivnesInWallet} hryvnias " + $" {dollarsInWallet} dollars");
        
        }
    }
}