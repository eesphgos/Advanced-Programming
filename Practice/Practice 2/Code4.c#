using System;
class participant
{
    public int participantid;
    public string name;
    public string email;

    public participant(int participantid, string name, string email)
    {
        this.participantid = participantid;
        this.name = name;
        this.email = email;
    }
    public void displayinfo()
    {
        Console.WriteLine();
        Console.WriteLine("  >> Participant Id : "+participantid);
        Console.WriteLine("     Name : "+name);
        Console.WriteLine("     Email : "+email);
        Console.WriteLine();
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class Event
{
    public int eventid;
    public string title;
    public DateTime date;
    public string location;
    public participant[] participants;
    public int participantscount;

    public Event(int eventid, string title, DateTime date, string location, participant[] participants, int participantscount)
    {
        this.eventid = eventid;
        this.title = title;
        this.date = date;
        this.location = location;
        this.participants = new participant[20];
        this.participantscount = 0;
    }
    public void addparticipant()
    {
       if (participantscount >= 20) { Console.WriteLine(); Console.WriteLine("participant is full");return;}

        Console.WriteLine();
        Console.WriteLine("enter participant id:");
        int iid = int.Parse(Console.ReadLine());
        Console.WriteLine("enter participant name");
        string namee = Console.ReadLine();
        Console.WriteLine("enter participant email");
        string emaill = Console.ReadLine();

        participants[participantscount] = new participant(iid, namee, emaill);
        participantscount++;
    }
    public void removeparticipantbyid()
    {
        Console.WriteLine();
        Console.WriteLine("enter participant id:");
        int iidd = int.Parse(Console.ReadLine());
        int ssit = 0;
        for(int i = 0; i < participantscount; i++)
        {
            if (participants[i].participantid == iidd || ssit == 1)
            {
                ssit = 1;
                participants[i] = participants[i + 1];
            }
        }
        if(ssit == 1)
        {
            Console.WriteLine();
            Console.WriteLine("participant was deleted");
            Console.WriteLine();

            participantscount--;
            return;
        }
        Console.WriteLine();
        Console.WriteLine("Not Found");
        Console.WriteLine();
    }
    public void searchparticipantbyname()
    {
        Console.WriteLine();
        Console.WriteLine("enter participant name:");
        string name =Console.ReadLine();

        for(int i = 0; i < participantscount; i++)
        {
            if (participants[i].name == name)
            {
                participants[i].displayinfo();
                return;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Not Found");
        Console.WriteLine();
    }
    public void displayeventinfo()
    {
        Console.WriteLine();
        Console.WriteLine("->> event id : "+eventid);
        Console.WriteLine("->> title : "+title );
        Console.WriteLine( $"->> date : {date.Year} {date.Month} {date.Day}");
        Console.WriteLine("->> location : "+location);
        Console.WriteLine();
        for(int i = 0; i < participantscount; i++)
        {
            participants[i].displayinfo();
        }
        
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


class Eventmanager
{
    public Event[] events = new Event[21];
    public int eventcount=0;

    public void addevent()
    {
        if(eventcount >= 20) { Console.WriteLine(); Console.WriteLine("events is full."); return; }
        Console.WriteLine();
        Console.WriteLine("enter event id:");
        int idd = int.Parse(Console.ReadLine());
        Console.WriteLine("enter title");
        string titl = Console.ReadLine();
        Console.WriteLine("enter year-month-day of event");
        int datey = int.Parse(Console.ReadLine());
        int datem = int.Parse(Console.ReadLine());
        int dated = int.Parse(Console.ReadLine());
        Console.WriteLine("enter location of event");
        string loc = Console.ReadLine();

        events[eventcount] = new Event(idd, titl, new DateTime(datey, datem, dated), loc, new participant[10],0);
        eventcount++;
    }
    public void removeeventbyid()
    {
        if(eventcount <= 0) { Console.WriteLine(); Console.WriteLine("empety"); return; }
        Console.WriteLine(); 
        Console.WriteLine("enter id of event");
        int iddd = int.Parse(Console.ReadLine());
        int sit = 0;
        for(int i = 0; i < eventcount; i++)
        {
            if (events[i].eventid == iddd || sit == 1)
            {
                sit = 1;
                events[i] = events[i + 1];
            }
        }
        
        
        if(sit == 1) {Console.WriteLine();  Console.WriteLine("Event was deleted :) ");Console.WriteLine(); eventcount--; return; }
        Console.WriteLine();
        Console.WriteLine("Not Found");
        Console.WriteLine();

    }
    public void searcheventbytitle()
    {
        Console.WriteLine();
        Console.WriteLine("enter title of event");
        string tit = Console.ReadLine();

        for (int i = 0; i < eventcount; i++)
        {
            if (events[i].title == tit)
            {
             
                events[i].displayeventinfo();
                return;
            }

        }
        Console.WriteLine();
        Console.WriteLine("Not Found");
        Console.WriteLine();

    }
    public void displayallevents()
    {
        for(int i = 0; i < eventcount; i++)
        {
            events[i].displayeventinfo();
            
        }
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class eventregistrationapp 
{
    static void Main()
    {
        Eventmanager OBJ = new Eventmanager();
        int num;

        do
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("# Event manage :");
            Console.WriteLine("");
            Console.WriteLine("1 -> add enent");
            Console.WriteLine("2 -> remove event by id");
            Console.WriteLine("3 -> search event by title");
            Console.WriteLine("4 -> display all event");
            Console.WriteLine("");
            Console.WriteLine("# Event registration manage :");
            Console.WriteLine("");
            Console.WriteLine("5 -> manage of event's detals");
            Console.WriteLine("");
            Console.WriteLine("Enter any number to exit . . .");

            Console.WriteLine("enter your choos ___");
            num = int.Parse(Console.ReadLine());

            //Console.Clear();

            switch (num)
            {
                case 1:
                    OBJ.addevent();
                    break;
                case 2:
                    OBJ.removeeventbyid();
                    break;
                case 3:
                    OBJ.searcheventbytitle();
                    break;
                case 4:
                    OBJ.displayallevents();
                    break;
                case 5:

                    int events = -9;

                    Console.WriteLine("");
                    Console.WriteLine("Enter id or title of event");
                    Console.WriteLine("");
                    Console.WriteLine("[] enter 1 to add id");
                    Console.WriteLine("[] enter 2 to add title");

                    int id = -55;
                    string title = " ";
                    int choz = int.Parse(Console.ReadLine());

                    Console.Clear();

                    if(choz == 1) 
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter id");
                        id = int.Parse(Console.ReadLine());
                        Console.Clear();
                        int sit = 0;
                        for (int i = 0; i < OBJ.eventcount; i++)
                        {
                           if (id == OBJ.events[i].eventid)
                            {
                                events = i;
                                sit = 1;
                            }
                        }
                        if (sit == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The event not found");
                            Console.WriteLine("");
                            break;
                        }
                    }
                    if (choz == 2)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter title of event");
                        title = Console.ReadLine();
                        Console.Clear();
                        int sit = 0;
                        for (int i = 0; i < OBJ.eventcount; i++)
                        {
                            if (title == OBJ.events[i].title)
                            {
                                events = i;
                                sit = 1;
                            }
                        }
                        if (sit == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The event not found");
                            Console.WriteLine("");
                            break;
                        }

                    }

                    Console.WriteLine("");
                    Console.WriteLine("1 -> add new participants");
                    Console.WriteLine("2 -> remove participants by id");
                    Console.WriteLine("3 -> search participant by name");
                    Console.WriteLine("4 -> display all detale of event");
                    Console.WriteLine("");

                    Console.WriteLine("enter your choos ___");
                    int choos = int.Parse(Console.ReadLine());
                    Console.Clear();


                    switch (choos)
                    {
                        case 1:
                            OBJ.events[events].addparticipant();
                            break;
                        case 2:
                            OBJ.events[events].removeparticipantbyid();
                            break;
                        case 3:
                            OBJ.events[events].searchparticipantbyname();
                            break;
                        case 4:
                            Console.WriteLine("....................................................");
                            OBJ.events[events].displayeventinfo();
                            break;
                    }
                        break;
       
            }
        }
        while (num > 0 && num < 6);


    }
}
