public enum level
{
    beginner,
    intermediate,
    advanced
}
public interface IPersian 
{
    string firstname { get; set; }
    string lastname { get; set; }
    string ssn { get; set; }
}
public interface IInstructor
{
    string specilty { get; set;}
    string University { get; set; }
    List<Student> students { get; set; }
    public string work();
    public string Graduatedfromm();
    public List<Student> findstudent(string major);
    public bool addstudent(Student student);
}
public class Student : IPersian
{
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string ssn { get; set; }
    public string major { get; set; }
    public level Level { get; set; }
    public Student(string firstname,string lastname,string ssn,string major,level Level)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.ssn = ssn;
        this.major = major;
        this.Level = Level;
    }
}
class ProgammingInstructor :IInstructor,IPersian
{
    int maxstudent { get; set; }
    
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string ssn { get; set; }
    public string specilty { get; set; }
    public string University { get; set; }
    public List<Student> students { get; set; }
    public ProgammingInstructor(int maxstudent, string firstname, string lastname, string ssn, string specilty, string university)
    {
        this.maxstudent = maxstudent;
        this.firstname = firstname;
        this.lastname = lastname;
        this.ssn = ssn;
        this.specilty = specilty;
        University = university;
        this.students = new List<Student>();
    }

    public string work()
    {
        return $"Instructor's speciality is {specilty}"; 
    }
    public string Graduatedfromm()
    {
        return $"{firstname} {lastname} graduated from {University}";
    }
    public List<Student> findstudent(string major)
    {
        List<Student> anew = new List<Student>();
            foreach(Student i in students)
            {
                if (i.major.IndexOf(major) != -1)
                {
                    anew.Add(i);
                }
            }
        
        return anew;
    }
    public bool addstudent(Student student)
    {
        if (students.Count == maxstudent) { Console.WriteLine("Class is full !"); return false; }
        if (student.major.IndexOf("Python") == -1 && student.major.IndexOf("Java") == -1&& student.major.IndexOf("C#") == -1) { Console.WriteLine("The major is invalid"); return false; }
        students.Add(student);
        return true;
    }
}
class Academy
{
    public static List<IInstructor> list = new List<IInstructor>();
    public static List<Student> listofadvancestudent()
    {
        List<Student> advanc = new List<Student>();
        foreach(IInstructor i in list)
        {
            foreach(Student j in i.students)
            {
                if (j.Level == level.advanced)
                {
                    advanc.Add(j);
                }
            }
        }
        return advanc;
    }
    public static string instructorwithmoststudent()
    {
        int a = -1;
        string name = "";
        foreach(ProgammingInstructor i in list)
        {
            if (i.students.Count > a)
            {
                a = i.students.Count;
                name = $"Name : {i.firstname}\nLast name : {i.lastname}";
            }
        }
        return name;
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1-add instructor");
            Console.WriteLine("2-add student to instructor");
            Console.WriteLine("3-search student by major");
            Console.WriteLine("4-show advanced student");
            Console.WriteLine("5-show instructor with most student");
            Console.WriteLine("6-Exit");
            Console.WriteLine("");
            string choos = Console.ReadLine();
            Console.Clear();
            switch (choos) 
            {
                case "1":
                    while (true)
                    {
                        Console.WriteLine("Enter instructor name");
                        string nm = Console.ReadLine();
                        Console.WriteLine("Enter structor last naem");
                        string ls = Console.ReadLine();
                        Console.WriteLine("Enter instructor ssn");
                        string sss = Console.ReadLine();
                        Console.WriteLine("Enter specialty of instructor");
                        string sp = Console.ReadLine();
                        Console.WriteLine("Enter university of instructor");
                        string un = Console.ReadLine();
                        Console.WriteLine("Enter maximum capacity of class");
                        int max = 0;
                        try { max = int.Parse(Console.ReadLine()); } catch(Exception e) { Console.WriteLine(e.Message+"\ntry again");continue; }
                        Console.WriteLine("Instructoe added succesfully");
                        list.Add(new ProgammingInstructor(max,nm,ls,sss,sp,un));
                        break;
                    }
                    
                    break;
                case "2":
                    if(list.Count == 0) { Console.WriteLine("We havent any instructor");break; }
                    while (true)
                    {
                        Console.WriteLine("Enter an instructor name to add student");
                        string a = Console.ReadLine();
                        bool flag = true;
                        foreach(ProgammingInstructor i in list)
                        {
                            if (i.firstname == a)
                            {
                                flag = false;
                                while (true)
                                {
                                    Console.WriteLine("Enter name");
                                    string n = Console.ReadLine();
                                    Console.WriteLine("Enter last name");
                                    string l = Console.ReadLine();
                                    Console.WriteLine("Enter ssn");
                                    string s = Console.ReadLine();
                                    Console.WriteLine("Enter major");
                                    string m = Console.ReadLine();
                                    Console.WriteLine("Enter level(beginner,intermediate,advanced)");
                                    level level;
                                    string lev = Console.ReadLine();
                                    try 
                                    { 
                                        foreach(char j in lev.ToArray())
                                        {
                                            if (char.IsDigit(j))
                                            {
                                                throw new Exception("Invalid Entery");
                                            }
                                        }
                                        level = (level)Enum.Parse(typeof(level),lev); 
                                    }
                                    catch(Exception e) 
                                    {
                                        Console.WriteLine(e.Message + "\nTry again");
                                        break; 
                                    }
                                    if(i.addstudent(new Student(n, l, s, m, level)))
                                    {
                                        Console.WriteLine("The student added succesfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The student adding field");
                                    }
                                        break;
                                }
                            } 
                        }
                        if (flag) { Console.WriteLine("instructor NOt Found"); }
                        break;
                    }
                    break;
                case "3":
                    if (list.Count == 0) { Console.WriteLine("we dont hove any instructor");break; }
                    Console.WriteLine("Enter your major to search");
                    string sch = Console.ReadLine();
                    List<Student> search = new List<Student>();
                    foreach(IInstructor i in list)
                    {
                        foreach(Student j in i.findstudent(sch))
                        {
                            search.Add(j);
                        }
                    }
                    foreach(Student i in search)
                    {
                        Console.WriteLine($"   -->Name : {i.firstname}\nLast Name : {i.lastname}\nSSN : {i.ssn}\nMajor : {i.major}\nLevel : {i.Level}\n");
                    }
                    break;
                case "4":
                    if (list.Count == 0) { Console.WriteLine("We dont have any instructor"); break; }
                    foreach(Student i in Academy.listofadvancestudent())
                    {
                        Console.WriteLine($"  -{i.firstname}");
                    }
                    break;
                case "5":
                    if (list.Count == 0) { Console.WriteLine("We dont have any instructor");break; }
                    Console.WriteLine(Academy.instructorwithmoststudent());
                    break;
                case "6":
                    Console.WriteLine("Good luck");
                    return;
            }
        }
       

    }
}
