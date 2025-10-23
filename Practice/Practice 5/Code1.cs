using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;
enum Type
{
    science,
    story,
    another
}
class Book
{
    protected string title;
    protected string author;
    public int year;
    public Type type;

    public Book(string title,string author, int year, Type type )
    {
        this.title = title;
        this.author = author;
        this.year = year;
        this.type = type;
    }
    public virtual string get_details()
    {
        return $"Title : {title}\nWriter : {author}\nYear : {year}\nType : {type}\n";
    }
}
class ScientificBook : Book
{
    [JsonInclude]
    string subject;
    public ScientificBook(string title, string author, int year, Type type,string subject):base(title,author,year,type)
    {
        this.subject = subject;
    }

    public override string get_details()
    {
        return base.get_details()+$"Subject : {subject}\n";
    }
}
class FictionBook:Book
{
    [JsonInclude]
    int age;
    public FictionBook(string title, string author, int year, Type type, int age) : base(title, author, year, type)
    {
        this.age = age;
    }
    public override string get_details()
    {
        return base.get_details() + $"Age range : {age}\n";
    }
}
static class ProExtention
{
    public static List<Book> Sortup(this List<Book> list)
    {
    for(int j = 0; j < list.Count; j++)
    {
        for(int i = 0; i < list.Count-1; i++)
        {
            if (list[i].year < list[i + 1].year)
            {
                Book hold = list[i];
                list[i] = list[i + 1];
                list[i + 1] = hold;
            }
        }
    }
        return list;
    }
    public static List<Book> Sortdown(this List<Book> list)
    {
        for (int j = 0; j < list.Count; j++)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].year > list[i + 1].year)
                {
                    Book hold = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = hold;
                }
            }
        }

        return list;
    }
    public static bool search(this List<Book> list,Type type)
    {
        foreach(Book i in list)
        {
            if (i.type == type) { return true; }
        }
        return false;
    }
}
class Proggram
{
    static void Main()
    {
        List<Book> library = new List<Book>();
        while (true)
        {
            WriteLine("Menu . . . . . . . . . . . . . . .");
            WriteLine("-> 'S' -Show Library");
            WriteLine("-> 'A' -Add Book");
            WriteLine("-> 'U' -Sort Up to down");
            WriteLine("-> 'D' -Sort Down to up");
            WriteLine("-> 'X' -Exsist type");
            WriteLine("-> 'E' -Exite");

            string a = ReadLine();

            Clear();
            switch (a)
            {
                case "S":
                    if (library.Count == 0) { WriteLine("Library is empty");break; }
                    for (int i = 0; i < library.Count; i++)
                    {
                        WriteLine($"{i + 1} --> {library[i].get_details()}");
                        
                    }
                    break;
                case "A":
                    while (true)
                    {
                        try
                        {

                            WriteLine("Enter title");
                            string name = ReadLine();
                            if (name == "") { throw new Exception(); }
                            WriteLine("Enter author");
                            string author = ReadLine();
                            if (author == "") { throw new Exception(); }
                            WriteLine("Entre type(history,science,story,another)");
                            Type neww = (Type)Enum.Parse(typeof(Type), ReadLine());
                            WriteLine("Enter year of writen");
                            int year = int.Parse(ReadLine());

                            if(neww == Type.science)
                            {
                                WriteLine("Enter subject");
                                string sub = ReadLine();
                                library.Add(new ScientificBook(name,author,year,neww,sub));
                                WriteLine("Added succsesfully");
                                break;
                            }
                            if(neww == Type.story)
                            {
                                WriteLine("Enter Age to up");
                                int s = int.Parse(ReadLine());
                                library.Add(new FictionBook(name, author, year, neww, s));
                                WriteLine("Added succsesfully");
                                break;
                            }
                            library.Add(new Book(name,author,year,neww) );
                            WriteLine("Added succsesfully");
                            break;
                        }
                        catch(Exception e) { WriteLine(e.Message); }
                    }
                    break;
                case "U":
                    library = library.Sortup();
                    WriteLine("Sorted complite");
                    break;
                case "D":
                    library = library.Sortdown();
                    WriteLine("Sorted complite");
                    break;
                case "X":
                    Write($"Story Book : ");WriteLine(library.search(Type.story)?"Yes":"No");
                    Write($"acience Book : ");WriteLine(library.search(Type.science)?"Yes":"No");
                    Write($"another Book : ");WriteLine(library.search(Type.another)?"Yes":"No");
                    break;
                case "E":
                    WriteLine("Good bye");
                    return;
                    
                default:
                    WriteLine("wrong entry");
                    break;
            }
        }
    }
}
