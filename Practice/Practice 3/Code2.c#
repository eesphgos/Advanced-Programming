using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Xml.Linq;

enum Animal
{
    Monkey=10,
    Lion,
    Elepgant,
    Bear,
    Tiger,
    Giraffe
}
class Zoo
{
    int Id;
    Animal type;
    string name;
    string location;
    string[] food;

    static int animalcount=1;

    public Zoo(Animal type, string name, string location, string[] food)
    {
        Id= animalcount;
        this.type = type;
        this.name = name;
        this.location = location;
        this.food = food;
        animalcount = animalcount + 1;
    }

    public bool Savetofile()
    {
        
        int sit =IsValidName(name);
        if(sit == 0)
        {
            return true;
        }
        int filee = (int)type;
        string file = filee.ToString();

        string foody = string.Join("-", food);
        File.AppendAllText(file, $"{Id} {name} {location} {foody}\n\n");
        return false;
    }
    public int IsValidName(string AnimName)
    {
        char[] namee = AnimName.ToCharArray();
        try
        {
            for (int i = 0; i < namee.Length; i++)
            {
                if (!char.IsLetter(namee[i]))
                {
                    throw new Exception();
                }
            }
            for (int i = 10; i < 16; i++)
            {
                string fil = i.ToString();
                if (File.Exists(fil))
                {
                    string[] lineoffile = File.ReadAllLines(fil);
                    for (int j = 0; j < lineoffile.Length; j+=2)
                    {

                        {
                            string[] detale = lineoffile[j].Split();
                            {
                                if (detale[1] == AnimName)
                                {
                                    throw new Exception();
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            Console.WriteLine("name not valid :/");
            return 0;
        }
        return 1;
    }

    public static void Change(string nam,string locat)
    {
        
        char[] namee = nam.ToCharArray();
        try
        {
            for (int i = 0; i < namee.Length; i++)
            {
                if (!char.IsLetter(namee[i]))
                {
                    throw new Exception();
                }
            }
        }
        catch
        {
            Console.WriteLine("incorect name");
        }
        for (int i = 10; i < 16; i++)
        {
            string fil = i.ToString();
            if (File.Exists(fil))
            {
                string[] lineoffile = File.ReadAllLines(fil);
                for (int j = 0; j < lineoffile.Length; j += 2)
                {
                    string[] detale = lineoffile[j].Split();
                    {
                        if (detale[1] == nam)
                        {
                            detale[2] = locat;
                            lineoffile[j] = string.Join((" "),detale);
 ;
                            File.WriteAllLines(fil, lineoffile);
                            return;
                        }
                    }
                }
            }
        }
        Console.WriteLine("animal not found");
        return;

    }
    public static void Change(string nam,string[] foody)
    {
        char[] namee = nam.ToCharArray();
        try
        {
            for (int i = 0; i < namee.Length; i++)
            {
                if (!char.IsLetter(namee[i]))
                {
                    throw new Exception();
                }
            }
        }
        catch
        {
            Console.WriteLine("incorect name");
        }
        for (int i = 10; i < 16; i++)
        {
            string fil = i.ToString();
            if (File.Exists(fil))
            {
                string[] lineoffile = File.ReadAllLines(fil);
                for (int j = 0; j < lineoffile.Length; j += 2)
                {
                    string[] detale = lineoffile[j].Split();
                    {
                        if (detale[1] == nam)
                        {
                            string newfood = string.Join(("-"),foody);
                            detale[3] = newfood;
                            lineoffile[j] = string.Join((" "), detale);
                            File.WriteAllLines(fil,lineoffile);
                            return;
                        }
                    }
                }
            }
        }
        Console.WriteLine("animal not found");
        return;
    }
    public static void Change(string nam,string locat,string[] foody)
    {
        char[] namee = nam.ToCharArray();
        try
        {
            for (int i = 0; i < namee.Length; i++)
            {
                if (!char.IsLetter(namee[i]))
                {
                    throw new Exception();
                }
            }
        }
        catch
        {
            Console.WriteLine("incorect name");
        }
        for (int i = 10; i < 16; i++)
        {
            string fil = i.ToString();
            if (File.Exists(fil))
            {
                string[] lineoffile = File.ReadAllLines(fil);
                for (int j = 0; j < lineoffile.Length; j += 2)
                {
                    string[] detale = lineoffile[j].Split();
                    {
                        if (detale[1] == nam)
                        {
                            string newfood = string.Join(("-"), foody);
                            detale[2] = locat;
                            detale[3] = newfood;
                            lineoffile[j] = string.Join((" "), detale);
                            File.WriteAllLines(fil, lineoffile);   
                            return;
                        }
                    }
                }
            }
        }
        Console.WriteLine("animal not found");
        return;
    }
    public static void AllInfo()
    {
        int sum = 0;
        int vowel = 0;
        for(int i = 10; i < 16; i++)
        {
           
            string file = i.ToString();
            if (File.Exists(file))
            {
                string[] line = File.ReadAllLines(file);
                for (int j = 0; j < line.Length; j+=2)
                {
                    string[] word = line[j].Split();
                    char[] vname = word[1].ToCharArray();
                    for (int k = 0; k < vname.Length; k++)
                    {
                        if (vname[k] == 'a' || vname[k] == 'i' || vname[k] == 'u' || vname[k] == 'o' || vname[k] == 'e' || vname[k] == 'A' || vname[k] == 'I' || vname[k] == 'U' || vname[k] == 'O' || vname[k] == 'E')
                        {
                            vowel++;
                        }
                    }
                }
                int number = line.Length/2;
                sum += number;
                Animal name = (Animal)i;
                Console.WriteLine($"{name} : {number}");
            }
            
        }
        Console.WriteLine("total =" + sum);
        Console.WriteLine("vowel letter :" + vowel);
    }
}
class Program
{
    static void Main()
    {
        int num = 0;
        while (true)
        {
            
            Console.WriteLine("Enter the number of animal you want to save");
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num < 0) { throw new Exception(); }
                break;
            }
            catch
            {
                Console.WriteLine("invalid number");
            }
        }
        
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine("Enter the type of animal (Monkey,Lion,Elepgant,Bear,Tiger,Giraffe):");
            string animaltype = "";
            Animal Anim = Animal.Lion;
            try
            {
                animaltype = Console.ReadLine();
                char[] t = animaltype.ToCharArray();
                for(int j = 0; j < t.Length; j++)
                {
                    if (char.IsDigit(t[j]))
                    {
                        throw new Exception();
                    }
                }
                Anim = (Animal)Enum.Parse(typeof(Animal), animaltype);

            }
            catch
            {
                Console.WriteLine("invalid type");
                i--;
                continue;
            }
            Console.WriteLine("Enter the name of animal:");
            string animalname = Console.ReadLine();

            Console.WriteLine("Enter the location:");
            string animallonc = Console.ReadLine();

            Console.WriteLine("Enter the food:");
            string[] animalfood = Console.ReadLine().Split(",");

            Zoo Anial = new Zoo(Anim, animalname, animallonc, animalfood);


            if (Anial.Savetofile())
            {
                i--;
            }

        }

        

        while (true)
        {
            if (num == 0) { break; }
            Console.WriteLine(" changing animal detal ...");
            Console.WriteLine(" enter number of animal you want to change...");
            int anum=0;
            try { anum = int.Parse(Console.ReadLine());}
            catch { Console.WriteLine("entry not digit");continue; }
            if (anum > num)
            {
                Console.WriteLine($"total animal in zoo : {num}");continue;
            }
            if(anum < 0) { Console.WriteLine("Invalid number"); continue; }
            for(int i = 0; i < anum; i++)
            {
                Console.WriteLine("enter the name of anima ->");
                string animname = Console.ReadLine();
                Console.WriteLine("enter the location of animal (You can push ENTER with out enter any loncation to location dont change)->>");
                string animloc = Console.ReadLine();
                Console.WriteLine("enter the food of animal (You can push ENTER with out enter any food to food dont change)->>>");
                string[] animfood = Console.ReadLine().Split(',');
                if(animloc=="" && animfood[0] == "")
                {
                    Console.WriteLine("you dont enter any thing try again");
                    i--;
                    continue;
                }
                else if(animloc == "")
                {
                    Zoo.Change(animname,animfood);
                    continue;
                }
                else if (animfood[0] == "")
                {
                    Zoo.Change(animname, animloc);
                    continue;

                }
                else
                {
                    Zoo.Change(animname, animloc, animfood);
                    continue;

                }
            }
            break;
            
        }
        

            Zoo.AllInfo();

        for(int i = 10; i < 16; i++)
        {
            string f = i.ToString();
            if (File.Exists(f))
            {
                //File.Delete(f);
            }
        }
    }
}
