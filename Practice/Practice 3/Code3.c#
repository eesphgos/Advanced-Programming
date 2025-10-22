using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

class Textfileprocessor
{
    public string path;
    string contain;
    public int size;

    public Textfileprocessor(string path)
    {
        this.path = path;
        this.contain = File.ReadAllText(path);
        this.size =(int) File.ReadAllBytes(path).Length;
    }
    public bool ContainText(string text)
    {
        bool exist = contain.Contains(text);
        if (exist)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ReplaceText(string oldtext,string newtext)
    {

        int number = contain.IndexOf(oldtext);
        char[] first = new char[number];
        char[] end = new char[contain.Length - number - oldtext.Length];
        char[] txt = contain.ToCharArray();
        //Console.WriteLine($"index = {number} ,contain = {contain.Length},old length = {oldtext.Length}");
        if(number >= 0)
        {
            for(int i = 0; i < contain.Length; i++)
            {
                if (i < number)
                {
                    first[i] = txt[i];
                }
                else if(i>=number && i < number + oldtext.Length)
                {
                    continue;
                }
                else
                {
                    end[i - number - oldtext.Length] = txt[i];
                }
            }
            string news = string.Join((""),first) + newtext + string.Join((""), end);
            File.WriteAllText(path, news);
            contain = news;
        }
    }
    public void RemoveText(string Text)
    {
        int number = contain.IndexOf(Text);
        char[] first = new char[number];
        char[] end = new char[contain.Length - number - Text.Length];
        char[] txt = contain.ToCharArray();
        //Console.WriteLine($"index = {number} ,contain = {contain.Length},old length = {oldtext.Length}");
        if (number >= 0)
        {
            for (int i = 0; i < contain.Length; i++)
            {
                if (i < number)
                {
                    first[i] = txt[i];
                }
                else if (i >= number && i < number + Text.Length)
                {
                    continue;
                }
                else
                {
                    end[i - number - Text.Length] = txt[i];
                }
            }
            string news = string.Join((""), first)+ string.Join((""), end);
            File.WriteAllText(path, news);
            contain = news;
        }
    }
    public int Countocurness(string text)
    {
        string txt = contain+" ";
        int sum = 0;
        while (true)
        {
                int index = txt.IndexOf(text);
                sum++;
                txt=txt.Substring(index+1);

                if(index == -1)
                {
                    return sum-1;
                }
        }
    }
    public int Getlength()
    {
        return size;
    }
    public void ConverttoUpper()
    {
        char[] text = contain.ToCharArray();

        for(int i=0;i<text.Length;i++)
        {
            if (char.IsLower(text[i]))
            {
                text[i] = char.ToUpper(text[i]);
            }
        }
        string txt = string.Join((""),text);
        File.WriteAllText(path,txt);
        contain = txt;
    }
    public void Removeemptylines()
    {
        string[] line = contain.Split("\n",StringSplitOptions.RemoveEmptyEntries);
        string file=null;
        for (int i = 0; i < line.Length; i++)
        {

            if (!string.IsNullOrWhiteSpace(line[i]))
            {
                file += line[i]+"\n";
            }
            File.WriteAllText(path, file);
        }
    }
    public void Appedtext(string text)
    {
        File.AppendAllText(path,text);
        contain = File.ReadAllText(path);
    }
}
class Folderprocessor
{
    public Textfileprocessor[] files;
    string path;

    public Folderprocessor(string path)
    {
        this.path = path;
        this.files = new Textfileprocessor[Directory.GetFiles(path, "*.txt").Length];
        string[] filepath = Directory.GetFiles(path, "*.txt");

        for (int i = 0; i < filepath.Length; i++)
        {
            files[i] = new Textfileprocessor(filepath[i]);
        }
    }
    public List<string> Findfilecontaitext(string text)
    {
        List<string> namefile = new List<string>();
        for(int i = 0; i < files.Length; i++)
        {
            if (files[i].ContainText(text))
            {
                string filepath = files[i].path;
                char[] addres = filepath.ToCharArray();
                char[] final = new char[addres.Length-path.Length+1];
                for(int j =path.Length + 1 ; j <addres.Length ; j++)
                {
                    final[j - path.Length + 1] = addres[j];
                }
                filepath = string.Join((""),final);
                namefile.Add(filepath);
            }
        }
        return namefile;
    }
    public void Replacetextinallfiles(string oldtext,string newtext)
    {
        for(int i = 0; i < files.Length; i++)
        {
            files[i].ReplaceText(oldtext,newtext);
        }
    }
    public void RenoveTextFromAllFile(string text)
    {
        for(int i = 0; i < files.Length; i++)
        {
            files[i].RemoveText(text);
        }
    }
    public void countoccuringinallfile(string text)
    {
        int sum = 0;
        for(int i = 0; i < files.Length; i++)
        {
            sum += files[i].Countocurness(text);
        }
        Console.WriteLine(sum+" Times.");
    }
    public void getfilelenggth()
    {
        int sum = 0;
        for(int i = 0; i < files.Length; i++)
        {
            sum += files[i].Getlength();
        }
        Console.WriteLine(sum+" Bytes.");
    }
    public void converalltoupper()
    {
        for(int i = 0; i < files.Length; i++)
        {
            files[i].ConverttoUpper();
        }
    }
    public void removeemptylinesfromallfiles()
    {
        for(int i = 0; i < files.Length; i++)
        {
            files[i].Removeemptylines();
        }
    }
    public void appendtexttoallfiles(string text)
    {
        for(int i = 0; i < files.Length; i++)
        {
            files[i].Appedtext(text);
        }
    }
}
class Program
{
    static void Main()
    {
        string adress = null;
        while (true)
        {
            Console.WriteLine("Enter a directory adress to work with it...");
            adress =Console.ReadLine();
            if (Directory.Exists(adress))
            {
                break;
            }
            Console.WriteLine("Directory adress is incorect pleas try again");
        }
        Folderprocessor a = new Folderprocessor(adress);
        if (a.files.Length == 0)
        {
            Console.WriteLine("corent directory has no file of txt format.");
            return;
        }
        while (true)
        {
            
            Console.WriteLine("################################################################################");
            Console.WriteLine("Key word :");
            Console.WriteLine("Find\"....\"");
            Console.WriteLine("Replace\"old..\",\"new...\"");
            Console.WriteLine("Remove\"....\"");
            Console.WriteLine("Count\".....\"");
            Console.WriteLine("Length");
            Console.WriteLine("Uppercase");
            Console.WriteLine("RemoveEmptyLines");
            Console.WriteLine("Append\".....\"");
            Console.WriteLine("Exit");

            string[] order =Console.ReadLine().Split("\"");
            Console.Clear();
            try
            {
                switch (order[0])
                {
                    case "Find":
                        List<string> name = a.Findfilecontaitext(order[1]);
                        if (name.Count == 0)
                        {
                            Console.WriteLine("this text not exsist in any file");
                        }
                        for(int i = 0; i < name.Count; i++)
                        {
                            Console.WriteLine(name[i]);
                        }
                        break;
                    case "Replace":
                        a.Replacetextinallfiles(order[1], order[3]);
                        Console.WriteLine("done");
                        break;
                    case "Remove":
                        a.RenoveTextFromAllFile(order[1]);
                        Console.WriteLine("done");
                        break;
                    case "Count":
                        a.countoccuringinallfile(order[1]);
                        break;
                    case "Length":
                        a.getfilelenggth();
                        break;
                    case "Uppercase":
                        a.converalltoupper();
                        Console.WriteLine("done");
                        break;
                    case "RemoveEmptyLines":
                        a.removeemptylinesfromallfiles();
                        Console.WriteLine("done");
                        break;
                    case "Append":
                        a.appendtexttoallfiles(order[1]);
                        Console.WriteLine("done");
                        break;
                    case "Exit":
                        Console.WriteLine("Thank you for choosing my app to use ;)");
                        return;
                    default:
                        Console.WriteLine("Your choss is incorect try again.");
                        break;

                }
            }
            catch(Exception err)
            {
                Console.WriteLine("Your entery format is incorect be careful");
            }
        }
    }
}
