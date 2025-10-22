using System;

class river
{

    static void Main()
    {

        long t = long.Parse(Console.ReadLine());

        for (long i = 0; i < t; i++)
        {
            long situation = 1;
            long jump = 0;
            long[] nmk = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            string rriv = "1 " + Console.ReadLine() + " 1 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4";
            long[] river = Array.ConvertAll(rriv.Split(), long.Parse);

            long jjjjump = 0;
            if (nmk[1] > nmk[0]) { Console.WriteLine("YES"); continue; }
            for (long j = 0; j <= nmk[0] + 1; j++)
            {
                if (jump > 0) { jump--; continue; }
                //Console.WriteLine(j+"----"+jump);
                if (j > nmk[0]) { jjjjump = 1; continue; }
                if (situation == 1)
                {
                    long sit = 0, sitb = 0;
                    for (long k = nmk[1]; k > 0; k--)
                    {

                        if (k + j > nmk[0]) { jjjjump = 1; break; }
                        if (river[j + k] == 1 && river[j] != 0 && river[j] != 2)
                        {
                            jump = k - 1;
                            situation = 1;
                            sit = 1;
                            break;
                        }
                    }
                    for (long k = nmk[1]; k > 0; k--)
                    {
                        if (sit == 1) { break; }
                        if (river[j + k] == 0)
                        {
                            //Console.WriteLine();
                            jump = k - 1;
                            situation = 0;
                            sitb = 1; nmk[2]--;
                            break;
                        }
                    }
                    if(sitb == 1) { continue; }
                    if (sitb != 1 && sit != 1) { situation = 2; }

                }
                if (situation == 0)
                {

                    if (river[j + 1] == 1)
                    {
                        situation = 1;

                    }
                    else if (river[j + 1] == 0)
                    {
                        situation = 0;
                        nmk[2]--;

                    }
                    else if (river[j + 1] == 2)
                    {
                        situation = 2;
                        nmk[2] = -1;

                    }
                }
                if (situation == 2)
                {
                    nmk[2] = -1;
                    break;
                }

                if (nmk[2] < 0) { break; }
            }
            if (jjjjump == 1) { Console.WriteLine("YES"); continue; }
            if (nmk[2] < 0) { Console.WriteLine("NO");continue; }
            else Console.WriteLine("YES");

        }
    }
}
