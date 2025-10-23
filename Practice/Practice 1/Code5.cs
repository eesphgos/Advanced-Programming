using System;

class rewrite
{
    static void Main()
    {
        long t = long.Parse(Console.ReadLine());

        for (long i = 0; i < t; i++)
        {
            long n = long.Parse(Console.ReadLine());
            long[] array = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long sits = 0, start = 1 ;

            long sum1 = 0;
            for (long s = 0; s < n; s++)
            {
                sum1 += array[s];
            }

            if (sum1 == 0) { Console.WriteLine("NO");continue; }

            else if (sum1 > 0)
            {
                for (long j = 0; j < n - 1; j++)
                {
                    for (long k = 0; k < n - 1; k++)
                    {
                        if (array[k] < array[k + 1])
                        {
                            long hold = array[k];
                            array[k] = array[k + 1];
                            array[k + 1] = hold;
                        }
                    }
                }
            }
            else if (sum1 < 0)
            {
                for (long j = 0; j < n - 1; j++)
                {
                    for (long k = 0; k < n - 1; k++)
                    {
                        if (array[k] > array[k + 1])
                        {
                            long hold = array[k];
                            array[k] = array[k + 1];
                            array[k + 1] = hold;
                        }
                    }
                }
            }
            Console.WriteLine("YES");
            for (long g = 0; g < n; g++)
            {
                Console.Write(array[g] + " ");
            }
            Console.WriteLine();
            


        }
    }
}
