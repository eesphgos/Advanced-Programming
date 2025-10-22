using System;
using System.Reflection.Metadata;
using static System.Console;

class LivingBeing
{
    protected string name { get; set; }
    protected int age { get; set; }
    protected int positionX { get;}
    protected int positionY { get;}
    public static List<LivingBeing> Livings = new List<LivingBeing>();

    public LivingBeing(string name, int age, int positionX, int positionY)
    {
        this.name = name;
        this.age = age;
        this.positionX = positionX;
        this.positionY = positionY;
    }
    public static void AddTree(string name, int age, int positionX, int positionY, int height, int fruitcount)
    {
        Livings.Add(new Tree(name, age, positionX, positionY, height, fruitcount));
    }
    public static void AddInsect(string name, int age, int positionX, int positionY, int harmfully, int eyesrange)
    {
        Livings.Add(new Insect(name, age, positionX, positionY, harmfully, eyesrange));
    }
    public virtual int CalculateValue()
    {
        
        int sum = 0;
        foreach(LivingBeing i in Livings)
        {
            sum += i.CalculateValue();
        }
        return sum;
    }
    public static void delinsect(int y,int x)
    {
        for(int i = 0; i < Livings.Count; i++)
        {
            if (Livings[i].positionY == y && Livings[i].positionX == x)
            {
                Livings.Remove(Livings[i]);
            }
        }
    }
    public static void upTree(int y,int x)
    {
        for (int i = 0; i < Livings.Count; i++)
        {
            if (Livings[i].positionY == y && Livings[i].positionX == x)
            {
                Tree a = (Tree)Livings[i];
                a.addfruit();
            }
        }
    }
}
class Tree : LivingBeing
{
    int height { get; set; }
    int fruitcount { get; set; }
    
    public Tree(string name, int age, int positionX, int positionY,int height,int fruitcount):base(name,age,positionX,positionY)
    {
        this.height = height;
        this.fruitcount = fruitcount;
        if (height < 1 || age < 1 || fruitcount < 0) { WriteLine("invalid entery");throw new Exception(); }
    }

    public override int CalculateValue()
    {
        return (5*fruitcount)+(10*age);
    }
    public void addfruit()
    {
        fruitcount += fruitcount / 5;
    }
}
class Insect : LivingBeing
{
    int harmfully { get; set; }
    int eyesrange { get; set; }

    public Insect(string name, int age, int positionX, int positionY, int harmfully, int eyesrange) : base(name, age, positionX, positionY)
    {
        this.harmfully = harmfully;
        this.eyesrange = eyesrange;
        if (harmfully < 1 || age < 1 || eyesrange < 0) { WriteLine("invalid entery"); throw new Exception(); }
    }
    public override int CalculateValue()
    {
        return (age*harmfully*-1);
    }
}
class Tool
{
    string name { get; set; }
    protected int usage { get; set; }
    protected static List<Tool> tools = new List<Tool>();
    public Tool(string name, int usage)
    {
        this.name = name;
        this.usage = usage;
    }
    public static void Addspray(string name, int usage, int sprayrange)
    {
        tools.Add(new Spray(name, usage, sprayrange));
    }
    public static void Addferzili(string name, int usage, int ferzilirange)
    {
        tools.Add(new Ferzili(name, usage, ferzilirange));
    }
    public virtual void use(int x,int y)
    {

    }
    public void useee(string name)
    {
        foreach(Tool i in tools)
        {
            if (i.name == name)
            {
                while (true)
                {
                    WriteLine("enter location to use(x y)");
                    try
                    {
                        string loc = ReadLine();
                        string[] lo = loc.Split(" ");
                        int x = int.Parse(lo[0]);
                        int y = int.Parse(lo[1]);

                        if (x > 10 || x < 0 || y > 10 || y <0) { WriteLine("wrong locatin out of the range");continue; }
                        i.use(x, y);
                    }
                    catch(Exception e) { WriteLine(e.Message); }
                    return;
                }
                
            }
        }
        WriteLine("Tool not found");
    }
}
class Spray : Tool
{
    int sprayrange { get; set; }

    public Spray(string name,int usage,int sprayrange):base(name,usage)
    {
        this.sprayrange = sprayrange;
        if (usage < 1 || sprayrange < 1) { WriteLine("invalid entry");throw new Exception(); }
    }
    public override void use(int x,int y)
    {
        if (usage <= 0) { WriteLine("This tool is broken and cant use it"); }
        usage--;
        for(int i = 0; i < 11; i++)
        {
            int yy = i;
            for(int j = 0; j < 11; j++)
            {
                int xx = j;
                if (Math.Sqrt(Math.Pow((xx - x),2) + Math.Pow((yy - y),2)) <= sprayrange)
                {
                    if (Program.gerd[yy][xx] == 'I') 
                    {
                        LivingBeing.delinsect(yy,xx);
                        Program.gerd[yy][xx] = 'O'; 
                    }
                                    
                }
            }
        }
    }
}
class Ferzili : Tool
{
    int ferzilirange { get; set; }

    public Ferzili(string name, int usage, int ferzilirange) : base(name, usage)
    {
        this.ferzilirange = ferzilirange;
        if (usage < 1 || ferzilirange < 1) { WriteLine("invalid entry"); throw new Exception(); }
    }
    public override void use(int x,int y)
    {
        if (usage <= 0) { WriteLine("This tool is broken and cant use it"); }
        usage--;
        for (int i = 0; i < 11; i++)
        {
            int yy = i;
            for (int j = 0; j < 11; j++)
            {
                int xx = j;
                if (Math.Sqrt(Math.Pow((xx - x), 2) + Math.Pow((yy - y), 2)) <= ferzilirange)
                {
                    if (Program.gerd[yy][xx] == 'T')
                    {
                        LivingBeing.upTree(yy, xx);
                    }

                }
            }
        }
    }
}
static class Count
{
    public static int CountType<T>(this List<T> total)
    {
        return total.Count;
    }
}
public class Program
{
    public static List<List<char>> gerd = new List<List<char>>();
    public static void Main()
    {
        
        for(int i = 0; i <= 10; i++)
        {
            gerd.Add(new List<char>());
        }
        foreach(List<char> i in gerd)
        {
            for(int j = 0; j <= 10; j++)
            {
                i.Add('O');
            }
        }

        while (true)
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            
            WriteLine($"________________ TLB : {LivingBeing.Livings.CountType()}__________________");
            WriteLine("1-Add Living Being");
            WriteLine("2-Add Tool");
            WriteLine("3-Use Tool");
            WriteLine("4-Calculate Garden Value");
            WriteLine("5-Show garden");
            WriteLine("6-Exit");
            ForegroundColor = ConsoleColor.Red;

            int dis = 0;
            try { dis = int.Parse(ReadLine()); }
            catch(Exception e) { WriteLine(e.Message); }
            Clear();
            switch (dis) 
            {
                case 1:
                    WriteLine("Enter type of liveing being (Tree,Insect)");
                    string type = ReadLine();
                    switch (type)
                    {
                        case "Tree":
                            WriteLine("Enter the propeties this format('Name' 'Age' 0<= 'X' <=10  0<= 'Y' <= 10 'Height' 'Fruitcount')");
                            string a = ReadLine();
                            string[] pro = a.Split(" ");
                            try 
                            {
                                string name = pro[0];
                                int age = int.Parse(pro[1]);
                                int X = int.Parse(pro[2]);
                                int Y = int.Parse(pro[3]);
                                int height = int.Parse(pro[4]);
                                int Fruit = int.Parse(pro[5]);

                                if (X < 0 || X > 10 || Y < 0 || Y > 10)
                                {
                                    WriteLine("invalid location");break;
                                }
                                if (gerd[Y][X] != 'O')
                                {
                                    WriteLine("this location is full");break;
                                }
                                LivingBeing.AddTree(name,age,X,Y,height,Fruit);
                                gerd[Y][X] = 'T';
                            }
                            catch(Exception e) { WriteLine(e.Message); }
                            break;
                        case "Insect":
                            WriteLine("Enter the propeties this format('Name' 'Age' 0<= 'X' <=10  0<= 'Y' <= 10 'Harmfully' 'eyes range')");

                            string aa = ReadLine();
                            string[] proa = aa.Split(" ");
                            try
                            {
                                string name = proa[0];
                                int age = int.Parse(proa[1]);
                                int X = int.Parse(proa[2]);
                                int Y = int.Parse(proa[3]);
                                int harmfull = int.Parse(proa[4]);
                                int eaysrange = int.Parse(proa[5]);

                                if (X < 0 || X > 10 || Y < 0 || Y > 10)
                                {
                                    WriteLine("invalid location"); break;
                                }
                                if (gerd[Y][X] != 'O')
                                {
                                    WriteLine("this location is full"); break;
                                }
                                LivingBeing.AddInsect(name, age, X, Y,harmfull,eaysrange);
                                gerd[Y][X] = 'I';
                            }
                            catch (Exception e) { WriteLine(e.Message); }
                            break;
                        default:
                            WriteLine("wrong type");
                            break;
                    }
                    break;
                case 2:
                    WriteLine("Enter tool type(Spray , Fertilizer)");
                    string b = ReadLine();
                    switch (b)
                    {
                        case "Spray":
                            WriteLine("Enter the propeties this format('Name' 'Usage' 'Spray range')");
                            string a = ReadLine();
                            string[] pro = a.Split(" ");
                            try
                            {
                                string name = pro[0];
                                int Usage = int.Parse(pro[1]);
                                int range = int.Parse(pro[2]);

                                Tool.Addspray(name, Usage, range);
                            }
                            catch (Exception e) { WriteLine(e.Message); }
                            break;
                        case "Fertilizer":
                            WriteLine("Enter the propeties this format('Name' 'Usage' 'Fertilizer range')");
                            string aa = ReadLine();
                            string[] proa = aa.Split(" ");
                            try
                            {
                                string name = proa[0];
                                int Usage = int.Parse(proa[1]);
                                int range = int.Parse(proa[2]);

                                Tool.Addferzili(name, Usage, range);
                            }
                            catch (Exception e) { WriteLine(e.Message); }
                            break;
                        default:
                            WriteLine("Invalid type");
                            break;
                    }
                    break;
                case 3:
                    WriteLine("enter tool name to use");
                    string tool = ReadLine();
                    new Tool("", 1).useee(tool);
                    break;
                case 4:
                    
                    WriteLine("whole value : "+new LivingBeing("",-1,-1,-1).CalculateValue()+" $");

                    break;
                case 5:
                    ForegroundColor = ConsoleColor.Green;

                    foreach (List<char> i in gerd)
                    {
                        foreach(char j in i)
                        {
                            Write(j+" ");
                        }
                        WriteLine();
                    }
                    ForegroundColor = ConsoleColor.DarkYellow;

                    break;
                case 6:
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("goodbye");
                    return;
                    break;
                default:
                    WriteLine("Try again");
                    break;

            }

        }
    }
}
