using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

interface INewsAPIHandler
{
    public News[] GetAllnews();
    public News Getnewbyid(int id);
    public bool Addnew(int id, string content);
    public bool Addnew(News news);
    public bool Deletenews(int id);
}
class News
{
    public int Id { get; set; }
    public string Content { get; set; }
    public News(int Id, string Content)
    {
        this.Id = Id;
        this.Content = Content;
    }
}
class NewsResponse
{
    public string status { get; set; }
    public News[] data { get; set; }
    public NewsResponse(string status, News[] data)
    {
        this.status = status;
        this.data = data;
    }
}
class MessageResponse
{
    public string status { get; set; }
    public string message { get; set; }
    public MessageResponse(string status, string message)
    {
        this.status = status;
        this.message = message;
    }
}
class NewsAPIHandler : INewsAPIHandler, IDisposable
{
    HttpClient Client { get; set; }
    string apiURL { get; set; }
    public NewsAPIHandler()
    {
        this.Client = new HttpClient();
        this.apiURL = "http://localhost:8080";
    }
    public News[] GetAllnews()
    {

        HttpResponseMessage response = Client.GetAsync($"{apiURL}/news").Result;
        string responseBody = response.Content.ReadAsStringAsync().Result;
        
        NewsResponse news =JsonConvert.DeserializeObject<NewsResponse>(responseBody);
        return news.data;
        

    }
    public News Getnewbyid(int id)
    {
        News[] find = new NewsAPIHandler().GetAllnews();
        foreach(News i in find)
        {
            if (i.Id == id)
            {
                return i;
            }
        }
        return new News(-9999,"");
    }
    public bool Addnew(int id, string content)
    {
        News ADD = new News(id, content);

        return Addnew(ADD);
    }
    public bool Addnew(News news)
    {

        string json = JsonConvert.SerializeObject(news);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = Client.PostAsync($"{apiURL}/news", content).Result;

        string responseBody = response.Content.ReadAsStringAsync().Result;
        MessageResponse messageResponse = JsonConvert.DeserializeObject<MessageResponse>(responseBody);
        Console.WriteLine(messageResponse.message);
        return  messageResponse.status == "Success";

    }
    public bool Deletenews(int id)
    {
        HttpResponseMessage response = Client.DeleteAsync($"{apiURL}/news?Id={id}").Result;
        string responseBody = response.Content.ReadAsStringAsync().Result;
        MessageResponse messageResponse = JsonConvert.DeserializeObject<MessageResponse>(responseBody);
        Console.WriteLine($"ID : {id} -->"+messageResponse.message);
        return messageResponse.status == "Success";
    }

    public void Dispose()
    {
        Client.Dispose();
    }
}
class Programm
{
    static void Main()
    {
        NewsAPIHandler API = new NewsAPIHandler();


        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Adding-----------------------\n");
        //start adding
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        API.Addnew(1, "this ");
        API.Addnew(2, "this is ");
        API.Addnew(3, "this is first ");
        API.Addnew(4, "this is first request");


        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nGet All News-----------------\n");
        //getting all news
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (News i in API.GetAllnews())
        {
            Console.WriteLine(i.Id + "-->" + i.Content);
        }


        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nSearchig for news------------\n");
        //searching
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        News search = API.Getnewbyid(2);
        if (search.Id != -9999)
        {
            Console.WriteLine("FOUNDED");
            Console.WriteLine($"ID : {search.Id}\nContent : {search.Content}");
        }
        else { Console.WriteLine("News Not Found"); }
        News searc = API.Getnewbyid(5);
        if (searc.Id != -9999)
        {
            Console.WriteLine("FOUNDED");
            Console.WriteLine($"ID : {searc.Id}\nContent : {searc.Content}");
        }
        else { Console.WriteLine("News Not Found"); }


        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nDeletting--------------------\n");
        //deletting
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        API.Deletenews(1);
        API.Deletenews(6);


        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nGet All News-----------------\n");
        //getting all news
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (News i in API.GetAllnews())
        {
            Console.WriteLine(i.Id + "-->" + i.Content);
        }


        //start dispos
        API.Dispose();
        Console.ForegroundColor = ConsoleColor.Blue;
    }
}



