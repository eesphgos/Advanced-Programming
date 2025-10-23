
public interface IIdentifiable 
{
    Guid id {  get; }
    string Typename { get; }
}
public interface IAuditable : IIdentifiable 
{
    DateTime Cratedat { get; }
}
public abstract class EntityBase : IAuditable 
{
    public Guid id { get; }
    abstract public string Typename { get; }
    public DateTime Cratedat { get; }
    public EntityBase()
    {
        this.id = Guid.NewGuid();
        this.Cratedat = DateTime.Now;
    }
}
public class Person : EntityBase
{
    public Guid id { get; }
    override public string Typename { get; }
    public DateTime Cratedat { get; }
    public Person() : base()
    {
        Typename = "Person";       
    }
}
public class Company : EntityBase
{
    public Guid id { get; }
    override public string Typename { get; }
    public DateTime Cratedat { get; }
    public Company() : base()
    {
        this.Typename = "Company";
    }
}
public static class EntityPrinter
{
    public static void Printinfo(this IAuditable T)
    {
        Console.WriteLine($"id={T.id}   typename={T.Typename}   creatat={T.Cratedat}");
    }
}
public class Pro
{
    static void Main()
    {
        Person P = new Person();
        Company C = new Company();
        P.Printinfo();
        C.Printinfo();
    }
}

