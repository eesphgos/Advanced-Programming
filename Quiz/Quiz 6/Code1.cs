

using System.CodeDom.Compiler;

public enum RepurtType 
{
    Daily,
    Monthly
}
interface IReport
{
    RepurtType Type { get; }
    void Generate();
}
interface ILoggedReport:IReport
{
    void LogGenerationTime();
}
public abstract class ReportBase:ILoggedReport
{
    public RepurtType Type { get; }

    public virtual void Generate()
    {
        Console.WriteLine("Generated");
    }
    public abstract void LogGenerationTime();
}
public class Dailyreport: ReportBase
{
    public override void LogGenerationTime()
    {
        Console.WriteLine($"Daily report generate at{DateTime.Now}");

    }
}
public class Monthlyreport : ReportBase
{
    public sealed override void Generate()
    {
        Console.WriteLine("MOnthly report generate");
    }
    public override void LogGenerationTime()
    {
        Console.WriteLine($"MOnthly report generate at{DateTime.Now}");
    }
}
public class Pro
{
    static void Main()
    {
        List<IReport> reports = new List<IReport>();
        reports.Add(new Dailyreport());
        reports.Add(new Dailyreport());
        reports.Add(new Dailyreport());
        reports.Add(new Monthlyreport());
        reports.Add(new Monthlyreport());

        foreach(var i in reports)
        {
            i.Generate();
        }
        foreach(var i in reports)
        {
            if(i is ILoggedReport a)
            {
                a.LogGenerationTime();
            }
        }
    }
}

