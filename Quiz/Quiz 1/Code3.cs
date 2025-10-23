using System;

class Q
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = Array.ConvertAll(Console.ReadLine().Split(),int.Parse);

        int[] up = new int[input.Length];
        int[] down = new int[input.Length];
      
        for (int i = 0; i < n; i++)
        {
            up[i] = input[i];
            down[i] = input[i];
        }

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (up[j] <= up[j + 1])
                {
                    int hold = up[j];
                    up[j] = up[j + 1];
                    up[j + 1] = hold;
                }
            }
        }
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (down[j] >= down[j + 1])
                {
                    int hold = down[j];
                    down[j] = down[j + 1];
                    down[j + 1] = hold;
                }
            }
        }

        int summ = 0;
        for (int i = 0; i < n; i++)
        {
            if (up[i] <= 0) { up[i]=up[i] * -1; }
            int a = input[i] - up[i];
            if (a <= 0)
            {
                a = a * -1;
            }
            summ += a;
        }
        int sumn = 0;
        for (int i = 0; i < n; i++)
        {   
            if (up[i] <= 0) { down[i] = down[i] * -1; }

            int a = input[i] - down[i];
            if (a <= 0)
            {
                a = a * -1;
            }
            sumn += a;
        }
        if (summ >= sumn)
        {

            for (int i = 0; i < n; i++)
            {
                Console.Write((input[i] - down[i])*-1 + " ");
            }
            
        }
        if (summ < sumn)
        {

            for (int i = 0; i < n; i++)
            {
                Console.Write((input[i] - up[i])*-1 + " ");
            }

        }
    }
}
