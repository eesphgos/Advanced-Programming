using System;

class menuitem
{
    public int itemid;
    string name;
    string discription;
    public double price;

    public  menuitem(int itemid, string name, string discription, double price)
    {
        this.itemid = itemid;
        this.name = name;
        this.discription = discription;
        this.price = price;
    }

    public void displyiteminfo()
    {
        Console.WriteLine();
        Console.WriteLine(":) -> Item Id : "+itemid);
        Console.WriteLine("Food name : "+name);
        Console.WriteLine("Discription : "+discription);
        Console.WriteLine("price : "+price+" $");
        Console.WriteLine();

    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class order
{
    public int orderid;
    public int tablenumber;
    public menuitem[] items;
    public int itemcount;
    public string status;

    public order (int orderid, int tablenumber, menuitem[] items, int itemcount, string status)
    {
        this.orderid = orderid;
        this.tablenumber = tablenumber;
        this.items = new menuitem[10];
        this.itemcount = 0;
        this.status = "preparing...";
    }

    public int additem()
    {
        Console.WriteLine("enter id of food");
        int id = int.Parse(Console.ReadLine());

        //items[itemcount] = new menuitem(id,name,disc,pric);
        //itemcount++;
        return id;
    }
    public void removeitembyid(order orders1, order orders2)
    {
        orders1.orderid = orders2.orderid;
        orders1.items = orders2.items;
        orders1.status = orders2.status;
        orders1.tablenumber = orders2.tablenumber;
        orders1.itemcount = orders2.itemcount;
    }
    public void calculatetotal()
    {
      
    }
    public void displyorderinfo()
    {
        double sumpric = 0;
        Console.WriteLine();
        Console.WriteLine("--> "+orderid);
        Console.WriteLine("Table: "+tablenumber);
        
        for (int i = 0; i < itemcount; i++)
        {
            items[i].displyiteminfo();
            sumpric += items[i].price;
        }
        Console.WriteLine( $"total price = {sumpric}");
        Console.WriteLine( $"status -> {status}");
        Console.WriteLine();


    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class resturant
{
    menuitem[] menu = new menuitem[10];
    order[] orders = new order[11];
    int menuitemcount = 0;
    int ordercount = 0;

    public void addmenuitem()
    {   
        if(menuitemcount >= 10)
        {
            Console.WriteLine("Menu is full");
            return;
        }
        Console.WriteLine("enter id of food");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("enter name of food");
        string name = Console.ReadLine();
        Console.WriteLine("enter discription of food");
        string disc = Console.ReadLine();
        Console.WriteLine("enter price");
        double pric = double.Parse(Console.ReadLine());

        menu[menuitemcount] = new menuitem(id, name, disc, pric);

        menuitemcount++;
    }
    public void displymenu()
    {
        
        for (int i = 0; i < menuitemcount; i++)
        {
            menu[i].displyiteminfo();
        }
    }
    public void addorder()
    {
        if(ordercount >= 10) { Console.WriteLine("order is fuul");return; }
        Console.WriteLine("enter id of order");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("enter number of table");
        int table = int.Parse(Console.ReadLine());
        menuitem[] item = new menuitem[10];
        int itemcount = 0;
        string status = "preparing...";
        orders[ordercount] = new order(id, table,item,itemcount,status);

        ordercount++;

    }
    public void removeorderbyid()
    {
        Console.WriteLine();
        Console.WriteLine("enter an order id to remove:");
        int remove=int.Parse(Console.ReadLine());

        int sit = 0;
        for (int i = 0; i < ordercount; i++)
        {
            if (orders[i].orderid == remove || sit == 1)
            {
                sit = 1;
                //orders[0].removeitembyid(orders[i], orders[i + 1]);
                orders[i] = orders[i + 1];
            }
            
        }
        if (sit == 1) { ordercount -= 1; }
        
        if (sit == 1) { return; }
        Console.WriteLine("");
        Console.WriteLine("NOT FOUND");
        Console.WriteLine("");

    }
    public void searchorderbytable()
    {
        Console.WriteLine("Enter number of table to find :");
        int find = int.Parse(Console.ReadLine());
        for (int i = 0; i < ordercount; i++)
        {
            if (orders[i].tablenumber == find)
            {
                Console.WriteLine();
                Console.WriteLine("--> " +orders[i].orderid);
                Console.WriteLine("Table: " +orders[i].tablenumber);
                Console.WriteLine();
                for (int j = 0; j < orders[i].itemcount; j++)
                {

                    orders[i].items[j].displyiteminfo();

                }
                return;
            }
        }
        Console.WriteLine();
        Console.WriteLine("NOT FOUND");
        Console.WriteLine();
    }
    public void displayallorder()
    {
        for (int i = 0; i < ordercount; i++)
        {
            orders[i].displyorderinfo();
        }
    }
    public void addfood()
    {
        Console.WriteLine("choos a order id to add food");
        int add = int.Parse(Console.ReadLine());
        int id=-9;
        int ii = -9;
        for (int i = 0; i < ordercount; i++)
        {
            if (orders[i].orderid == add)
            {
                if (orders[i].itemcount >= 10) { Console.WriteLine("full");return; }
                id = orders[i].additem();
                ii = i;
            }
        }
        for(int i = 0; i < menuitemcount; i++)
        {
            if (menu[i].itemid == id)
            {
                orders[ii].items[orders[ii].itemcount] = menu[i];
                orders[ii].itemcount++;
            }
        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class resturantapp
{
    static void Main()
    {
        resturant OBJ = new resturant();
        int num;

        do
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("-> Menu manage :");
            Console.WriteLine("");
            Console.WriteLine("1 - add new item to menu");
            Console.WriteLine("2 - menu of resturant");
            Console.WriteLine("");
            Console.WriteLine("-> Order manage :");
            Console.WriteLine("");
            Console.WriteLine("3 - new order");
            Console.WriteLine("4 - add food");
            Console.WriteLine("5 - remove order by orderid");
            Console.WriteLine("6 - search order by table");
            Console.WriteLine("7 - show detale of all order");
            Console.WriteLine("");
            Console.WriteLine("Enter any number to exit . . .");


            num = int.Parse(Console.ReadLine());

            //Console.Clear();

            switch (num)
            {
                case 1:
                    OBJ.addmenuitem();
                    break;
                case 2:
                    OBJ.displymenu();
                    break;
                case 3:
                    OBJ.addorder();
                    break;
                case 4:
                    OBJ.addfood();
                    break;
                case 5:
                    OBJ.removeorderbyid();
                    break;
                case 6:
                    OBJ.searchorderbytable();
                    break;
                case 7:
                    OBJ.displayallorder();
                    break;
            }
        }
        while (num > 0 && num < 8);


    }
}
