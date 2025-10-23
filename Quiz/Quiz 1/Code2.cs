
using System;
using System.ComponentModel;
using System.Reflection.Metadata;

class Q
{
    static void Main()
    {

        int n = -1;
        int[] stak = new int[1000];
        int counter = 0;
        int[] del = new int[1000];
        int delcount = 0;
        do
        {
            n = int.Parse(Console.ReadLine());
            
            switch (n) {

                case 0:

                    break;

                case 1:

                    stak[counter] = int.Parse(Console.ReadLine());
                    counter++;

                    break;

                case 2:
                    del[delcount] = stak[counter -1];
                    delcount++;
                    counter--;
                    break;
                    
            }
        } while (n != 0);

        for (int i = 0; i < delcount; i++)
        {
            Console.WriteLine(del[i] + " ");
        }

    }
}
