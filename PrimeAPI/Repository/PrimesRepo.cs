using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeAPI.Repository
{
    public class PrimesRepo
    {
        public int GetPrimesSum(int primes)
        {
            return 5;
        }

        public bool IsPrime(int number)
        {

            int n, i;
            int m = number / 2;
            for (i = 2; i <= m; i++)
            {
                if (number % i == 0)
                {
                    // Number is not a prime
                    return false;
                }
            }

            // Number is a prime
            return true;
        }
    }
}
