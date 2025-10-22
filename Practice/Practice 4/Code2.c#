using System;
using static System.Console;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;
using System.Transactions;
enum Shifttype
{
    morning,
    evening,
    night,
    custum,
    oncall
}
enum Department
{
    engineering,
    sales,
    HR,
    operations,
    finance,
    marketing
}
enum Employeestate
{
    active,
    onleave,
    terminated,
    probation
}
enum Paygrade
{
    Intern,
    Junior,
    Midlevel,
    Senior,
    Lead,
    Manager
}
struct Time
{
    public int hour { get; set; }
    public int min { get; set; }
    public Time(int hour, int min)
    {
        this.hour = hour;
        this.min = min;
    }
}
struct Workshift
{
    [JsonInclude]
    public Time starttime { get; set; }
    [JsonInclude]
    public Time endtime { get; set; }
    [JsonInclude]
    Shifttype shifttype { get; set; }
    [JsonIgnore]
    public int overtimehour;
    [JsonInclude]
    public int Overtimehour
    {
        get { return overtimehour; }
        private set { overtimehour = value; }
    }
    [JsonInclude]
    public int daysperweek { get; set; }

    public Workshift(Shifttype shifttype, Time starttime, Time endtime, int Overtimehour, int daysperweek)
    {
        this.shifttype = shifttype;
        this.starttime = starttime;
        this.endtime = endtime;
        this.Overtimehour = overtimehour;
        this.daysperweek = daysperweek;
    }
    public bool IsValidShift(int sh, int eh, int sm, int em, int over, int day)
    {
        if (shifttype == Shifttype.oncall)
        {
            if (sh > eh)
            {
                if ((eh + 24 - sh > 12) || (eh + 24 - sh == 12 && em > sm))
                {
                    WriteLine("Shift time cant be more than 12 hour");
                    return true;
                }
            }
            else if (sh < eh)
            {
                if ((eh - sh > 12) || (eh - sh == 12 && em > sm))
                {
                    WriteLine("Shift time cant be more than 12 hour");
                    return true;
                }
            }
            else if (sm < em)
            {

            }
            else
            {
                WriteLine("Shift time cant be more than 12 hour");
                return true;
            }
        }
        if (over < 0 || day > 7 || day < 0) { return true; }
        return false;
    }
    public double GetShiftHours()
    {
        double weekhour;
        if (starttime.hour > endtime.hour)
        {
            if (starttime.min > endtime.min)
            {
                weekhour = endtime.hour + 24 - starttime.hour + (endtime.min + 60 - starttime.min) / 60;
            }
            else if (starttime.min < endtime.min)
            {
                weekhour = endtime.hour + 24 - starttime.hour + (endtime.min - starttime.min) / 60;
            }
            else
            {
                weekhour = endtime.hour + 24 - starttime.hour;
            }
        }
        else if (starttime.hour < endtime.hour)
        {
            if (starttime.min > endtime.min)
            {
                weekhour = endtime.hour - starttime.hour + (endtime.min + 60 - starttime.min) / 60;
            }
            else if (starttime.min < endtime.min)
            {
                weekhour = endtime.hour - starttime.hour + (endtime.min - starttime.min) / 60;
            }
            else
            {
                weekhour = endtime.hour - starttime.hour;
            }
        }
        else
        {
            if (starttime.min > endtime.min)
            {
                weekhour = 23 + (endtime.min + 60 - starttime.min) / 60;
            }
            else if (starttime.min < endtime.min)
            {
                weekhour = 24 + (endtime.min - starttime.min) / 60;
            }
            else
            {
                weekhour = 24;
            }
        }
        return weekhour * daysperweek + overtimehour;
    }
    public Workshift AddOvertime(int hour)
    {
        Workshift NEW = this;
        NEW.Overtimehour += hour;
        return NEW;
    }
    public void show()
    {
        WriteLine("Shift -->");
        WriteLine($"    Shift type : {shifttype}");
        WriteLine($"    Start : {starttime.hour}:{starttime.min}");
        WriteLine($"    End : {endtime.hour}:{endtime.min}");
        WriteLine($"    Over time : {overtimehour} H");
        WriteLine($"    Day per week : {daysperweek} D");

    }
}
class Employee
{
    public int EmployeeId { get; }
    string name;
    [JsonInclude]
    string Name
    {
        get { return name; }
        set
        {
            if (value == "" || value == null) { WriteLine("Name cant be null or empty"); throw new Exception(); }
            this.name = value;
        }
    }
    [JsonInclude]
    Paygrade Grade { get; set; }
    decimal salary;
    [JsonInclude]
    decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < 0 || PayGradeRange[this.Grade].max < value || PayGradeRange[this.Grade].min > value) { WriteLine("Salary not match to Grade"); throw new Exception(); }
            salary = value;
        }
    }
    [JsonInclude]
    Department Department { get; set; }
    [JsonInclude]
    Employeestate State { get; set; }
    [JsonInclude]
    public Workshift Shift { get; set; }
    [JsonInclude]
    DateTime HireDate { get; }
    [JsonInclude]
    double PerformanceRating { get; set; }
    int YearsOfService { get; set; }

    public Employee(int EmployeeId, string Name, Paygrade Grade, decimal Salary, Department Department, Employeestate State, Workshift Shift, DateTime HireDate, double PerformanceRating)
    {
        this.EmployeeId = EmployeeId;
        this.Name = Name;
        this.Grade = Grade;
        this.Salary = Salary;
        this.Department = Department;
        this.State = State;
        this.Shift = Shift;
        this.HireDate = HireDate;
        this.PerformanceRating = PerformanceRating;
        this.YearsOfService = (DateTime.Now.Year - HireDate.Year);
    }
    public void ApplyRaise(int percen)
    {
        if (PerformanceRating < 4 || YearsOfService < 0) { WriteLine("This employee cant be rased at salary");return; }
        if(Salary == PayGradeRange[Grade].max) { WriteLine("This employee at max of salary");return; }
        salary += salary * percen / 100;
        if (salary > PayGradeRange[Grade].max) { salary = PayGradeRange[Grade].max; }
        WriteLine("Salary rasing complete:)");
    }
    public decimal CalculateBounce()
    {
        decimal Tenure = salary * (Math.Min(YearsOfService, 10) / 100);

        return (salary / 20) + Tenure;
    }
    public bool CanTakeOvertime()
    {
        if (State != Employeestate.active) { return false; }
        if (Shift.GetShiftHours() >= 40) { return false; }
        return true;
    }
    public void Promoteto()
    {
        if (Grade == Paygrade.Manager) { WriteLine("This employee is manager cant upgrad his"); return; }
        Grade++;
        salary = PayGradeRange[Grade].min;
        WriteLine();
        WriteLine("*******************");
        WriteLine("upgraded sucsesfuly");
    }
    public void AddOvertime()
    {
        while (true)
        {
            WriteLine($"you can add over time between 0 - {40 - Shift.GetShiftHours()}");
            int hour = 0;
            try { hour = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            if (hour < 0 || hour > 40 - Shift.GetShiftHours()) { WriteLine("Your entry out of the range"); continue; }
            Shift =Shift.AddOvertime(hour);
            return; ;
        }
    }
    public void show()
    {
        WriteLine($"ID >> {EmployeeId}");
        WriteLine($"Name : {name}");
        WriteLine($"Grade : {Grade}");
        WriteLine($"Salary : {salary} $");
        WriteLine($"Department : {Department}");
        WriteLine($"State : {State}");
        Shift.show();
        WriteLine($"Hire date : {HireDate}");
        WriteLine($"Performance : {PerformanceRating}");
        WriteLine($"Year of servis : {YearsOfService} Year");

    }
    private static readonly Dictionary<Paygrade, (decimal min, decimal max)> PayGradeRange = new()
    {
        {Paygrade.Intern,(20000,30000) },
        {Paygrade.Junior,(30000,50000) },
        {Paygrade.Midlevel,(50000,80000) },
        {Paygrade.Senior,(80000,120000)},
        {Paygrade.Lead,(120000,160000) },
        {Paygrade.Manager,(160000,250000) }
    };
}
class Program
{
    static void Main()
    {
        while (true)
        {
            WriteLine("");
            WriteLine("1-Add Employee");
            WriteLine("2-Show Information");
            WriteLine("3-Apply Raise");
            WriteLine("4-Calculat Bonus");
            WriteLine("5-Can Take Overtime");
            WriteLine("6-Ptomote");
            WriteLine("7-Add over time");
            WriteLine("8-Exit");
            int choose = 0;
            try { choose = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            switch (choose)
            {
                case 1:
                    AddEmplotee();
                    break;
                case 2:
                    Showinformation();
                    break;
                case 3:
                    ApplyRase();
                    break;
                case 4:
                    Calculatbonus();
                    break;
                case 5:
                    cantakeovertime();
                    break;
                case 6:
                    Pormoto();
                    break;
                case 7:
                    addovtime();
                    break;
                case 8:
                    WriteLine("Good Bye");
                    return;
                default:
                    WriteLine("Pleas Choose Between 1-7");
                    break;
            }
        }
    }
    public static void AddEmplotee()
    {
        int c = 0;
        string save = ReadAllText("Save.json");
        List<Employee> find = new List<Employee>();
        string name;
        Paygrade PayG = Paygrade.Intern;
        int salary = 0;
        Department Dep = Department.engineering;
        Employeestate Sit = Employeestate.active;
        Workshift WS = new Workshift();
        DateTime Hire;
        double Perform;

        //getting id
        while (true)
        {
            WriteLine("Enter an Id to add employee");
            try { c = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            break;
        }
        //reading file and used id
        while (true)
        {
            try { find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true }); }
            catch (Exception e) { Console.WriteLine(e.Message); continue; }

            foreach (Employee i in find)
            {
                if (i.EmployeeId == c)
                {
                    Console.WriteLine("This ID used for another employee");
                    return;
                }
            }
            break;
        }
        //getting name
        while (true)
        {
            WriteLine("Enter Name of employee");
            name = ReadLine();
            try { new Employee(-1, name, Paygrade.Intern, 25000, new Department(), new Employeestate(), new Workshift(), DateTime.Now, 0); }
            catch { continue; }
            break;
        }
        //getting grade
        while (true)
        {
            WriteLine("Enter Grade of employee(Intern-Junior-Midlevel-Senior-Lead-Manager)");
            try
            {
                string N = ReadLine();
                char[] n = N.ToCharArray();
                foreach (char i in n)
                {
                    if (char.IsDigit(i)) { throw new Exception(); }
                }
                PayG = (Paygrade)Enum.Parse(typeof(Paygrade), N);
            }
            catch { WriteLine("Invalid type"); continue; }
            break;
        }
        //getting salary    
        while (true)
        {
            WriteLine("Enter Salary of employee");
            try { salary = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            try { new Employee(-1, name, PayG, salary, new Department(), new Employeestate(), new Workshift(), DateTime.Now, 0); }
            catch { continue; }
            break;
        }
        //getting department
        while (true)
        {
            WriteLine("Enter Department of new employee(engineering,sales,HR,operations,finance,marketing)");
            try
            {
                string D = ReadLine();
                char[] d = D.ToCharArray();
                foreach (char i in d)
                {
                    if (char.IsDigit(i)) { throw new Exception(); }
                }
                Dep = (Department)Enum.Parse(typeof(Department), D);
            }
            catch { WriteLine("Invalid Department type"); continue; }
            break;
        }
        //getting State
        while (true)
        {
            WriteLine("Enter State of new employee(active,onleave,terminated,probation)");
            try
            {
                string S = ReadLine();
                char[] s = S.ToCharArray();
                foreach (char i in s)
                {
                    if (char.IsDigit(i)) { throw new Exception(); }
                }
                Sit = (Employeestate)Enum.Parse(typeof(Employeestate), S);
            }
            catch { WriteLine("Invalid Employee State type"); continue; }
            break;
        }
        //getting shipt type
        while (true)
        {
            int over = 0;
            int day = 0;

            WriteLine("Enter Shift type of employee(morning,evening,night,custum,oncall)");
            Shifttype SHi = new Shifttype();
            try
            {
                string H = ReadLine();
                char[] h = H.ToCharArray();
                foreach (char i in h)
                {
                    if (char.IsDigit(i)) { throw new Exception(); }
                }
                SHi = (Shifttype)Enum.Parse(typeof(Shifttype), H);
            }
            catch { WriteLine("Invalid Shift type"); continue; }
            Time start = new Time();
            Time end = new Time();
            if (SHi == Shifttype.custum)
            {
                while (true)
                {
                    WriteLine("Enter start time(hour,min)");
                    try
                    {
                        int hour = int.Parse(ReadLine());
                        if (hour > 23 || hour < 0) { WriteLine("Hour most be between 0-23"); continue; }
                        int min = int.Parse(ReadLine());
                        if (min > 59 || min < 0) { WriteLine("Minute most be between 0-59"); continue; }
                        start = new Time(hour, min);
                    }
                    catch (Exception e) { WriteLine(e.Message); continue; }
                    break;
                }
                while (true)
                {
                    WriteLine("Enter end time(hour,min)");
                    try
                    {
                        int hour = int.Parse(ReadLine());
                        if (hour > 23 || hour < 0) { WriteLine("Hour most be between 0-23"); continue; }
                        int min = int.Parse(ReadLine());
                        if (min > 59 || min < 0) { WriteLine("Minute most be between 0-59"); continue; }
                        end = new Time(hour, min);
                    }
                    catch (Exception e) { WriteLine(e.Message); continue; }
                    break;
                }

            }
            else if (SHi == Shifttype.oncall)
            {
                while (true)
                {
                    while (true)
                    {
                        WriteLine("Enter start time(hour,min)");
                        try
                        {
                            int hour = int.Parse(ReadLine());
                            if (hour > 23 || hour < 0) { WriteLine("Hour most be between 0-23"); continue; }
                            int min = int.Parse(ReadLine());
                            if (min > 59 || min < 0) { WriteLine("Minute most be between 0-59"); continue; }
                            start = new Time(hour, min);
                        }
                        catch (Exception e) { WriteLine(e.Message); continue; }
                        break;
                    }
                    while (true)
                    {
                        WriteLine("Enter end time(hour,min)");
                        try
                        {
                            int hour = int.Parse(ReadLine());
                            if (hour > 23 || hour < 0) { WriteLine("Hour most be between 0-23"); continue; }
                            int min = int.Parse(ReadLine());
                            if (min > 59 || min < 0) { WriteLine("Minute most be between 0-59"); continue; }
                            end = new Time(hour, min);
                        }
                        catch (Exception e) { WriteLine(e.Message); continue; }
                        break;

                    }

                    break;

                }
            }
            else
            {
                if (SHi == Shifttype.morning) { start = new Time(6, 0); end = new Time(14, 00); }
                else if (SHi == Shifttype.evening) { start = new Time(14, 0); end = new Time(22, 00); }
                else { start = new Time(22, 0); end = new Time(6, 00); }
            }
            while (true)
            {
                WriteLine("Enter day per week of employee");

                try { day = int.Parse(ReadLine()); }
                catch (Exception e) { WriteLine(e.Message); continue; }
                break;
            }
            if (new Workshift(SHi, start, end, over, day).IsValidShift(start.hour, end.hour, start.min, end.min, over, day)) { WriteLine("shift not valid"); continue; }
            WS = new Workshift(SHi, start, end, over, day);
            break;
        }
        //getting Hire date
        while (true)
        {

            WriteLine("Enter Hire date(year,month,day)");
            int yy = 0, mm = 0, dd = 0;
            try
            {
                yy = int.Parse(ReadLine()); if (yy < 0) { WriteLine("we dont have negativ year"); continue; }
                mm = int.Parse(ReadLine()); if (mm < 0 || mm > 12) { WriteLine("wrong Month entry"); continue; }
                dd = int.Parse(ReadLine()); if (dd < 0 || dd > 31) { WriteLine("wrong day entry"); continue; }
            }
            catch (Exception e) { WriteLine(e.Message); continue; }
            Hire = new DateTime(yy, mm, dd);
            break;

        }
        //getting performance
        while (true)
        {
            WriteLine("Enter performance rate of employee(1-5)");
            try { Perform = double.Parse(ReadLine()); if (Perform < 1 || Perform > 5) { WriteLine("Performance most be in range"); continue; } }
            catch (Exception e) { WriteLine(e.Message); continue; }
            break;
        }



        Employee A;
        try { A = new Employee(c, name, PayG, salary, Dep, Sit, WS, Hire, Perform); if (A != null) { find.Add(A); } }
        catch { return; }
        WriteLine("Employee Added sucsesfully");
        save = Serialize(find, new JsonSerializerOptions { WriteIndented = true });
        WriteAllText("Save.json", save);
    }
    public static void Showinformation()
    {
        string save = ReadAllText("Save.json");
        List<Employee> find = new List<Employee>();
        find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true });
        if (find.Count == 0) { WriteLine("not any employee to show"); return; }
        for (int i = 0; i < find.Count; i++)
        {
            WriteLine($"Employee {i + 1} -------------------");
            WriteLine();
            find[i].show();
            WriteLine();
            WriteLine("------------------------------");
        }
    }
    public static void ApplyRase()
    {
        string save = ReadAllText("Save.json");
        List<Employee> find = new List<Employee>();
        find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true });
        if (find.Count == 0) { WriteLine("not any employee to show"); return; }
        int id;
        while (true)
        {
            WriteLine("Enter employee ID to rase salary");
            try { id = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            break;
        }
        foreach (Employee i in find)
        {
            if (i.EmployeeId == id)
            {
                while (true)
                {
                    WriteLine("Enter percen of rase");
                    int percen;
                    try { percen = int.Parse(ReadLine()); if (percen < 0) { WriteLine("Percent cant be negative"); continue; } }
                    catch (Exception e) { WriteLine(e.Message); continue; }
                    i.ApplyRaise(percen);
                    save = Serialize(find, new JsonSerializerOptions { WriteIndented = true });
                    WriteAllText("Save.json", save);
                    return;
                }
            }
        }
        WriteLine($"Employee with ID : {id} Not Found . . .404 ");
    }
    public static void Calculatbonus()
    {
        string save = ReadAllText("Save.json");
        List<Employee> find = new List<Employee>();
        find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true });
        if (find.Count == 0) { WriteLine("not any employee to show"); return; }
        int id;
        while (true)
        {
            WriteLine("Enter employee ID to calculate bonus");
            try { id = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            break;
        }
        foreach (Employee i in find)
        {
            if (i.EmployeeId == id)
            {
                while (true)
                {
                    WriteLine(i.CalculateBounce() + " $");
                    return;
                }
            }
        }
        WriteLine($"Employee with ID : {id} Not Found . . .404 ");
    }
    public static void cantakeovertime()
    {
        string save = ReadAllText("Save.json");
        List<Employee> find = new List<Employee>();
        find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true });
        if (find.Count == 0) { WriteLine("not any employee to show"); return; }
        int id;
        while (true)
        {
            WriteLine("Enter employee ID to over time state");
            try { id = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            break;
        }
        foreach (Employee i in find)
        {
            if (i.EmployeeId == id)
            {
                while (true)
                {

                    if (i.CanTakeOvertime()) { WriteLine($"Employee can use {i.Shift.Overtimehour} H of his over time hour"); }
                    else { WriteLine("Employee cant use overhour time"); }
                    return;
                }
            }
        }
        WriteLine($"Employee with ID : {id} Not Found . . .404 ");
    }
    public static void Pormoto()
    {
        string save = ReadAllText("Save.json");
        List<Employee> find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true });
        if (find.Count == 0) { WriteLine("not any employee to show"); return; }
        while (true)
        {
            WriteLine("Enter ID of employee to Upgrade");
            int id = 0;
            try { id = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            foreach (Employee i in find)
            {
                if (i.EmployeeId == id)
                {
                    i.Promoteto();
                    save = Serialize(find, new JsonSerializerOptions { WriteIndented = true });
                    WriteAllText("Save.json", save);
                    return;
                }
            }
            WriteLine($"Employee {id}  Not Found to upgrade");
            break;
        }
    }
    public static void addovtime()
    {
        string save = ReadAllText("Save.json");
        List<Employee> find = Deserialize<List<Employee>>(save, new JsonSerializerOptions { WriteIndented = true });
        if (find.Count == 0) { WriteLine("not any employee to show"); return; }
        while (true)
        {
            WriteLine("Enter ID of employee to add over time");
            int id = 0;
            try { id = int.Parse(ReadLine()); }
            catch (Exception e) { WriteLine(e.Message); continue; }
            foreach (Employee i in find)
            {
                if (i.EmployeeId == id)
                {
                    i.AddOvertime();
                    save = Serialize(find, new JsonSerializerOptions { WriteIndented = true });
                    WriteAllText("Save.json", save);
                    WriteLine("over time extended");
                    return;
                }
            }
            WriteLine($"Employee {id}  Not Found to add over time");
            break;
        }
    }
}
