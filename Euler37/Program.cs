using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler37
{
    class Program
    {

        static int[] pow10 = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        static void Main(string[] args)
        {
            int n = 10;

            List<int> results = new List<int>();

            int truncatableCount = 0;

            while (truncatableCount < 11)
            {
                n++;
                int p = n;
                while(p > 0  && isPrime(p))
                {
                    p = p / 10;
                }
                if (p > 0)
                    continue;

                p = n;
                int rank = (int) Math.Truncate(Math.Log10(n));
                int pow = pow10[rank];
                while(p > 0 && isPrime(p))
                {
                    pow = pow10[rank];
                    p = p % pow;
                    rank--;
                }
                if (p > 0)
                    continue;

                Console.WriteLine(n);
                truncatableCount++;
                results.Add(n);
            }
            Console.WriteLine(results.Sum());
            Console.ReadLine();
        }

        public static bool isPrime(int n)
        {
            if (n == 2)
                return true;
            if (n < 2 || n % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
