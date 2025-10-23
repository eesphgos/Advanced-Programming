using System;
class lost
{
    static void sort(ref int[] numb2,int rate)
    {
        int b = 0;
       for(int a = 0; a < numb2.Length; a++)
        {
            if (numb2[a] >= 0 && numb2[a] == rate) { b = 1; }
        }
        if (b == 0) { Console.WriteLine(rate);return; }
        sort(ref numb2, rate + 1);
    }
    static void Main()
    {
        int[] numb = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        sort(ref numb,1);

    }
}
