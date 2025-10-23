using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Xml;

enum Files
{
    HTML,
    CSS,
    JS,
    Unsupported
}
class Targetfile
{
    string path;
    int oldvolum;
    int newvolum;
    DateTime prosses;
    Files type;
    public Targetfile(string path)
    {
        this.path = path;
        this.oldvolum =(int) File.ReadAllBytes(path).Length;
        this.prosses = DateTime.Now;
        this.type = Files.Unsupported;
    }
    public void Minify()
    {
        string[] typee = path.Split('.');
        string word = typee[typee.Length - 1];
        typee[typee.Length - 1] = "min." + typee[typee.Length - 1];
        string newpath =string.Join('.',typee);
        switch (word)
        {
            case "html":
                minihtml(newpath);
                break;
            case "css":
                minicss(newpath);
                break;
            case "js":
                minijs(newpath);
                break;
        }
    }
    void minihtml(string newpath)
    {
        char[] txte = File.ReadAllText(path).ToCharArray();
        bool flage = false;
        for (int i = 0; i < txte.Length; i++)
        {
            if (txte[i] == '\n') //deleting new line
            {
                txte[i - 1] = ' ';
                txte[i] = ' ';
            }
            if (txte[i] == '<' && txte[i + 1] == '!' && txte[i + 2] == '-' && txte[i + 3] == '-')
            {
                flage = true;
            }
            else if (txte[i] == '-' && txte[i + 1] == '-' && txte[i + 2] == '>')
            {
                flage = false;
                txte[i] = ' ';
                txte[i + 1] = ' ';
                txte[i + 2] = ' ';
            }
            if (flage)//deleying comment
            {
                txte[i] = ' ';
            }
        }
        List<char> minitxte = new List<char>();
        bool site = false;
        for (int k = 0; k < txte.Length; k++)
        {
            if (txte[k] != ' ') { site = false; }
            if (site) { continue; }
            minitxte.Add(txte[k]);
            if (txte[k] == ' ') { site = true; }
        }
        string tttt = string.Join((""), minitxte);
        File.WriteAllText(newpath, tttt);
        type = Files.HTML;
        newvolum = (int)File.ReadAllBytes(newpath).Length;
        SaveToHistory();
    }
    void minicss(string newpath)
    {
        char[] txt = File.ReadAllText(path).ToCharArray();
        bool flag = false;
        for (int i = 0; i < txt.Length; i++)
        {
            if (txt[i] == '\n') //deleting new line
            {
                txt[i - 1] = ' ';
                txt[i] = ' ';
            }
            if (txt[i] == '/' && txt[i + 1] == '*')
            {
                flag = true;
            }
            else if (txt[i] == '*' && txt[i + 1] == '/')
            {
                flag = false;
                txt[i] = ' ';
                txt[i + 1] = ' ';
            }
            if (flag)//deleying comment
            {
                txt[i] = ' ';
            }
        }
        List<char> minitxt = new List<char>();
        bool sit = false;
        for (int k = 0; k < txt.Length; k++)
        {
            if (txt[k] != ' ') { sit = false; }
            if (sit) { continue; }
            minitxt.Add(txt[k]);
            if (txt[k] == ' ') { sit = true; }
        }
        string ttt = string.Join((""), minitxt);
        File.WriteAllText(newpath, ttt);
        newvolum = (int)File.ReadAllBytes(newpath).Length;
        type = Files.CSS;
        SaveToHistory();
    }
    void minijs(string newpath)
    {
        char[] txtx = File.ReadAllText(path).ToCharArray();
        bool flagg = false;
        for (int i = 0; i < txtx.Length; i++)
        {
            if (txtx[i] == '/' && txtx[i + 1] == '/')
            {
                int x = 0;
                while (txtx[i + x] != '\n')
                {
                    txtx[i + x] = ' ';
                    x++;
                }
            }
            if (txtx[i] == '\n') //deleting new line
            {
                txtx[i - 1] = ' ';
                txtx[i] = ' ';
            }
            if (txtx[i] == '/' && txtx[i + 1] == '*')
            {
                flagg = true;
            }
            else if (txtx[i] == '*' && txtx[i + 1] == '/')
            {
                flagg = false;
                txtx[i] = ' ';
                txtx[i + 1] = ' ';
            }
            if (flagg)//deleying comment
            {
                txtx[i] = ' ';
            }
        }
        List<char> minitxtx = new List<char>();
        bool sitg = false;
        for (int k = 0; k < txtx.Length; k++)
        {
            if (txtx[k] != ' ') { sitg = false; }
            if (sitg) { continue; }
            minitxtx.Add(txtx[k]);
            if (txtx[k] == ' ') { sitg = true; }
        }
        string tt = string.Join((""), minitxtx);
        File.WriteAllText(newpath, tt);
        newvolum = (int)File.ReadAllBytes(newpath).Length;
        type = Files.JS;
        SaveToHistory();
    }
    void SaveToHistory()
    {
        string[] word = path.Split('\\');
        string save = $"File : {word[word.Length - 1]} | type : {type} | Orginal : {oldvolum} KB | Minified : {newvolum} KB | Date : {prosses}\n";
        string dpath = Path.GetDirectoryName(path);
  
        File.AppendAllText("history.txt",save);
    }
    public static void GetHistory()
    {
        if (File.Exists("history.txt"))
        {
            Console.WriteLine(File.ReadAllText("history.txt"));
        }
        else
        {
            Console.WriteLine("dont modified any file.");
        }
        
    }
}
class Program
{
    static void Main()
    {
        string path;
        while (true)
        { 
            Console.WriteLine("Enter a directory path . . .\nEnter 'history' to see history\nEnter 'Exit' to Exit ");
            path = Console.ReadLine();
            if(path == "Exit") { break; }
            else if(path == "history")
            {
                Targetfile.GetHistory();
                continue;
            }
            else if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string i in files)
                {
                    Targetfile thiss = new Targetfile(i);
                    thiss.Minify();
                }
                Console.WriteLine();
                Console.WriteLine("Minifiring complited :)");
                Console.WriteLine();

                continue;
            }
            else
            { 
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Directory Not found");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}
