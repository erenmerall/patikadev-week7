using System;
using System.Collections.Generic;
using System.Linq;

class Students
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

class Classes
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}

class Linq_Group_Join
{
    static void Main(string[] args)
    {
        // öğrenciler listesi 
        List<Students> students = new List<Students>
        {
            new Students { StudentId = 1, StudentName = "Student1", ClassId = 1 },
            new Students { StudentId = 2, StudentName = "Student2", ClassId = 2 },
            new Students { StudentId = 3, StudentName = "Student3", ClassId = 1 },
            new Students { StudentId = 4, StudentName = "Student4", ClassId = 3 },
            new Students { StudentId = 5, StudentName = "Student5", ClassId = 2 }
        };

        // sınıflar listesi 
        List<Classes> classes = new List<Classes>
        {
            new Classes { ClassId = 1, ClassName = "Matematik" },
            new Classes { ClassId = 2, ClassName = "Türkçe" },
            new Classes { ClassId = 3, ClassName = "Kimya" },
        };

        // GROUP JOIN
        var classWithStudents = from cls in classes
                                join std in students
                                on cls.ClassId equals std.ClassId
                                into studentGroup
                                select new
                                {
                                    ClassName = cls.ClassName,
                                    Students = studentGroup
                                };

        // sonuçları yazdırma
        foreach (var group in classWithStudents)
        {
            Console.WriteLine($"Sınıf: {group.ClassName}");

            foreach (var student in group.Students)
            {
                Console.WriteLine($" - Öğrenci: {student.StudentName}");
            }
        }
    }
}