using Microsoft.Win32.SafeHandles;
using System.Text.RegularExpressions;

public abstract class WarehouseSection<T>
{
    protected List<T> item=new List<T>();
    public void AddItem(T item)
    {
        this.item.Add(item);
    } 
    public void RemoveItem(Func<T,bool> predicate)
    {
        for(int i = 0; i < item.Count; i++)
        {
            if (predicate(item[i]))
            {
                this.item.Remove(item[i]);
                i--;
            }
        }
    }
    public T? GetITem(Func<T, bool> predicate)
    {
        foreach(var i in item)
        {
            if (predicate(i))
            {
                return i;
            }
        }
        return default ;
    }
    public List<T> FilterItem(Func<T, bool> predicate)
    {
        List<T> filter = new List<T>();
        foreach(var i in item)
        {
            if (predicate(i))
            {
                filter.Add(i);
            }
        }
        return filter;
    }
    public bool Exists(Func<T, bool> predicate)
    {

        foreach(var i in item)
        {
            if (predicate(i))
            {
                return true;
            }
        }
        return false;
    }
    public void Updateitem(int id,T newitems)
    {
        for(int i=0;i<item.Count;i++)
        {
            if(item[i] is Electronic a && a.id==id){ item[i] = newitems; }
            else if(item[i] is Furniture b && b.id==id){ item[i] = newitems; }
            else if(item[i] is Book c && c.id==id){ item[i] = newitems; }
        }
    }
    public void Clearitem()
    {
        item = new List<T>();
    }
    public int Count()
    {
        return item.Count();
    }
    public void SortItem(Comparison<T> comparison)
    {
        item.Sort(comparison);
    }
    public void ListItem()
    {
        foreach(T i in item)
        {
            DisplayItem(i);
        }
    }
    protected abstract void DisplayItem(T item);
    public abstract string CategoryName();
    public virtual List<T> FilterByCategoryProperty(string key)
    {
        List<T> list = new List<T>();
        
        return list;
    }
    
}
public class WarehouseCategory<T> : WarehouseSection<T>
{
    public string Name { get;private set; }
    public WarehouseCategory(string name):base()
    {
        this.Name = name;
    }
    public override string CategoryName()
    {
        return Name;
    }
    protected override void DisplayItem(T item)
    {
        Console.WriteLine( item.ToString());
    }
}
public class Electronic
{
    public int id { get; set; }
    public string name { get; set; }
    public string brand { get; set; }
    public Electronic(int id, string name, string brand)
    {
        this.id = id;
        this.name = name;
        this.brand = brand;
    }
    public override string ToString()
    {
        return $"id->{id},name->{name},brand->{brand}";
    }
}
public class ElectronicsWarehouse : WarehouseCategory<Electronic>
{
    public ElectronicsWarehouse(string name) : base(name)
    {   
    }
    protected override void DisplayItem(Electronic item)
    {
        Console.WriteLine(item.ToString());

    }
    public List<Electronic> GetByBrand(string brand)
    {
        List<Electronic> brands = new List<Electronic>();

        foreach(var i in item)
        {
            if (i.brand.Contains(brand))
            {
                brands.Add(i);
            }
        }
        return brands;
    }
    public override List<Electronic> FilterByCategoryProperty(string key)
    {
        List<Electronic> a = new List<Electronic>();
        foreach (var i in item)
        {
            if (Name.Contains(key))
            {
                a.Add(i);
            }
        }
        return a;
    }
}
public class Furniture
{
    public int id { get; set; }
    public string name { get; set; }
    public string material { get; set; }
    public Furniture(int id, string name, string material)
    {
        this.id = id;
        this.name = name;
        this.material = material;
    }
    public override string ToString()
    {
        return $"id->{id},name->{name},material->{material}";

    }
}
public class FurnitureWarehouse : WarehouseCategory<Furniture>
{
    public FurnitureWarehouse(string name) : base(name)
    {
    }
    protected override void DisplayItem(Furniture item)
    {
        Console.WriteLine(item.ToString());
    }
    public List<Furniture> GetByMaterial(string material)
    {
        List<Furniture> mater = new List<Furniture>();

        foreach (var i in item)
        {
            if (i.material.Contains(material))
            {
                mater.Add(i);
            }
        }
        return mater;
    }
    public override List<Furniture> FilterByCategoryProperty(string key)
    {
        List<Furniture> a = new List<Furniture>();
        foreach (var i in item)
        {
            if (Name.Contains(key))
            {
                a.Add(i);
            }
        }
        return a;
    }
}
public class Book
{
    public int id { get; set; }
    public string name { get; set; }
    public string author { get; set; }
    public Book(int id, string name, string author)
    {
        this.id = id;
        this.name = name;
        this.author = author;
    }
    public override string ToString()
    {
        return $"id->{id},name->{name},author->{author}";

    }
}
public class BookWarehouse : WarehouseCategory<Book>
{
    public BookWarehouse(string name) : base(name)
    {
    }
    protected override void DisplayItem(Book item)
    {
        Console.WriteLine(item.ToString());

    }
    public List<Book> GetByAuthor(string author)
    {
        List<Book> authors = new List<Book>();

        foreach (var i in item)
        {
            if (i.author.Contains(author))
            {
                authors.Add(i);
            }
        }
        return authors;
    }
    public override List<Book> FilterByCategoryProperty(string key)
    {
        List<Book> a = new List<Book>();
        foreach(var i in item)
        {
            if (Name.Contains(key))
            {
                a.Add(i);
            }
        }
        return a;
    }
}
class Pro 
{
    static void Main()
    {
        ElectronicsWarehouse aa = new ElectronicsWarehouse("Electronic");
        FurnitureWarehouse bb = new FurnitureWarehouse("Furnithure");
        BookWarehouse cc = new BookWarehouse("Bohook");

        WarehouseCategory<Electronic> a = aa;
        WarehouseCategory<Furniture> b = bb;
        WarehouseCategory<Book> c =cc;

        /////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("START\nAdding . . .");
        Console.ForegroundColor = ConsoleColor.White;
        a.AddItem(new Electronic(8, "abuhs", "a"));
        a.AddItem(new Electronic(5, "aligent", "a"));
        a.AddItem(new Electronic(6, "alihe", "a"));
        b.AddItem(new Furniture(7, "cball", "b"));
        b.AddItem(new Furniture(1, "bohm", "b"));
        b.AddItem(new Furniture(3, "blade", "b"));
        c.AddItem(new Book(2, "calm", "c"));
        c.AddItem(new Book(10, "allh", "c"));
        c.AddItem(new Book(0, "lo", "c"));
        ////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nShow\n");
        Console.ForegroundColor = ConsoleColor.White;
        a.ListItem();
        b.ListItem();
        c.ListItem();
        /////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nRemoveing wich is have 'c' in there name . . .\n");
        Console.ForegroundColor = ConsoleColor.White;
        string contain = "c";
        a.RemoveItem(x => x.name.Contains(contain));
        b.RemoveItem(x => x.name.Contains(contain));
        c.RemoveItem(x => x.name.Contains(contain));
        //////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nShow\n");
        Console.ForegroundColor = ConsoleColor.White;
        a.ListItem();
        b.ListItem();
        c.ListItem();
        /////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nGet item wich id is 5\n");
        Console.ForegroundColor = ConsoleColor.White;
        int test = 5;
        if (a.GetITem(x => x.id == test) != null)
        {
            Console.WriteLine("\nFounded");
            Console.WriteLine(a.GetITem(x => x.id == test).ToString());
        }
        else if (b.GetITem(x => x.id == test) != null)
        {
            Console.WriteLine("\nFounded");
            Console.WriteLine(b.GetITem(x => x.id == test).ToString());
        }
        else if (c.GetITem(x => x.id == test) != null)
        {
            Console.WriteLine("\nFounded");
            Console.WriteLine(c.GetITem(x => x.id == test).ToString());
        }
        else { Console.WriteLine("Not Found"); }
        //////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nFIlter by name('al')\n");
        Console.ForegroundColor = ConsoleColor.White;
        string filter = "al";
        var alist = a.FilterItem(x => x.name.Contains(filter));
        var blist = b.FilterItem(x => x.name.Contains(filter));
        var clist = c.FilterItem(x => x.name.Contains(filter));
        foreach(var i in alist)
        {
            Console.WriteLine(i.ToString());
        }
        foreach (var i in blist)
        {
            Console.WriteLine(i.ToString());
        }
        foreach (var i in clist)
        {
            Console.WriteLine(i.ToString());
        }
        ////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nExisti name with length 7 charactor\n");
        Console.ForegroundColor = ConsoleColor.White;
        int length = 7;
        if (a.Exists(x=>x.name.ToArray().Length==length) || b.Exists(x => x.name.ToArray().Length == length) || c.Exists(x => x.name.ToArray().Length == length))
        {
            Console.WriteLine("Exist :)");
        }
        else { Console.WriteLine("Not Exist :("); }
        /////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nUpdating if id==5 -> id == 50 ...\n");
        Console.ForegroundColor = ConsoleColor.White;
        a.Updateitem(5, new Electronic(50, "hall", "cake"));
        b.Updateitem(5, new Furniture(50, "hall", "cake"));
        c.Updateitem(5, new Book(50, "hall", "cake"));
        /////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nCounting . . .\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Total item={a.Count() + b.Count() + c.Count()}");
        ////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nSorting(by name length) and show\n");
        Console.ForegroundColor = ConsoleColor.White;
        a.SortItem((x, y) => x.name.Length.CompareTo(y.name.Length));
        b.SortItem((x, y) => x.name.Length.CompareTo(y.name.Length));
        c.SortItem((x, y) => x.name.Length.CompareTo(y.name.Length));

        a.ListItem();
        b.ListItem();
        c.ListItem();
        //////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nShowing category name\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(a.CategoryName());
        Console.WriteLine(b.CategoryName());
        Console.WriteLine(c.CategoryName());
        //////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nFilter category by key('h')\n");
        Console.ForegroundColor = ConsoleColor.White;
        string key = "h";
        foreach (var i in aa.FilterByCategoryProperty(key))
        {
            Console.WriteLine( i.ToString());
        }
        foreach (var i in bb.FilterByCategoryProperty(key))
        {
            Console.WriteLine(i.ToString());

        }
        foreach (var i in cc.FilterByCategoryProperty(key))
        {
            Console.WriteLine(i.ToString());
        }
        //////////////////////////////////////////////////////////////
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nCLear all and show\n");
        Console.ForegroundColor = ConsoleColor.White;
        a.Clearitem();
        b.Clearitem();
        c.Clearitem();

        a.ListItem();
        b.ListItem();
        c.ListItem();
    }
}

