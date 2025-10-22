using System;
using System.Globalization;

class cometstar
{
    static void printstar(long numb)
    {
        if (numb <= 0)
        {
            return;
        }
        Console.Write("*");

        printstar(numb - 1);
        return;
    }
    static void drawTriangle(long n)
    {
        if (n <= 0)
        {
            return;
        }

        drawTriangle(n - 1);

        printstar(n);
        Console.WriteLine("");


        return;
    }
    static void narray(long num, long k)
    {
        if (num <= 0) { return; }
        if (k % 2 == 1) { Console.WriteLine("*"); return; }
        else if (k % Math.Pow(2, num) == Math.Pow(2, num - 1))
        {
            drawTriangle(num);
            return;
        }
        narray(num - 1, k);
        return;
    }
    static void Main()
    {

        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        if (input[1] <= 0 || input[0] <= 0) { return; }

        narray(input[0], input[1]);

    }


}
