
using System;
using System.Reflection.Metadata;
using System.Transactions;
using static System.Console;
struct File
{
    public string name;
    public int size;
    public string content;
    public Directory parent;
    public DateTime creationDate;

    public File(string name,string content,Directory parent)
    {
        this.name = name;
        this.content = content;
        this.parent = parent;
        char[] i = content.ToCharArray();
        this.size = 4 * i.Length;
        this.creationDate = DateTime.Now;
    }
}
class Directory
{
    public string name { get; set; }
    public List<File> files { get; set; }
    public List<Directory> directories { get; set; }
    public Directory parent { get; set; }
    public DateTime creationdate { get; set; }
    public Directory(string name,Directory parent)
    {
        this.name = name;
        this.files = new List<File>();
        this.directories = new List<Directory>();
        this.parent = parent;
        this.creationdate = DateTime.Now;
    }
    public Directory(string name)
    {
        this.name = name;
        this.files = new List<File>();
        this.directories = new List<Directory>();
        this.parent = parent;
        this.creationdate = DateTime.Now;
    }
}
class Filesystem
{
    public Directory root { get; set; }
    public Directory current { get; set; }
    public Filesystem()
    {
        this.root = new Directory("root");
        current = root;
    }

    public void createfile(string name,string content)
    {
        current.files.Add(new File (name,content,current));
        if (current.name != "root")
        {
            root.files.Add(new File(name, content, current));
        }
    }
    public void createdirectory(string name)
    {
        current.directories.Add(new Directory(name,current));
        if (current.name != "root")
        {
            root.directories.Add(new Directory(name, current));
        }
    }
    public void changedirec(string path)
    {
        if (path == "../") 
        { 
            
            foreach(Directory i in current.directories)
            {
                if (i.name == path)
                {
                    current = i;
                }
            }
            string[] a = Propertice.currentpath.Split("/");
            Propertice.currentpath = "";
            for(int i = 0; i < a.Length - 1; i++)
            {
                Propertice.currentpath += a[i];
                if (i != a.Length - 2)
                {
                    Propertice.currentpath += "/";

                }
            }
        }
        foreach(Directory i in current.directories)
        {
            if (i.name == path)
            {
                current = i;
            }
        }
    }
    public void List()
    {
        foreach(Directory i in current.directories)
        {
            WriteLine($"D -> {i.name} date : {i.creationdate}");
        }
        foreach(File i in current.files)
        {
            WriteLine($"F -> {i.name} size : {i.size}  date : {i.creationDate}");
        }
    }
    public void Listall()
    {
        foreach(Directory i in root.directories)
        {
            WriteLine(i.name);
            foreach(Directory j in i.directories)
            {
                WriteLine(j.name);
                foreach(Directory k in j.directories)
                {
                WriteLine(k.name);

                }
                foreach(File k in j.files)
                {
                    WriteLine(k.name);

                }
            }
            foreach (File j in i.files)
            {
                WriteLine(j.name);
            }
        }
        foreach(File i in root.files)
        {
            WriteLine(i.name);
        }
    }
    public void Delfile(string name)
    {
        for(int i = 0; i < current.files.Count; i++)
        {
            if (current.files[i].name == name)
            {
                current.files.Remove(current.files[i]);
            }
        }
    }
    public void deldirec(string name)
    {
        for (int i = 0; i < current.directories.Count; i++)
        {
            if (current.directories[i].name == name)
            {
                current.directories.Remove(current.directories[i]);
            }
        }
    }
}
class Propertice
{
    public static int totalfile { get;set;}
    public static int totaldirec { get; set; }
    public static string currentpath { get; set; }
}
class Program
{
    static  void Main()
    {
        Filesystem a = new Filesystem();
        Propertice.currentpath = "root";
        while (true)
        {
          try {
            string comman = ReadLine();

            string[] split = comman.Split(" ");
            switch (split[0])
            {
                case "mkfile":
                    a.createfile(split[1], split[2]);
                    Propertice.totalfile++;
                        WriteLine("total file"+Propertice.totalfile);
                    break;
                case "cat":
                    foreach(File i in a.current.files)
                    {
                        if(i.name == split[1])
                        {
                            WriteLine(i.content);
                        }
                    }
                    break;
                case "ls":
                    a.List();
                    break;
                case "lsall":
                    
                    break;
                case "rm":
                    for(int i=0;i<a.current.files.Count;i++)
                    {
                        if (a.current.files[i].name == split[1])
                        {
                            a.current.files.Remove(a.current.files[i]);
                        }
                    }
                    Propertice.totalfile--;
                    break;
                case "rmdir":
                    for (int i = 0; i < a.current.directories.Count; i++)
                    {
                        if (a.current.directories[i].name == split[1])
                        {
                            a.current.directories.Remove(a.current.directories[i]);
                        }
                    }
                    Propertice.totaldirec--;
                    break;
                case "mkdir":
                    a.createdirectory(split[1]);
                    Propertice.totaldirec++;
                        WriteLine("total directory" + Propertice.totaldirec);

                        break;
                case "pwd":
                        WriteLine(Propertice.currentpath);
                    break;
                case "cd":
                        a.changedirec(split[1]);
                        if (split[1] == "../") { break; }
                        Propertice.currentpath += "/"+split[1];
                    break;
                default:
                    WriteLine("not exist");
                    break;
                        
            }
          }
            catch
            {
                continue;
            }
        }
    }
}
