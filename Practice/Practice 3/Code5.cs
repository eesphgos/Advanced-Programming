using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Numerics;
public enum bar
{
    Food,
    Minerals,
    Technology,
    Waepons,
    LuxaryGoods,
    Hazardous
}
public class Planet
{
    public int planetid;
    public string name;
    public int x, y, z;
    public bool glasticfuelstation;
    public List<Cargo> Avaliblecargo;

    public Planet (int planetid, string name, int x, int y, int z, bool glasticfuelstation)
    {
        this.planetid = planetid;
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
        this.glasticfuelstation = glasticfuelstation;
        Avaliblecargo = new List<Cargo>();
    }
    public void Planetstatus(int id)
    {
        Console.WriteLine("");
        Console.WriteLine($"Planet Id : {planetid}");
        Console.WriteLine($"Planet Name : {name}");
        Console.WriteLine($"Planet Location x:{x} ,y:{y} , z:{z}");
        Console.WriteLine($"Planet Fuel Station : {glasticfuelstation}");
        Console.WriteLine("");
        foreach(Cargo i in Avaliblecargo)
        {
            i.cargostatus();
        }
    }
    public void Destroyplanet(int id)
    {
        if (Avaliblecargo.Count() != 0) { Console.WriteLine("There is Exist any cargo you can't remove thid planet");return; }
        foreach (Ship i in Space.shipes)
        {
            if (i.currentplanet == null) { continue; }
            if(i.currentplanet.planetid == id) { Console.WriteLine("This planet origin or distination of any shipes can't remove");return; }
        }
        foreach(Planet i in Space.planets)
        {
            foreach (Cargo j in i.Avaliblecargo)
            {
                if (j.pickdown.planetid == id)
                {
                    Console.WriteLine("Some cargo should be sent to this planet you cant destroy th planet");return;
                }
            }
        }
        foreach (Planet i in Space.planets)
        {
            if (i.planetid == id)
            {
                Space.planets.Remove(i);
                Console.WriteLine("complitly removed");
                return;
            }
        }
        Console.WriteLine("planet not found");
    }
}
public class Cargo 
{
    public int cargoId;
    bar cargotype;
    public float Weight;
    public float Volume;
    public Planet pickup;
    public Planet pickdown;
    public int reward;
    public bool deliverystatus;
    public float integerity;

    public Cargo (int cargoId,bar cargotype,float Weight,float Volume,Planet pickup,Planet pickdown,int reward)
    {
        this.cargoId = cargoId;
        this.cargotype = cargotype;
        this.Weight = Weight;
        this.Volume = Volume;
        this.pickup = pickup;
        this.pickdown = pickdown;
        this.reward = reward;
        this.deliverystatus = false;
        this.integerity = 100;
    }

    public void cargostatus()
    {
        Console.WriteLine($"cargo ID = {cargoId}");
        Console.WriteLine($"cargo Type = {cargotype}");
        Console.WriteLine($"cargo weight : {Weight} Kg");
        Console.WriteLine($"cargo volume : {Volume} Ms");
        Console.WriteLine($"cargo origin planet = {pickup.name}");
        Console.WriteLine($"cargo destination planet = {pickdown.name}");
        Console.WriteLine($"cargo reward : {reward} $");
        Console.WriteLine($"cargo delivery status : {deliverystatus}");
        Console.WriteLine($"cargo integrity = {integerity} %");
        Console.WriteLine($"");
    }

}
public class Ship
{
    public int shipid;
    string name;
    float currentfuel;
    float maxfuel;
    public Planet currentplanet;
    float networth;
    float maxWeight;
    float maxvolume;
    public List<Cargo> cargos;

    public Ship(int shipid, string name, float currentfuel, float maxfuel, float networth, float maxWeight, float maxvolume)
    {
        this.shipid = shipid;
        this.name = name;
        this.currentfuel = currentfuel;
        this.maxfuel = maxfuel;
        this.currentplanet = null;
        this.networth = networth;
        this.maxWeight = maxWeight;
        this.maxvolume = maxvolume;
        this.cargos = new List<Cargo>();
    }
    public void shipstatus(int id)
    {
        Console.WriteLine("");
        Console.WriteLine($"Ship ID :{shipid}");
        Console.WriteLine($"Ship Name : {name}");
        if (currentplanet != null)Console.WriteLine($"Ship Origin Name : {currentplanet.name}");
        else { Console.WriteLine($"Ship in {Centralstation.name} , C.S"); }
        Console.WriteLine($"Ship Current Fuel : {currentfuel}");
        Console.WriteLine($"Ship Max Fuel : {maxfuel}");
        Console.WriteLine($"Ship Max Volume : {maxvolume}");
        Console.WriteLine($"Ship Max Weight : {maxWeight}");
        Console.WriteLine($"Ship Mony : {networth}");
        Console.WriteLine("");
        foreach(Cargo i in cargos)
        {
            i.cargostatus();
        }
    }
    public void headto(int id)
    {
        while (true)
        {
            foreach(Planet i in Space.planets)
            {
                if (currentplanet == null)
                {
                    double distance;
                    distance = Math.Sqrt(Math.Pow((i.x), 2) + Math.Pow((i.y), 2) + Math.Pow((i.z), 2));
                    if (currentfuel > distance)
                    {
                        currentfuel -= (float)distance;
                        currentplanet = i;
                        Console.WriteLine($"ship moved to {i.name}");
                        triggerrandomevent();
                        return;
                    }
                    else { Console.WriteLine("more fuel needed"); }
                    return;
                }
                if (id == 0) 
                {
                    double distance;
                    distance = Math.Sqrt(Math.Pow((i.x), 2) + Math.Pow((i.y), 2) + Math.Pow((i.z), 2));
                    if (currentfuel > distance)
                    {
                        currentfuel -= (float)distance;
                        currentplanet = null;
                        Console.WriteLine($"ship moved to {Centralstation.name}");
                        triggerrandomevent();
                        return;
                    }
                    else { Console.WriteLine("more fuel needed"); }
                    return;
                }
                if(i.planetid == id && id == currentplanet.planetid) { Console.WriteLine("can't move to origin planet");return; }
                if (i.planetid == id)
                {
                    double distance;
                    distance = Math.Sqrt(Math.Pow((i.x - currentplanet.x),2) + Math.Pow((i.y - currentplanet.y),2) + Math.Pow((i.z - currentplanet.z),2));
                    if (currentfuel > distance)
                    {
                        currentfuel -=(float) distance;
                        currentplanet = i;
                        Console.WriteLine($"ship moved to {i.name}");
                        triggerrandomevent();
                        return;
                    }
                    else { Console.WriteLine("more fuel needed"); }
                        return;
                }
            }
            Console.WriteLine("not found");
            return;
        }
        
    }
    public static void refuel(int id)
    {
        foreach(Ship i in Space.shipes)
        {
            if (i.shipid == id)
            {
                if (i.currentplanet == null) { Console.WriteLine("ship in the centeral station can't refueling");return; }
                if (i.currentplanet.glasticfuelstation)
                {
                    if (i.currentfuel == i.maxfuel) { Console.WriteLine("you can't refueling capacity is full");return; }
                    float sum = 0;
                    while (i.currentfuel < i.maxfuel && i.networth>=5)
                    {
                        if (i.currentfuel + 1 > i.maxfuel) { break; }
                        i.currentfuel++;
                        i.networth -= 5;
                        sum++;
                    }
                    Console.WriteLine($"refueling is done we gain {sum} L of fuel");
                    Console.WriteLine($"current fuel : {i.currentfuel}");
                    Console.WriteLine($"Mony : {i.networth}");
                    return;
                }
                Console.WriteLine("planet doesn't have fuel station");
                return;
            }
        }
        Console.WriteLine("ship not found");
    }
    public void pickupcargo(int cargoid)
    {
        foreach(Cargo i in Space.cargoes)
        {
            if (i.cargoId == cargoid)
            {
                if (i.pickup != currentplanet) { Console.WriteLine("The cargo origin not here to pick up it");return; }
                if (i.Weight > maxWeight) { Console.WriteLine("The weight of cargo bigger than capacity of ship");return; }
                if(i.Volume > maxvolume) { Console.WriteLine("The volume of cargo bigger than capacity of ship");return; }
                maxvolume -= i.Volume;
                maxWeight -= i.Weight;
                cargos.Add(i);
                foreach (Planet j in Space.planets)
                {
                    if (j == i.pickup)
                    {
                        j.Avaliblecargo.Remove(i);
                    }
                }
                Console.WriteLine("cargo pick up succesfully ;)");return;
            }
        }
        Console.WriteLine("cargo not found");
    }
    public static void deliverycargo(int cargoid)
    {
        foreach(Ship i in Space.shipes)
        {
            foreach(Cargo j in i.cargos)
            {
                if (j.cargoId == cargoid)
                {
                    if (i.currentplanet == j.pickdown)
                    {
                        j.deliverystatus = true;
                        i.maxvolume += j.Volume;
                        i.maxWeight += j.Weight;
                        i.networth += j.reward * j.integerity / 100;
                        foreach(Planet k in Space.planets)
                        {
                            if (k == i.currentplanet)
                            {
                                k.Avaliblecargo.Add(j);
                            }
                        }
                        i.cargos.Remove(j);
                        Console.WriteLine("cargo delivered");
                        return;
                    }
                    Console.WriteLine("Current planet not distination of this cargo");return;
                }
            }
            
        }
        Console.WriteLine("cargo not found");
    }
    public void triggerrandomevent()
    {
        Random random = new Random();

        int possiblity = random.Next(1, 11);

        if (possiblity == 4 || possiblity == 3 || possiblity == 2) 
        { 
            Console.WriteLine($"Oh no the pirate attaked to our ship !!! \n we lost {currentfuel/10} fuel and 50% of cargoes integrity");
            currentfuel -= currentfuel/ 10;
            foreach(Cargo i in cargos)
            {
                i.integerity -= i.integerity/2;
            }
        }
        else if (possiblity == 5 || possiblity == 6 || possiblity == 7) 
        {
            Console.WriteLine("oHHHHH look at the meteor shower !!! \n we lost 15% of cargoes integrity");
            foreach (Cargo i in cargos)
            {
                i.integerity -= 15;
            }
        }
        else if (possiblity == 8 || possiblity == 9 || possiblity == 10) 
        {
            Console.WriteLine($"Oh no the pirate attaked to our ship !!! \n we lost {currentfuel/5} fuel");
            currentfuel -= currentfuel /5;
        }
    }
}
public class Centralstation
{
    public static string name;
    static int x, y, z;
    public static List<Ship> shipes;
    static int totalnetworyh;

    static Centralstation()
    {
        Console.WriteLine("Let's choose a name to the central station next countinue");
        name = Console.ReadLine();
        x = 0;y = 0;z = 0;
        shipes = new List<Ship>();
        totalnetworyh = 0;
    }
    public static void AddShip()
    {
        while (true)
        {
            bool repeat = false;
            try
            {
                Console.WriteLine("Enter an id for ship");
                int id = int.Parse(Console.ReadLine());
                foreach (Ship i in Space.shipes)
                {
                    if (i.shipid == id) { repeat = true; }
                }
                if (repeat) { throw new Exception(); }
                Console.WriteLine("Enter name of ship");
                string name = Console.ReadLine();

                Console.WriteLine("Enter max fuel capacity");
                float maxfuel = float.Parse(Console.ReadLine());
                if (maxfuel < 0) { Console.WriteLine("Max fuel capacity can't be less  than zero"); throw new Exception(); }
                Console.WriteLine("Enter max volume capacity");
                float maxvolume = float.Parse(Console.ReadLine());
                if (maxvolume < 0) { Console.WriteLine("Max volume capacity can't be less  than zero"); throw new Exception(); }

                Console.WriteLine("Enter max Weight capacity");
                float maxweight = float.Parse(Console.ReadLine());
                if (maxweight < 0) { Console.WriteLine("Max weight capacity can'tbe less  than zero"); throw new Exception(); }

                Console.WriteLine("Enter current fuel");
                float currentfuel = float.Parse(Console.ReadLine());
                if (currentfuel < 0) { Console.WriteLine("current fuel can'tbe less  than zero"); throw new Exception(); }

                if (currentfuel < 0 || currentfuel > maxfuel)
                {
                    Console.WriteLine("current fuel more than max fuel capacity pleas try again."); continue;
                }
                Console.WriteLine("Enter the mony of ship");
                float mony = float.Parse(Console.ReadLine());
                if (mony < 0) { Console.WriteLine("nomy can't be less  than zero"); throw new Exception(); }

                Space.shipes.Add(new Ship(id, name, currentfuel, maxfuel, mony, maxweight, maxvolume));
                Centralstation.shipes.Add(new Ship(id, name, currentfuel, maxfuel, mony, maxweight, maxvolume));
                break;
            }
            catch
            {
                if (repeat) { Console.WriteLine("wrong id used befor for an another ship"); continue; }
                Console.WriteLine("wrong entry try agan");
            }
        }
    }
    public static void Destroyship()
    {
        if (Space.shipes.Count() == 0) { Console.WriteLine("there is no any shipes to remove"); return; }
        while (true)
        {
            Console.WriteLine("Enter a ship id to remome ship");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("entery not int try again"); continue; }
            bool exist = true;

            for (int i = 0; i < Space.shipes.Count(); i++)
            {
                if (Space.shipes[i].shipid == id)
                {
                    if (Space.shipes[i].cargos.Count() != 0) { Console.WriteLine("the ship have cargo can't destroy it"); return; }
                    if (Space.shipes[i].currentplanet!=null) { Console.WriteLine("the ship not in the C.S"); return; }
                    Space.shipes.Remove(Space.shipes[i]);
                    exist = false;
                    Console.WriteLine("ship remove complited");
                }
            }
            for (int i = 0; i < Centralstation.shipes.Count(); i++)
            {
                if (Centralstation.shipes[i].shipid == id)
                {
                    if (Centralstation.shipes[i].cargos.Count() != 0) { Console.WriteLine("the ship have cargo can't destroy it");return; }
                    Centralstation.shipes.Remove(Centralstation.shipes[i]);

                }
            }

            if (exist) { Console.WriteLine($"ship not found"); }
            break;
        }
    }
}
public static class Space
{
    public static List<Planet> planets = new List<Planet>();
    public static List<Ship> shipes = new List<Ship>();
    public static List<Cargo> cargoes = new List<Cargo>();
}
class Programm
{
    static void Main()
    {
        Centralstation.shipes.Count();
        bool pro = true;
        int a = 0;
        while (pro)
        {
            Console.WriteLine("______________________________");
            Console.WriteLine("Choose work to do ->");
            Console.WriteLine("");
            Console.WriteLine("1-Show total status");
            Console.WriteLine("2-add or remove cargo");
            Console.WriteLine("3-add or remove ship");
            Console.WriteLine("4-add or remove planet");
            Console.WriteLine("5-move to");
            Console.WriteLine("6-Collection noun");
            Console.WriteLine("7-Cargo delivery");
            Console.WriteLine("8-Refuiling");
            Console.WriteLine("9-Exit");
            Console.WriteLine("");
            try 
            { 
                a = int.Parse(Console.ReadLine());
                Console.Clear();
                if (a>9 || a < 1)
                {
                    throw new Exception();
                }
            }
            catch 
            {
                Console.Clear();
                Console.WriteLine("!  !  !  !  !  !  !  !  !");
                Console.WriteLine("Wrong entry try agane");
                Console.WriteLine("_________________________");
            }
            switch (a)
            {
                case 1:
                    show();
                    break;
                case 2:
                    if (Space.planets.Count() == 0) { Console.WriteLine("there is no planet to add corgo"); break; ; }
                    while (true)
                    {
                        Console.WriteLine("Enter add or remove to apply on cargo");
                        string plan = Console.ReadLine();
                        if (plan == "add")
                        {
                            addcargo();
                            break;
                        }
                        else if (plan == "remove")
                        {
                            removecargo();
                            break;
                        }
                        else { Console.WriteLine("you most enter 'add' or 'remove' "); }
                    }
                    break;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("enter add or remove to apply ship");
                        string ship = Console.ReadLine(); 
                        if (ship == "add")
                        {
                            Centralstation.AddShip();
                            break;
                        }
                        else if (ship == "remove")
                        {
                            Centralstation.Destroyship();
                            break;
                        }
                        else { Console.WriteLine("you most enter 'add' or 'remove' "); }
                    }
                    break;
                case 4:
                    while (true) 
                    {
                        Console.WriteLine("Enter add or remove to apply on planet");
                        string plan = Console.ReadLine();
                        if (plan == "add")
                        {
                            addplanet();
                            break;
                        }
                        else if (plan == "remove")
                        {
                            removeplanet();
                            break;
                        }
                        else { Console.WriteLine("you most enter 'add' or 'remove' "); }
                    }
                    
                        break;
                case 5:
                    moveto();
                    break;
                case 6:
                    pickupcargo();
                    break;
                case 7:
                    pickdown();
                    break;
                case 8:
                    Refuel();
                    break;
                case 9:
                    Console.WriteLine("Good Luck ;)");
                    pro = false;
                    break;
            }
        }
    }
    public static void show()
    {
        if (Space.planets.Count() == 0 && Space.shipes.Count() == 0)
        {
            Console.WriteLine("there is no ship or planet"); return ;
        }
        string s;
        while (true)
        {
            Console.WriteLine("Enter P(show planet status) or S(show ship status)");
            s = Console.ReadLine();
            try
            {
                if (!(s == "P" || s == "S"))
                {
                    throw new Exception();
                }
            }
            catch { Console.WriteLine("Wrong entery"); continue; }
            if (s == "S")
            {
                if (Space.shipes.Count() == 0) { Console.WriteLine("ther is no ship"); break; }
                while (true)
                {
                    Console.WriteLine("Enter a ship id");
                    int id = -1;
                    bool sit = false;
                    try { id = int.Parse(Console.ReadLine()); }
                    catch { Console.WriteLine("entry not int"); continue; }
                    foreach (Ship i in Space.shipes)
                    {
                        if (i.shipid == id)
                        {
                            i.shipstatus(id);
                            sit = true;
                        }
                    }
                    if (!sit)
                    {
                        Console.WriteLine("ship not found"); break;
                    }
                    else
                    {
                        break;
                    }
                }

                break;
            }
            if (s == "P")
            {
                if (Space.planets.Count() == 0) { Console.WriteLine("ther is no planet"); continue; }

                while (true)
                {
                    Console.WriteLine("Enter a planet id");
                    int id = -1;
                    bool sit = false;
                    try { id = int.Parse(Console.ReadLine()); }
                    catch { Console.WriteLine("entry not int"); continue; }
                    foreach (Planet i in Space.planets)
                    {
                        if (i.planetid == id)
                        {
                            i.Planetstatus(id);
                            sit = true;
                        }
                    }
                    if (!sit)
                    {
                        Console.WriteLine("planet not found"); break;
                    }
                    else
                    {
                        break;
                    }
                }

                break;
            }
        }
    }
    public static void addplanet()
    {
        while (true)
        {
            bool repeat = false;
            try
            {
                Console.WriteLine("Enter an id for planet to add");
                int id = int.Parse(Console.ReadLine());
                foreach (Planet i in Space.planets)
                {
                    if (i.planetid == id) { repeat = true; }
                }
                if (repeat) { throw new Exception(); }
                Console.WriteLine("Enter name of planet");
                string name = Console.ReadLine();
                Console.WriteLine("Enter location x,y,z");
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter false(not exist) or true(exist) for fuel station");
                bool fuel = bool.Parse(Console.ReadLine());
                Space.planets.Add(new Planet(id, name, x, y, z, fuel));
                break;
            }
            catch
            {
                if (repeat) { Console.WriteLine("Entered id was enter before"); continue; }
                Console.WriteLine("wrong entry try agan");
            }
        }
    }
    public static void removeplanet()
    {
        if (Space.planets.Count() == 0) { Console.WriteLine("there is no planet to remove"); return; }
        while (true)
        {
            Console.WriteLine("Enter a planet id to remome planet");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("entery not int try again"); continue; }
            bool exist = true;

            for (int i = 0; i < Space.planets.Count(); i++)
            {
                if (Space.planets[i].planetid == id)
                {
                    Space.planets[i].Destroyplanet(id);
                    exist = false;
                }
            }

            if (exist) { Console.WriteLine("planet not found"); }
            break;
        }
    }
    //public static void addship()
    //{
    //    while (true)
    //    {
    //        bool repeat = false;
    //        try
    //        {
    //            Console.WriteLine("Enter an id for ship");
    //            int id = int.Parse(Console.ReadLine());
    //            foreach (Ship i in Space.shipes)
    //            {
    //                if(i.shipid == id) { repeat = true; }
    //            }
    //            if (repeat) { throw new Exception(); }
    //            Console.WriteLine("Enter name of ship");
    //            string name = Console.ReadLine();

    //            Console.WriteLine("Enter max fuel capacity");
    //            float maxfuel = float.Parse(Console.ReadLine());
    //            if (maxfuel < 0) { Console.WriteLine("Max fuel capacity can't be less  than zero");throw new Exception(); }
    //            Console.WriteLine("Enter max volume capacity");
    //            float maxvolume = float.Parse(Console.ReadLine());
    //            if (maxvolume < 0) { Console.WriteLine("Max volume capacity can't be less  than zero"); throw new Exception(); }

    //            Console.WriteLine("Enter max Weight capacity");
    //            float maxweight = float.Parse(Console.ReadLine());
    //            if (maxweight < 0) { Console.WriteLine("Max weight capacity can'tbe less  than zero"); throw new Exception(); }

    //            Console.WriteLine("Enter current fuel");
    //            float currentfuel = float.Parse(Console.ReadLine());
    //            if (currentfuel < 0) { Console.WriteLine("current fuel can'tbe less  than zero"); throw new Exception(); }

    //            if (currentfuel < 0 || currentfuel > maxfuel)
    //            {
    //                Console.WriteLine("current fuel more than max fuel capacity pleas try again."); continue;
    //            }
    //            Console.WriteLine("Enter the mony of ship");
    //            float mony = float.Parse(Console.ReadLine());
    //            if (mony < 0) { Console.WriteLine("nomy can't be less  than zero"); throw new Exception(); }

    //            Space.shipes.Add(new Ship(id, name, currentfuel, maxfuel, mony, maxweight, maxvolume));
    //            break;
    //        }
    //        catch
    //        {
    //            if (repeat) { Console.WriteLine("wrong in id or planet"); continue; }
    //            Console.WriteLine("wrong entry try agan");
    //        }
    //    }
    //}
    //public static void removeship()
    //{
    //    if (Space.shipes.Count() == 0) { Console.WriteLine("there is no any shipes to remove");return; }
    //    while (true)
    //    {
    //        Console.WriteLine("Enter a ship id to remome ship");
    //        int id = 0;
    //        try
    //        {
    //            id = int.Parse(Console.ReadLine());
    //        }
    //        catch { Console.WriteLine("entery not int try again"); continue; }
    //        bool exist = true;

    //        for (int i = 0; i < Space.shipes.Count(); i++)
    //        {
    //            if (Space.shipes[i].shipid == id)
    //            {
    //                Space.shipes.Remove(Space.shipes[i]);
    //                exist = false;
    //                Console.WriteLine("ship remove complited");
    //            }
    //        }

    //        if (exist) { Console.WriteLine("ship not found"); }
    //        break;
    //    }
    //}
    public static void addcargo()
    {
        if (Space.planets.Count() == 1) { Console.WriteLine("there is only one planet to add corgo"); return; }
        while (true)
        {
            bool repeat = false;
            try
            {
                Console.WriteLine("Enter an id for new cargo");
                int id = int.Parse(Console.ReadLine());
                foreach (Cargo i in Space.cargoes)
                {
                    if (i.cargoId == id) { repeat = true;throw new Exception(); }
                }
                Console.WriteLine("Enter type of cargo( Food - Minerals - Technology - Waepons - LuxaryGoods - Hazardous )");
                string bar = Console.ReadLine();
                char[] a = bar.ToCharArray();

                foreach(char i in a){if(i >= '0' && i <= '9'){throw new Exception();}}

                if (Enum.TryParse(bar, true, out bar neww))
                {
                }
                else
                {
                    Console.WriteLine("Invalid cargo type!");
                    continue;
                }
                Console.WriteLine("enter weight of cargo");
                float weght = float.Parse(Console.ReadLine()); 
                Console.WriteLine("enter volume of cargo");
                float volume = float.Parse(Console.ReadLine());
                Console.WriteLine("enter reward of cargo");
                int reward = int.Parse(Console.ReadLine());
                if (reward < 0 || weght < 0 || volume < 0) { throw new Exception(); }

                Console.WriteLine("enter ides of origin planet and destination ");
                int oringi=0, destination = 0;

                oringi =int.Parse(Console.ReadLine());
                destination =int.Parse(Console.ReadLine());
                if (oringi == destination) { Console.WriteLine("origin planet and destination planet can't be same");throw new Exception(); }
                bool orig = false, des = false;
                Planet ooo = null;
                Planet bbb = null;
                foreach(Planet i in Space.planets)
                {
                    if (i.planetid == oringi)
                    {
                        orig = true;
                        ooo = i;
                    }
                    if (i.planetid == destination)
                    {
                        des = true;
                        bbb = i;
                    }
                }
                if (!(orig && des))
                {
                    Console.WriteLine($"origin planet find :{orig} , destination planet find :{des}");
                    throw new Exception();
                }
                Cargo newcargo = new Cargo(id,neww,weght,volume,ooo,bbb,reward);
                foreach(Planet i in Space.planets)
                {
                    if (i == ooo)
                    {
                        i.Avaliblecargo.Add(newcargo);
                    }
                }
                Space.cargoes.Add(newcargo);
                break;
            }
            catch
            {
                if (repeat) { Console.WriteLine("wrong in id"); continue; }
                Console.WriteLine("wrong entry try agan");
            }
        }
    }
    public static void removecargo()
    {
        if (Space.cargoes.Count() == 0) { Console.WriteLine("There is no any cargo to remove");return; }
        while (true)
        {
            Console.WriteLine("enter id of cargo to remove it");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("entery not int try again"); continue; }
            bool exist = true;
            int name = 0;
            for (int i = 0; i < Space.cargoes.Count(); i++)
            {
                if (Space.cargoes[i].cargoId == id)
                {
                    if (Space.cargoes[i].deliverystatus) {name = Space.cargoes[i].pickdown.planetid; }
                    else { name = Space.cargoes[i].pickup.planetid; }
                        exist = false;
                    Space.cargoes.Remove(Space.cargoes[i]);
                    Console.WriteLine("cargo remove complited");
                }
            }
            foreach(Planet i in Space.planets)
            {
                if (i.planetid == name)
                {
                    for(int j = 0; j < i.Avaliblecargo.Count(); j++)
                    {
                        if (i.Avaliblecargo[j].cargoId == id)
                        {
                            i.Avaliblecargo.Remove(i.Avaliblecargo[j]);
                        }
                    }
                }
            }

            if (exist) { Console.WriteLine("ship not found"); }
            break;
        }
        
    }
    public static void Refuel()
    {
        if (Space.shipes.Count() == 0) { Console.WriteLine("there is no any shipes to refuel");return; }
        while (true)
        {
            Console.WriteLine("enter an ship id to refuel it");
            int id = 0;
            try { id = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Entry no int"); }
            Ship.refuel(id);
            break;
        }

    }
    public static void moveto()
    {
        if (Space.shipes.Count() == 0) { Console.WriteLine("there is no any ships"); return; }
        if (Space.planets.Count() == 0) { Console.WriteLine("there is no planet"); return; }
        while (true)
        {
            Console.WriteLine("enter a ship id to move it");
            int id = 0;
            try { id = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("entry not int"); }
            foreach (Ship i in Space.shipes)
            {
                if (i.shipid == id)
                {
                    Console.WriteLine("enter an id of distination of thid ship");
                    int idd = 0;
                    try { idd = int.Parse(Console.ReadLine()); }
                    catch { Console.WriteLine("entry not int"); }
                    i.headto(idd);
                    return;
                }
            }
            
            Console.WriteLine("Ship not found");
            break;
        }
    }
    public static void pickupcargo()
    {
        if (Space.shipes.Count() == 0) { Console.WriteLine("there is no any ship to pick up the cargo");return; }
        if (Space.cargoes.Count() == 0) { Console.WriteLine("there is no any cargo to pick up it");return; }
        while (true)
        {
            Console.WriteLine("enter an id of a ship to pick up cargo");
            int id = 0;
            try { id = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("entry not int"); }
            foreach(Ship i in Space.shipes)
            {
                if (i.shipid == id)
                {
                    while (true)
                    {
                        Console.WriteLine("enter an id of a cargo to pick up it");
                        int idd = 0;
                        try { idd = int.Parse(Console.ReadLine()); }
                        catch { Console.WriteLine("entry not int"); }
                        i.pickupcargo(idd);
                        return;
                    }
                }
            }
            Console.WriteLine("ship not found");return;
        }
    }
    public static void pickdown()
    {
        if (Space.cargoes.Count() == 0) { Console.WriteLine("don't exist any cargo");return; }
        if (Space.shipes.Count() == 0) { Console.WriteLine("don't exist any shipes");return; }
        while (true)
        {
            Console.WriteLine("enter an cargo id to pick it down");
            int id = 0;
            try { id = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("entry not int"); }
            Ship.deliverycargo(id);
            return;
        }
    }
}

//Rexy
//3
//add
//1
//hero
//100
//105
//120
//20
//210
//4
//add
//1
//earth
//2
//2
//2
//true
//4
//add
//2
//mars
//5
//1
//9
//true
//4
//add
//3
//cake
//11
//2
//8
//false
//2
//add
//1
//Food
//55
//55
//120
//1
//2
