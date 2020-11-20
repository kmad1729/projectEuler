/*
 prb10.cs
 sum of all the primes below 2 million (2 000 000)
*/

namespace projectEuler
{
    using System;

    public class Prb10
    {
        public static long Run()
        {
            int N = 2000000;
            // int N = 10;
            N += 1;
            bool[] sieve = new bool[N];

            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }

            sieve[0] = false;
            sieve[1] = false;

            for (int i = 2; i < sieve.Length; i++)
            {
                if (!sieve[i])
                {
                    // already a composite. no need to proceed
                    continue;
                }

                // set multiples of i to false;
                int multiplier = 2;
                while (multiplier * i < N)
                {
                    sieve[multiplier*i] = false;
                    multiplier++;
                }
            }

            // PrintSieve(sieve);
            return EvaluateResult(sieve);
        }

        public static void PrintSieve(bool[] sieve)
        {
            int colsize = 30;
            int i = 0;
            string compositeChar = "*";
            while (i < sieve.Length-1)
            {
                if (i % colsize == 0)
                {
                    Console.WriteLine();
                }

                if (sieve[i])
                {
                    Console.Write($"{i,4} ");
                }
                else
                {
                    Console.Write($"{compositeChar,4} ");
                }
                i++;
            }
            Console.WriteLine();
        }

        public static long EvaluateResult(bool[] sieve)
        {
            long result = 0;
            for(int i = 0; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    result += i;
                }
            }
            return result;
        }

    }
}