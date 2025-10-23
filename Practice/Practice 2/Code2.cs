using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

class Employee
{
    public string name;
    public string id;
    public string role;
    public int age;

    public Employee(string name, string id, string role, int age)
    {
        this.name = name;
        this.id = id;
        this.role = role;
        this.age = age;
    }
    public void getEmployeeinfo()
    {
        Console.WriteLine("-name : " + name);
        Console.WriteLine("id : " + id);
        Console.WriteLine("role : " + role);
        Console.WriteLine("age : " + age);

    }
}
class Project
{
    public string name;
    public DateTime startdate;
    public DateTime enddate;
    public Employee[] teamMembers;

    public Project(string name, DateTime startdate, DateTime enddate, Employee[] teamMembers)
    {
        this.name = name;
        this.startdate = startdate;
        this.enddate = enddate;
        this.teamMembers = new Employee[0];
    }
    public void AddTeamMember(Project aaa)
    {
        Console.WriteLine("enter name");
        string empname = Console.ReadLine();
        Console.WriteLine("enter id");
        string id =Console.ReadLine();
        Console.WriteLine("role");
        string role =Console.ReadLine();
        Console.WriteLine("age");
        int age =int.Parse( Console.ReadLine());
        int nnn = aaa.teamMembers.GetLength(0)+1;

        Employee[] hlep = new Employee[nnn];
         
        for (int i = 0; i < nnn - 1;i++)
        {
            hlep[i] = teamMembers[i];
        }
        Employee a = new Employee(empname,id,role,age);
        hlep[nnn-1] = a;
        aaa.teamMembers = new Employee[nnn];
        for (int i = 0; i < nnn; i++)
        {
            aaa.teamMembers[i] = hlep[i];
        }
    }
    public TimeSpan getProjectDuration(Project aaa)
    {
        TimeSpan a = aaa.enddate - aaa.startdate;
        return a;
    }
    public void getAverageTeamAge()
    {
        int sum = 0;
        for (int i = 0; i < teamMembers.GetLength(0); i++)
        {
            sum += teamMembers[i].age;
        }
        sum = sum / teamMembers.GetLength(0);
        Console.WriteLine();

        Console.WriteLine("Average of age = "+ sum);
    }
    public void getMaxTeamMemberAge(Project aaa)
    {
        int max = 0;
        for (int i = 0; i < aaa.teamMembers.GetLength(0); i++)
        {
            if (aaa.teamMembers[i].age > max)
            {
                max = aaa.teamMembers[i].age;
            }
        }
    }
    public void getProjectDetail()
    {
        Console.WriteLine($"Name = {name}");
        Console.WriteLine("Start date = " + startdate.Year + " " + startdate.Month + " " + startdate.Day);
        Console.WriteLine("End date = " + enddate.Year + " " + enddate.Month + " " + enddate.Day);

        for (int j = 0; j < teamMembers.GetLength(0); j++)
        {
            Console.WriteLine("");
            teamMembers[j].getEmployeeinfo();
        }
        if(teamMembers.GetLength(0) != 0) {getAverageTeamAge(); }
        
        Console.WriteLine();
    }

}
class Projectmanager
{
    public Project[] projects = new Project[0];

    public int projectcount = 0;

    public void addproject()
    {
        projectcount++;

        Project[] copy = new Project[projectcount];

        for (int i=0; i < projectcount-1; i++)
        {
            copy[i] = projects[i];
        }
        projects = new Project[projectcount];
        for (int i = 0; i < projectcount; i++)
        {
           projects[i] = copy[i]  ;
        }

        Console.WriteLine("enter name");
        string projname = Console.ReadLine();
        Console.WriteLine("enter year of start");
        int sy = int.Parse(Console.ReadLine());
        Console.WriteLine("enter month of start");
        int sm = int.Parse(Console.ReadLine());
        Console.WriteLine("enter day of start");
        int sd = int.Parse(Console.ReadLine());
        Console.WriteLine("enter year of end");
        int ey = int.Parse(Console.ReadLine());
        Console.WriteLine("enter month of end");
        int em = int.Parse(Console.ReadLine());
        Console.WriteLine("enter day of end");
        int ed = int.Parse(Console.ReadLine());

        projects[projectcount-1] = new Project(projname, new DateTime(sy, sm, sd), new DateTime(ey, em, ed), new Employee[0]);
       
    }
    public void findProjectByNamea()
    {
        Console.WriteLine("enter name of project");
        string sarch = Console.ReadLine();


        if(projectcount == 0) {
                Console.WriteLine();
            Console.WriteLine("Empty."); 
                Console.WriteLine();
            return;
        }
        for (int i = 0; i < projectcount; i++)
        {
            if (sarch == projects[i].name)
            {
                Console.WriteLine();
                Console.WriteLine($"Name = {projects[i].name}");
                Console.WriteLine("Start date = " + projects[i].startdate.Year +" "+ projects[i].startdate.Month + " "+ projects[i].startdate.Day);
                Console.WriteLine("End date = " + projects[i].enddate.Year +" "+ projects[i].enddate.Month +" "+ projects[i].enddate.Day);
                Console.WriteLine();

                for (int j = 0; j < 0; j++)
                {
                    Console.WriteLine(projects[i].teamMembers[j].name);
                }
                return;
            }
            
        }
        Console.WriteLine();
        Console.WriteLine("Not found.");
        Console.WriteLine();



    }
    public void sortProjectbyduration()
    {
        for (int i=0;i<projectcount-1; i++)
        {
            for (int j = 0; j < projectcount - 1; j++)
            {
                if (projects[j].enddate - projects[j].startdate < projects[j+1].enddate - projects[j + 1].startdate)
                {
                    Project hold = projects[j];
                    projects[j] = projects[j + 1];
                    projects[j + 1] = hold;
                    
                }
            }
        }
    }
    public void gerProjectwithMaxduration()
    {
        if(projectcount == 0) { Console.WriteLine("empty");return; }
        Project[] max = new Project[projectcount];
        for(int i = 0; i < projectcount; i++)
        {
            max[i] = projects[i];
        }

        for (int i = 0; i < projectcount - 1; i++)
        {
            for (int j = 0; j < projectcount - 1; j++)
            {
                if (max[j].enddate - max[j].startdate < max[j + 1].enddate - max[j + 1].startdate)
                {
                    Project hold = max[j];
                    max[j] = max[j + 1];
                    max[j + 1] = hold;

                }
            }
            
        }
        Console.WriteLine();
        Console.WriteLine("Project "+max[0].name);
        Console.WriteLine();
    }
    public void getAllprojectdetales()
    {
        for (int i = 0; i < projectcount; i++)
        {
            projects[i].getProjectDetail();
        }
    }
}

class ConpanyApp
{
    static void Main()
    {
        int a;

        Projectmanager OBJ = new Projectmanager();
        Project obj ;

        do
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("1 - show the detail of all project");
            Console.WriteLine("2 - searching project by name");
            Console.WriteLine("3 - sort ptoject by end time");
            Console.WriteLine("4 - find projecr with longest duration");
            Console.WriteLine("5 - add new project");
            Console.WriteLine("6 - add new member");
            Console.WriteLine("Press any number to end...");

            a = int.Parse(Console.ReadLine());
            Console.Clear();


            switch (a)
            {
                case (1):
            
                    OBJ.getAllprojectdetales();

                    break;
                case (2):

                    OBJ.findProjectByNamea();

                    break;
                case (3):

                    OBJ.sortProjectbyduration();

                    break;
                case (4):

                    OBJ.gerProjectwithMaxduration();

                    break;
                case (5):
                    
                    OBJ.addproject();
                    break;
                case (6):

                    //OBJ.addemp();
                    Console.WriteLine("choose a name of project to add employee");
                    string ad = Console.ReadLine();
                    int sit = 0;
                    for (int i = 0; i < OBJ.projectcount; i++)
                    {

                        if (ad == OBJ.projects[i].name)
                        {
                            OBJ.projects[i].AddTeamMember(OBJ.projects[i]);
                            sit = 1;
                        }
                        
                    }
                    if (sit == 0) { Console.WriteLine("Not Found"); }

                    break;
                
            }



        } while (a >= 1 && a <= 6);
    }
}
//5
//a
//5
//5
//5
//6
//6
//6
//5
//b
//5
//5
//5
//6
//6
//8
//5
//v
//5
//5
//5
//6
//8
//8
