using System.Diagnostics.Metrics;
using System.Xml.Linq;
using System;

public class Organization
{
    public Organization(string line)
    {
        var toks = line.Split(',');
        index = toks[0];
        Name = toks[1];
        Website = toks[2];
        Country = toks[3];
        Description = toks[4];
        Founded = int.Parse(toks[5]);
        Industry = toks[6];
        NumberofEmployees = int.Parse(toks[7]);
    }
    public string index;
    public string Name;
    public string Website;
    public string Country;
    public string Description;
    public int Founded;
    public string Industry;
    public int NumberofEmployees;
    
}


internal class Question1
{
    static void Main(string[] args)
    {
        var data = File.ReadAllLines(@"organizations.csv")
        .Skip(1)
        .Select(line => new Organization(line));
        Console.WriteLine($"Question 1: {data.ExtensionMethodPlaceHolder1()}");
        Console.WriteLine($"Question 2: {data.ExtensionMethodPlaceHolder2()}");
        Console.WriteLine($"Question 3: {data.ExtensionMethodPlaceHolder3()}");
        Console.WriteLine($"Question 4: {data.ExtensionMethodPlaceHolder4()}");
        Console.WriteLine($"Question 5: {data.ExtensionMethodPlaceHolder5()}");
        Console.WriteLine($"Question 6: {data.ExtensionMethodPlaceHolder6()}");
        Console.WriteLine($"Question 7: {data.ExtensionMethodPlaceHolder7()}");
        Console.WriteLine($"Question 8: {data.ExtensionMethodPlaceHolder8()}");
        Console.WriteLine($"Question 9: {data.ExtensionMethodPlaceHolder9()}");
        Console.WriteLine($"Question 10: {data.ExtensionMethodPlaceHolder10()}");
    }
}

public static class Extensions
{
    public static string ExtensionMethodPlaceHolder1(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Website.IndexOf(".net")!= -1);
        return $"{NEW.Count()}";
    }
    public static string ExtensionMethodPlaceHolder2(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Country=="Iran").GroupBy(x => x.Industry).OrderByDescending(x => x.Count()).FirstOrDefault();
        return NEW.Key;
    }
    public static string ExtensionMethodPlaceHolder3(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Industry=="Chemicals" && x.Founded>2000);
        double sum = 0;
        foreach(var i in NEW)
        {
            sum += i.NumberofEmployees;
        }
        return $"{sum/NEW.Count()}";
    }
    public static string ExtensionMethodPlaceHolder4(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Industry == "Online Publishing" || x.Industry=="E - Learning");
        long sum = 0;
        foreach (var i in NEW)
        {
            sum += i.NumberofEmployees;
        }
        return $"{sum}";
    }
    public static string ExtensionMethodPlaceHolder5(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Country=="Spain");

        var spain = NEW.OrderByDescending(x => x.NumberofEmployees);
        var emp =spain.ToArray();
        return $"{emp[0].Name}";
    }
    public static string ExtensionMethodPlaceHolder6(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Founded >= 2010).GroupBy(x => x.Country).OrderByDescending(x => x.Count()).FirstOrDefault();
        return NEW.Key;
    }
    public static string ExtensionMethodPlaceHolder7(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Industry.Contains("Software"));

        var old = NEW.OrderBy(x => x.Founded);

        var lists = old.ToArray();
        string res="\n";
        for(int i = 0; i < lists.Length; i++)
        {
            res += $" {i+1}- {lists[i].Name} at {lists[i].Founded} -----> {lists[i].Industry}\n";
            if (i == 4) { break; }
        }

        if (res == "\n") { res = "Not Exist industry"; }
        return res;

    }
    public static string ExtensionMethodPlaceHolder8(this IEnumerable<Organization> list)
    { 
        var Design = list.Where(x => x.Industry == "Design");
        var Art = list.Where(x => x.Industry == "Fine Art");
        var Emp = Design.OrderBy(x=>x.NumberofEmployees).Take(10).Union(Art.OrderBy(x=>x.NumberofEmployees).Take(10)).OrderBy(x=>x.NumberofEmployees).ThenBy(x=>x.Founded).ToArray();
        string res = "\n";
        for (int i = 0; i < Emp.Count(); i++)
        {
            res += $"  {i + 1}-->{Emp[i].Name}\n";
        }
        return res+="\n";
    }
    public static string ExtensionMethodPlaceHolder9(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Description.Contains("CIRCUIT",StringComparison.OrdinalIgnoreCase));

        var lits = NEW.OrderByDescending(x => x.Founded).ToArray();
        
        var org = new Organization[10];

        for(int i = 0; i < 10; i++)
        {
            if (i == lits.Length) { break; }
            org[i] =lits[i];
        }
        var last = org.OrderByDescending(x => x.NumberofEmployees).ToArray();
        string res = "\n";
        for(int i=0;i<10;i++)
        {
            if (i == last.Length) { break; }
            res += $"  {i + 1}- {last[i].Name}\n";//--------------{last[i].Description}-{last[i].Founded}-{last[i].NumberofEmployees}
        }
        return res;
    }
    public static string ExtensionMethodPlaceHolder10(this IEnumerable<Organization> list)
    {
        var NEW = list.Where(x => x.Industry=="Fishery");
        var New = list.Where(x => x.Country == "Italy");
        var last = NEW.Union(New).OrderByDescending(x => x.Founded).ToArray();
        string res = "\n";
        for(int i = 0; i < 10; i++)
        {
            res += $"  {i + 1}- {last[i].Website}\n";
        }
        return res;
    }
}
