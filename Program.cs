using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;



namespace DigitsSum
{
    class Program
    {
        static int[] GetDigits(int x)
        {
            var result = new List<int>();
            while (x > 0)
            {
                result.Add(x % 10);
                x = x / 10;
            }
            return result.ToArray();
        }

        static int GetDigitsSum(int x)
        {
            var digits = GetDigits(x);
            var sum = 0;
            for (int i = 0; i < digits.Length; i++)
                sum += digits[i];

            return sum;
        }


        static void Main1()
        {
            const int x_min = 100;
            const int x_max = 200;
            var sums = new List<int>();
            for (int x = x_min; x <= x_max; x++)
            {
                var x0 = x;
                var thread = new Thread(() =>
                        {
                            lock (sums) //последующие строки в фигурных скобках выполняются как единое целое
                            {
                                Console.Write("Sum({0})", x);
                                var sum = GetDigitsSum(x0);
                                Console.WriteLine(sum);
                            }
                        });
                thread.Start();
            }
            Console.WriteLine("Total sum {0}", sums.Sum());
            Console.ReadLine();
        }

        static void Main()
        {
            const int x_min = 100;
            const int x_max = 200;
            var sums = new List<int>();
            for (int x = x_min; x <= x_max; x++)
            {
                var sum = GetDigitsSum(x);
                sums.Add(sum);
                Console.Write("Sum{0} = ", x);
                Console.WriteLine(sum);

            }
            Console.WriteLine("Total sum {0}", sums.Sum());
            Console.ReadLine();
        }




    }
}

