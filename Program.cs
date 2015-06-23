using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 topNumber;
            int numberOfPrimes = 1;
            List<int> myPrimes = new List<int>();
            bool isItPrime = false;
            CustomStopwatch sw = new CustomStopwatch();

            try
            {
                topNumber = Convert.ToInt32(args[0]);
            } catch (IndexOutOfRangeException) 
            {
                topNumber = 101;
            }

            sw.Start();
            Console.WriteLine("Primes from 2 to " + topNumber + ":");
            myPrimes.Add(2);
            
            
            for (int primeCheck = 3; primeCheck < topNumber + 1; primeCheck++)
            {
                if (primeCheck % 2 != 0) //discard even numbers.
                {
                    isItPrime = checkThroughList(primeCheck, myPrimes);
                    if (isItPrime)
                    {
                        numberOfPrimes++;
                        myPrimes.Add(primeCheck);
                        printNumbers(primeCheck);
                    }
                }
            }

            sw.Stop();
            //Write out all the primes
            //printList(myPrimes);

            Console.WriteLine("");
            Console.WriteLine("There are " + numberOfPrimes + " primes from 2 to " + topNumber + ". It took " + sw.ElapsedMilliseconds + "ms to calculate.");
            Console.WriteLine("");
            if (topNumber == myPrimes[myPrimes.Count - 1])
            {
                Console.WriteLine(topNumber + " is a prime number");
            }
            else
            {
                Console.WriteLine(topNumber + " is not a prime number");
            }
        }

        public static int squareRoundUp(Int64 i)
        {
            int result;
            double j = Math.Sqrt(i);
            result = (int)Math.Ceiling(j);
            return result;
        }

        public static bool checkThroughList(int numberToCheck, List<int> listToCheckAgainst)
        {
            int i = 0;
            while (i < Math.Ceiling((double)listToCheckAgainst.Count / 2))
            {
                if (numberToCheck % listToCheckAgainst[i] == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        public static void printList(List<int> myList) 
        {
            foreach (int i in myList)
            {
                Console.Write(i);
                if (i < 10)
                {
                    Console.Write("       ");
                }
                else if(i < 100)
                {
                    Console.Write("      ");
                }
                else if(i < 1000)
                {
                    Console.Write("     ");
                }
                else if (i < 10000)
                {
                    Console.Write("    ");
                }
                else if (i < 100000)
                {
                    Console.Write("   ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
        }

        public static void printNumbers(int i)
        {
            Console.Write(i);
            if (i < 10)
            {
                Console.Write("       ");
            }
            else if (i < 100)
            {
                Console.Write("      ");
            }
            else if (i < 1000)
            {
                Console.Write("     ");
            }
            else if (i < 10000)
            {
                Console.Write("    ");
            }
            else if (i < 100000)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write("  ");
            }
        }
    }

    public class CustomStopwatch : Stopwatch
    {

        public DateTime? StartAt { get; private set; }
        public DateTime? EndAt { get; private set; }


        public void Start()
        {
            StartAt = DateTime.Now;

            base.Start();
        }

        public void Stop()
        {
            EndAt = DateTime.Now;

            base.Stop();
        }

        public void Reset()
        {
            StartAt = null;
            EndAt = null;

            base.Reset();
        }

        public void Restart()
        {
            StartAt = DateTime.Now;
            EndAt = null;

            base.Restart();
        }

    }
}
