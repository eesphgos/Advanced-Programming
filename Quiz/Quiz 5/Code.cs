
using System.Diagnostics;

class Publication
{
    public string title { get; set; }
    public int pagecount { get; set; }

    public Publication(string title, int pagecount)
    {
        this.title = title;
        this.pagecount = pagecount;
    }

    public virtual double calculateprice()
    {
        return 1000 * pagecount;
    }
    public virtual string info()
    {
        return $"Title : {title}\nPages : {pagecount}";
    }
}
class book : Publication
{
    protected string gener { get; set; }
    public book(string title , int pagecount ,string gener):base(title,pagecount)
    {
        this.gener = gener;
    }

    public override double calculateprice()
    {
        return 1000 * pagecount*1.1;
    }
    public override string info()
    {
        return $"Title : {title}\nPages : {pagecount}\nGener : {gener}";
    }
}
class comicbook :book
{
    string illustrator { get; set; }
    public comicbook(string title, int pagecount,string gener, string illustratorr):base(title,pagecount,gener)
    {
        this.illustrator = illustrator;
    }
    public override double calculateprice()
    {
        return 800 * pagecount;
    }
    public virtual string info()
    {
        return $"Title : {title}\nPages : {pagecount}\nGener : {gener}\nIllustrator : {illustrator}";
    }
}

static class Ext
{
    public static double Average(this List<Publication> a)
    {
        double sum = 0;
        foreach(Publication i in a)
        {
            sum += i.calculateprice();
        }
        return sum/a.Count;
    }
    public static int totalpage(this List<Publication> a)
    {
        int  ssum = 0;
        foreach (Publication i in a)
        {
            ssum += i.pagecount;
        }
        return ssum;
    }
    public static void findbytitle(this List<Publication> a ,string keyword)
    {
        char[] find = keyword.ToCharArray();
        foreach(Publication i in a)
        {
            char[] ititle = i.title.ToCharArray();
            if (ititle.Length < find.Length) { continue; }

            if (i.title.IndexOf(keyword) != -1)
            {
                Console.WriteLine("");
                Console.WriteLine(i.info());
            }
        }
    }
}

class Programm 
{
    static void Main()
    {
        List<Publication> pub = new List<Publication>();
        pub.Add(new Publication("AAA",125));
        pub.Add(new Publication("bbb",24));
        pub.Add(new Publication("ugh",351));
        pub.Add(new book("ughaaaaaaaaa",29,"comedy"));
        pub.Add(new book("www",1000,"action"));
        pub.Add(new book("man in the",654,"hororr"));
        pub.Add(new comicbook("ughjkfn",21311,"happyness","none"));
        pub.Add(new comicbook("uifhdklc",2122,"hhsh","to"));
        pub.Add(new comicbook("ugfsg",123,"ohisf","man"));
        foreach(Publication i in pub)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(i.info());
            Console.WriteLine("Price :"+i.calculateprice()+" R");
        }
        Console.WriteLine("_______________________________________");
        Console.WriteLine("Average of price :"+pub.Average());
        Console.WriteLine("Total page :" + pub.totalpage());
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
        pub.findbytitle("ugh");
    }
}
