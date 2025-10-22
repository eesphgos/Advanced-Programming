using System;

class tamrin1
{
           static void Main ()
    {
        int n = int.Parse(Console.ReadLine());
        long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        //int numofpalindorm = 0;
        //for (int b = 0; b < n / 2; b++)
        //{
        //    if (input[b] == input[n - b - 1])
        //    {
        //        numofpalindorm++;
        //    }
        //}

        //if (numofpalindorm == n / 2) { numofpalindorm = 1; }
        //else { numofpalindorm = 0; }


        for (int j=0;j < input.GetLength(0) - 1; j++) {
            for (int i = 0; i < input.GetLength(0)-1;i++)
            {
                if (input[i] > input[i + 1])
                {
                    long hold;
                    hold = input[i];
                    input[i] = input[i + 1];
                    input[i + 1] = hold;
                }
            }
         }

        for (int k = 0; k < n; k++)
        {
            Console.Write(input[k] + " ");
        }

        Console.WriteLine("");

        for (int g=n-1; g >= 0;g--)
        {
            Console.Write(input[g] + " ");
        }
        Console.WriteLine("");

        int num;
        if (n % 2 == 1) { num = n / 2 + 1; }
        else { num = n / 2; }

        for (int a = 0; a < num; a++)
        {
            Console.Write(input[a] + " ");
            if (n % 2 == 1 && a == num - 1) { break; }
            Console.Write(input[n - a - 1] + " ");
        }

        int numofpalindorm = 0;
        for (int b = 0; b < n / 2; b++)
        {
            if (input[b] == input[n - b - 1])
            {
                numofpalindorm++;
            }
        }

        if (numofpalindorm == n / 2) { numofpalindorm = 1; }
        else { numofpalindorm = 0; }

        Console.WriteLine("");
        Console.WriteLine(numofpalindorm);


        for ( int z = 0; z < n; z++)
        {

            int prinme = 0;

            for (int x =1; x < input[z]; x++)
            {
                if (input[z] % x == 0) { prinme++; }
            }
            if (prinme == 1)
            {
                Console.Write(input[z] + " ");
            }
        }
        Console.WriteLine("");

        long sum = 0, fib1 = 1, fib2 = 1, fib3 = 0;

        for (int r = 0; r < n; r++)
        {
            sum += input[r];
        }

        for (int p = 0; p < (sum % 30) -2; p++)
        {
            fib3 = fib2 + fib1;
            fib1 = fib2;
            fib2 = fib3;
  
        }

        Console.WriteLine(fib3);


    }
}




