
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security.Cryptography;

enum paintingstyle 
{
    Expressionism,
    Impressionism,
    Cubism,
    Baroque,
    Surrelism,
    Realism
}
enum paintingmaterial
{
    Acrylie,
    Oil,
    Pastel,
    CharcoalPencil,
    Watercolor,
    OilPaster
}
interface IGallerymanager
{
    public void RegisterArtist(Artist artist);
    public GalleryItem CreateGalleryItemForArtist(int artistId,int galeryitemid, string title, int year, int price, double height, double? width, string material, paintingstyle? style, paintingmaterial? paintingMaterial, double? weightKg, bool isSculpture);
    public void ExhibitItem(GalleryItem item, string location);
    public void RemoveItem(string location);
    public bool HasAvailableLocations();
    public void Exhibitmap();
    public string GetItemlocation(GalleryItem item);
}
abstract class Persion
{
    public int id { get; set; }
    public string name { get; set; }
    public Persion(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public abstract void DisplayInfo();
}
abstract class GalleryItem
{
    public string title { get; set; }
    public  int artistid { get; set; }
    public int yearcreated { get; set; }
    public int price { get; set; }
    public int GaleryItemID { get; set; }
    public abstract void DIsplayInfo(Manager manager);
}
class Manager : Persion, IGallerymanager
{
    public List<Artist> registeredArtist { get; set; }
    public List<ExhibitingEntery> exhibilityitem { get; set; }
    public List<GalleryItem> I { get; set; }
    public Manager(int id,string name):base(id,name)
    {
        registeredArtist = new List<Artist>();
        exhibilityitem = new List<ExhibitingEntery>();
        this.I = new List<GalleryItem>();
        this.id = id;
        this.name = name;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Manager Id = {id}\nManager Name : {name}");
        for(int i=0;i<registeredArtist.Count;i++)
        {
            Console.WriteLine($"[{i+1}]-->");
            registeredArtist[i].DisplayInfo();
        }
    }
    public void RegisterArtist(Artist artist)
    {
        registeredArtist.Add(artist);
    }
    public GalleryItem CreateGalleryItemForArtist(int artistId,int galeryitemid, string title, int year, int price, double height, double? width, string material, paintingstyle? style, paintingmaterial? paintingMaterial, double? weightKg, bool isSculpture)
    {
        foreach (Artist i in registeredArtist)
        {
            if (i.id == artistId)
            {
                return isSculpture
                    ? new Sculpture(artistId,galeryitemid,title,year,price,height,material,width ?? 0)
                    : new Painting(artistId,galeryitemid,title,year,price,height,width ?? 0,material,style ?? paintingstyle.Realism,paintingMaterial ?? paintingmaterial.Oil);
            }
        }
        Console.WriteLine("Artist not found");
        return new Sculpture(-1,0,"",0,0,0,"",12);
        
    }
    public void ExhibitItem(GalleryItem item, string location)
    {
        foreach(ExhibitingEntery i in exhibilityitem)
        {
            if (i.Lodcation == location)
            {
                Console.WriteLine("Location is occupancy");
                return;
            }
        }
        exhibilityitem.Add(new ExhibitingEntery(location,item));
    }
    public void RemoveItem(string location)
    {
        foreach(ExhibitingEntery i in exhibilityitem)
        {
            if (i.Lodcation == location)
            {
                exhibilityitem.Remove(i);
                Console.WriteLine("Art was removed");
                return;
            }
        }
        Console.WriteLine("NOT found art in this location");
    }
    public bool HasAvailableLocations()
    {
        return true;
    }
    public void Exhibitmap()
    {
        for(int i = 0; i < exhibilityitem.Count; i++)
        {
            Console.WriteLine($"[{i+1}] -->");
            Console.WriteLine($"  Title : {exhibilityitem[i].Item.title}");
            Console.WriteLine($"  Location : {exhibilityitem[i].Lodcation}");
        }
    }
    public string GetItemlocation(GalleryItem item)
    {
        foreach(ExhibitingEntery i in exhibilityitem)
        {
            if (i.Item == item)
            {
                return i.Lodcation;
            }
        }
        return "not have any location";
    }
}
class Artist:Persion
{
    string specilty { get; set; }
    string eduction { get; set; }
    paintingstyle style { get; set; }
    public Artist(int id,string name,string specilty, string eduction, paintingstyle style):base(id,name)
    {
        this.specilty = specilty;
        this.eduction = eduction;
        this.style = style;
        this.id = id;
        this.name = name;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Name: {name}\n  ID : {id}\n  Specilty : {specilty}\n  Eduction : {eduction}\n  Painting style : {style}");
    }
}
class Painting : GalleryItem
{
    double height { get; set; }
    string material { get; set; }
    double width { get; set; }
    paintingstyle style { get; set; }
    paintingmaterial materiaal { get; set; }

    public Painting(int artistId,int galetyitemid, string title, int year, int price, double height, double width,string material, paintingstyle style, paintingmaterial paintingMaterial)
    {
        this.height = height;
        this.material = material;
        this.width = width;
        this.style = style;
        this.materiaal = paintingMaterial;
        this.price = price;
        this.title = title;
        this.artistid = artistId;
        this.yearcreated = year;
        this.GaleryItemID = galetyitemid;
    }
    public override void DIsplayInfo(Manager manager)
    {
        Console.WriteLine("Painting art:\n");
        foreach(GalleryItem i in manager.I)
        {
            if(i is Painting)
            {
                Painting a =(Painting) i;
                Console.WriteLine($"  artist id:{a.artistid}\n   Item id: {a.GaleryItemID}\n   Title: {a.title}\n   Year of creat: {a.yearcreated}\n   Price: {a.price}\n   Height: {a.height}\n   Width: {a.width}\n   Material: {a.material}\n   Style: {a.style}\n   Painting material :{a.materiaal}");
            }
        }
    }
}
class Sculpture : GalleryItem
{
    double height { get; set; }
    string material { get; set; }
    double weight { get; set; }
    public Sculpture(int artistId,int galeryitemid, string title, int year, int price, double height, string material,double weightKg)
    {
        this.height = height;
        this.material = material;
        this.weight = weight;
        this.title = title;
        this.yearcreated = year;
        this.price = price;
        this.artistid = artistId;
        this.GaleryItemID = galeryitemid;

    }
    public override void DIsplayInfo(Manager manager)
    {
        Console.WriteLine("Sculpture art:\n");
        foreach (GalleryItem i in manager.I)
        {
            if (i is Sculpture)
            {
                Sculpture a = (Sculpture)i;
                Console.WriteLine($"  artist id:{a.artistid}\n   Item id: {a.GaleryItemID}\n   Title: {a.title}\n   Year of creat: {a.yearcreated}\n   Price: {a.price}\n   Height: {a.height}\n   Weight: {a.weight}\n   Material: {a.material}\n");
            }
        }
    }
}
class ExhibitingEntery
{
    public string Lodcation { get; set; }
    public GalleryItem Item { get; set; }
    public ExhibitingEntery(string loc,GalleryItem item)
    {
        this.Lodcation = loc;
        this.Item = item;
    }
}
class Progrram
{
    static void Main()
    {
        List < GalleryItem > galleryItems= new List<GalleryItem>();
        List<string> location =new List<string> { "loc 1" ,"loc 2", "loc 3", "loc 4", "loc 5", "loc 6", "loc 7", "loc 8", "loc 9" };
        int mId;
        while (true)
        {
            Console.WriteLine("Enter manager ID");
            try
            {
                mId = int.Parse(Console.ReadLine());
            }
            catch(Exception e) { Console.WriteLine(e.Message);continue; }
            break;
        }
        Console.WriteLine("Enter manager name");
        string MName = Console.ReadLine();
        Manager T = new Manager(mId,MName);
        
        while (true)
        {
            T.I = galleryItems;
            Console.WriteLine("..................................");
            Console.WriteLine("1-Add new artist");
            Console.WriteLine("2-Add new art");
            Console.WriteLine("3-add Art in exhibition");
            Console.WriteLine("4-remove art from exhibition");
            Console.WriteLine("5-Show map");
            Console.WriteLine("6-Show person list");
            Console.WriteLine("7-Show art list");
            Console.WriteLine("8-Exit");
            string a = Console.ReadLine();
            Console.Clear();
            switch (a)
            {
                case "1":
                    int id;
                    string name;
                    string specilty;
                    string eduction;
                    paintingstyle p;
                    while (true)
                    {
                        Console.WriteLine("Enter id of artist");
                        try { id = int.Parse(Console.ReadLine());if (id < 0) { throw new Exception("ID cant be smaller than 0"); } }
                        catch { Console.WriteLine("Invalid entry");continue; }
                        break;
                    }
                    Console.WriteLine("Enter name of artist");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter epecilty of artist");
                    specilty = Console.ReadLine();
                    Console.WriteLine("Enter eduction of artist");
                    eduction = Console.ReadLine();
                    while (true)
                    {
                        Console.WriteLine("Enter paintig style of artist((0)Expressionism,(1)Impressionism,(2)Cubism,(3)Baroque,(4)Surrelism,(5)Realism)");
                        
                        try 
                        {
                            int num = int.Parse(Console.ReadLine());
                            if (num < 0 || num > 5) { throw new Exception("Number not valid"); }
                            string b =num.ToString();
                            p = (paintingstyle)Enum.Parse(typeof(paintingstyle),b ); 
                        }
                        catch(Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    T.RegisterArtist(new Artist(id,name,specilty,eduction,p));
                    break;
                case "2":
                    if (T.registeredArtist.Count == 0) { Console.WriteLine("not any artist to add art");break; }
                    int artistId;
                    int galeryitemid;
                    string title;
                    int year;
                    int price;
                    double height;
                    double width;
                    string material;
                    paintingstyle style;
                    paintingmaterial paintingMaterial;
                    double weightKg=0;
                    bool isSculpture;
                    while (true)
                    {
                        Console.WriteLine("Enter id of artist");
                        try { artistId = int.Parse(Console.ReadLine()); }
                        catch(Exception e) { Console.WriteLine(e.Message);continue; }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter id of art");
                        try { galeryitemid = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    Console.WriteLine("Enter title");
                    title = Console.ReadLine();
                    while (true)
                    {
                        Console.WriteLine("Enter year fo cread art");
                        try { year = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter Price of art");
                        try { price = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter height of art");
                        try { height = double.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    Console.WriteLine("Enter material");
                    material = Console.ReadLine();
                    string issc;
                    while (true)
                    {
                        isSculpture = false;
                        Console.WriteLine("Enter Weight of art(if art is painting press enter)");
                        issc = Console.ReadLine();
                        if (issc == "") { isSculpture = false;break; }
                        else { isSculpture = true; }
                            try { weightKg = double.Parse(issc); }
                            catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    if (isSculpture) 
                    {
                        GalleryItem NewW = T.CreateGalleryItemForArtist(artistId, galeryitemid, title, year, price, height, null, material, null, null, weightKg,isSculpture);
                        if (NewW.artistid != -1)
                        {
                            galleryItems.Add(NewW);
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter width of art");
                        try { width = double.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter paintig style of art((0)Expressionism,(1)Impressionism,(2)Cubism,(3)Baroque,(4)Surrelism,(5)Realism)");

                        try
                        {
                            int num = int.Parse(Console.ReadLine());
                            if (num < 0 || num > 5) { throw new Exception("Number not valid"); }
                            string b = num.ToString();
                            style = (paintingstyle)Enum.Parse(typeof(paintingstyle), b);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter paintig material of art((0)Acrylie,(1)Oil,(2)Pastel,(3)CharcoalPencil,(4)Watercolor,(5)OilPaster)");

                        try
                        {
                            int numb = int.Parse(Console.ReadLine());
                            if (numb < 0 || numb > 5) { throw new Exception("Number not valid"); }
                            string bb = numb.ToString();
                            paintingMaterial = (paintingmaterial)Enum.Parse(typeof(paintingmaterial), bb);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); continue; }
                        break;
                    }
                    GalleryItem New= T.CreateGalleryItemForArtist(artistId,galeryitemid,title,year,price,height,width,material,style,paintingMaterial,null,isSculpture);
                    if (New.artistid != -1)
                    {
                        galleryItems.Add(New);
                    }
                    break;
                case "3":
                    if (galleryItems.Count == 0) { Console.WriteLine("Not any art to show in exhibition");break; }
                    int aid;
                    while (true)
                    {
                        Console.WriteLine("Enter id of art to move it to exhibition");
                        try { aid = int.Parse(Console.ReadLine()); }
                        catch(Exception i) { Console.WriteLine(i.Message);continue; }
                        break;
                    }
                    bool s = true;
                    foreach(GalleryItem i in galleryItems)
                    {
                        if (i.GaleryItemID == aid)
                        {
                            s = false;
                            Console.WriteLine("Enter location where you want(loc 1,loc 2,loc 3,loc 4,loc 5,loc 6,loc 7,loc 8,loc 9)");
                            string loca = Console.ReadLine();
                            if (!location.Contains(loca))
                            {
                                Console.WriteLine("The location not exist");
                                break;
                            }
                            T.ExhibitItem(i, loca);
                        }
                    }
                    if (s) { Console.WriteLine("art not found"); }
                    break;
                case "4":
                    if (T.exhibilityitem.Count == 0) { Console.WriteLine("NOt any art in exhibition to remove it");break; }
                    Console.WriteLine("Enter location of art to remove it");
                    string loc = Console.ReadLine();
                    T.RemoveItem(loc);
                    break;
                case "5":
                    if (T.exhibilityitem.Count == 0) { Console.WriteLine("Not anyart in exhibition");break; }
                    T.Exhibitmap();
                    break;
                case "6":
                    T.DisplayInfo();
                    break;
                case "7":
                    if (T.registeredArtist.Count == 0) { Console.WriteLine("NOt ant artist");break; }
                    new Painting(0, 0, "", 0, 0, 0, 0, "", paintingstyle.Expressionism, paintingmaterial.Oil).DIsplayInfo(T);
                    new Sculpture(0,0,"",0,0,0,"",0).DIsplayInfo(T);
                    break;
                case "8":
                    Console.WriteLine("Good luck");
                    return;
                default:
                    Console.WriteLine("Invalid entery");
                    break;
            }
        }
    }
}
