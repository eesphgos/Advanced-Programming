using System;

class taxi
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        
        int[] team = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
      
        int t1=0, t2=0, t3=0, t4=0;

        for (int i = 0; i < number; i++)
        {
            if (team[i] == 4) { t4++; }
            else if (team[i] == 3) { t3++; }
            else if (team[i] == 2) { t2++; }
            else if (team[i] == 1) { t1++; }
        }
        int total = 0;
        total += t4;
        total += t2 / 2;
        
        
        
        while(t1 > 0 && t3 > 0)
        {


            total++;
            t1--;
            t3--;
        }
        
        total += t3;
             
        if (t2 % 2 == 1) { t1 += 2; }
        total += t1 / 4;
        if(t1 % 4 != 0) { total++; }
 //Console.WriteLine(t1+"-"+t2+"-"+t3+"-"+t4);
        Console.WriteLine(total);
        return;
        
        
        
    }
}
