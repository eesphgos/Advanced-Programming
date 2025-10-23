
using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;

public class Student
{
    public int studentid;
    public string name;
    public int[] grades;

    public Student (int studentid, string name)
    {
        this.studentid = studentid;
        this.name = name;
        this.grades = new int[5];
        for(int i = 0; i < 5; i++)
        {
            grades[i] = -1;
        }
    }
    public void SetGrade (int dars, int grade)
    {
        if(dars < 0 || dars > 4)
        {
            Console.WriteLine("Error : outOfRange");
            return;
        }
        if (grade < 0 || grade > 20)
        {
            Console.WriteLine("Error : outOfRange");
            return;
        }
        grades[dars] = grade;
    }
    public int calculateAverage ()
    {
        int sum=0;
        for (int i = 0; i < 5; i++)
        {
            sum+=grades[i];
        }
        return sum/5;
    }
    public void displaystudentinfo()
    {
        Console.WriteLine();
        Console.WriteLine($"student id : {studentid}");
        Console.WriteLine($"student name : {name}");

        Console.WriteLine("student grade :");
        for (int i = 0; i < 5; i++)
        {
            if (grades[i] != -1)
            {
                Console.Write($"{grades[i]} ");
            }
            
        }
        Console.WriteLine();
        Console.WriteLine(".................");
        Console.WriteLine();


    }
}
class Classroom
{
    public Student[] students;
    public int studentcount;

    public Classroom()
    {
        this.students = new Student[30];
        this.studentcount = 0;
    }
    public void addstudent(Student newStudent)
    {
        if (studentcount >= 30)
        {
            Console.WriteLine("class is full");
            return;
        }
 

        
        for(int i = 0; i < studentcount; i++)
        {
            if (students[i].studentid == newStudent.studentid)
            {
                Console.WriteLine("id is not true");
                return;
            }
        }

        students[studentcount] = newStudent;
        studentcount++;
    }
    public void removestudentbyid(int idd)
    {

        if (studentcount == 0) { Console.WriteLine("class is empty");return; }
        try
        {

            int situation = 0;//flag
            for(int i = 0; i < studentcount; i++)
            {
                if (students[i].studentid == idd)
                {
                    situation = 1;
                }
            }
            if (situation == 0)
            {
                Exception e = new Exception();
            }
        

        }
        catch
        {
            Console.WriteLine("not corect id format");
            return;
        }

        int sit = 0;
        for(int i = 0; i < studentcount; i++)
        {
            if (students[i].studentid == idd || sit ==1)
            {
                sit = 1;
                students[i] = students[i + 1];
            }
        }
        if (sit == 1)
        {
            studentcount--;
            Console.WriteLine("----------------------");
            Console.WriteLine();

            Console.WriteLine("student was deleted :)");
            Console.WriteLine();

            Console.WriteLine("----------------------");

        }

    }
    public void findstudentbyid(int studentid)
    {
        for(int i = 0; i < studentcount; i++)
        {
            if (students[i].studentid == studentid)
            {
                Console.WriteLine("student was found ->");
                Console.WriteLine();
                students[i].displaystudentinfo();
                return;
            }
        }
        Console.WriteLine("student not found");
    }
    public int calculateclassAverage()
    {
        int classsum = 0;

        for(int i = 0; i < studentcount; i++)
        {
            classsum +=  students[i].calculateAverage();
        }
        return classsum / studentcount;
    }
    public void displayRanking()
    {
        if (studentcount == 0)
        {
            Console.WriteLine("no student");
            return;
        }
        for(int i = 0; i < studentcount - 1; i++)
        {
            for (int j = 0; j < studentcount - 1; j++)
            {
                if (students[j].calculateAverage() < students[j + 1].calculateAverage())
                {
                    Student hold = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = hold;
                }
            }
        }
        for (int i = 0; i < studentcount - 1; i++)
        {
            for (int j = 0; j < studentcount - 1; j++)
            {
                if (students[j].calculateAverage() == students[j + 1].calculateAverage())
                {
                    if (students[j].studentid > students[j + 1].studentid)
                    {
                        Student hold = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = hold;
                    }
                }
            }
        }

        for (int i = 0; i < studentcount; i++)
        {
            Console.Write(i + 1);
            students[i].displaystudentinfo();
        }
    } 
    public void displayallstudent()
    {
        for(int i = 0; i < studentcount; i++)
        {
            students[i].displaystudentinfo();
        }
    }
}
class Program
{
    static void Main()
    {

        Student std1=new Student(100,"Ali");
        Student std2=new Student(101,"Kian");
        Student std3=new Student(102,"Bab");
        Student std4=new Student(103,"Sam");

        std1.SetGrade(0,12);
        std1.SetGrade(1,11);
        std1.SetGrade(2,18);
        std1.SetGrade(3,19);
        std1.SetGrade(4,10);

        std2.SetGrade(0,18);
        std2.SetGrade(1,11);
        std2.SetGrade(2,5);
        std2.SetGrade(3,12);
        std2.SetGrade(4,10);

        std3.SetGrade(0,20);
        std3.SetGrade(1,2);
        std3.SetGrade(2,12);
        std3.SetGrade(3,17);
        std3.SetGrade(4,11);

        std4.SetGrade(0,5);
        std4.SetGrade(1,15);
        std4.SetGrade(2,11);
        std4.SetGrade(3,18);
        std4.SetGrade(4,20);

        Classroom clas = new Classroom();

        clas.addstudent(std1);
        clas.addstudent(std2);
        clas.addstudent(std3);
        clas.addstudent(std4);

        clas.displayallstudent();

        clas.findstudentbyid(101);

 

        clas.removestudentbyid(101);

 

        clas.displayRanking();
        //clas.displayallstudent();
    }
}
