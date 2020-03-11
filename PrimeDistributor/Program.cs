using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PrimeDistributor
{
    class Program
    {

        static void Main(string[] args)
        {

            string[] primesQueue = {
                  "http://localhost:44314/api/prime",
                  "http://localhost:44344/api/prime"
                   };

            int iPrimesQue = 0;
            string input = "Booting primes";

            while (!input.Equals("quit"))
            {
                Console.Write("Enter a number: ");
                input = Console.ReadLine();

                if (CheckInputForNumbers(input))
                {
                    int userNumber = int.Parse(input);

                    Console.WriteLine("Enter 1 if you want to find out if your number is a prime");
                    Console.WriteLine("Enter 2 if you want to add all primes that your number contains");

                    input = Console.ReadLine();

                    Console.WriteLine(input);
                    if (input.Equals("1"))
                    {

                        Console.WriteLine("Thanos did nothing wrong");
                        try
                        {
                            if (iPrimesQue >= 2) iPrimesQue = 0;

                            Console.WriteLine("I used stones to destroy stones");
                            IsNumberAPrime(primesQueue[iPrimesQue], userNumber);
                        }
                        catch
                        {
                            Console.WriteLine("The server is down, requesting the next server...");

                            iPrimesQue += 1;
                            if (iPrimesQue >= 2) iPrimesQue = 0;
                            IsNumberAPrime(primesQueue[iPrimesQue], userNumber);
                        }
                        Console.WriteLine("APiUrl: " + primesQueue[iPrimesQue] + "APiNumber: " + (iPrimesQue + 1));
                        iPrimesQue += 1;
                    }
                    /*
                    if (input.Equals("2"))
                    {
                        AddPrimes(userNumber);
                    }*/
                }
            }
        }

        public static bool CheckInputForNumbers(string input)
        {
            return input.All(c => c >= '0' && c <= '9');
        }


        public static void IsNumberAPrime(string apiUrl, int number)
        {
            if (!string.IsNullOrEmpty(apiUrl))
            {
                Console.WriteLine("Setting up client");
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;

                Console.WriteLine(apiUrl + "/" + number);
                var json = client.DownloadData(apiUrl + "/" + number);
                Console.WriteLine("something went wrong spiderman");
                if (json != null)
                {

                    Console.WriteLine("Responded");
                    string download = Encoding.ASCII.GetString(json);
                    bool isPrime = (new JavaScriptSerializer()).Deserialize<bool>(download);
                    if (isPrime)
                    {
                        Console.WriteLine("Your number is indeed a prime! :)");
                    }
                    else
                    {
                        Console.WriteLine("Your number is not a prime :(");
                    }
                }
                else
                    Console.WriteLine("Something went wrong, please try again later");
            }

            Console.WriteLine("after if in IsNumberAPrime");

        }

        public static void AddPrimes(string queue, int number)
        {

        }
    }
}
