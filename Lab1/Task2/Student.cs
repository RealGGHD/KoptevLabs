using System.Runtime.InteropServices.JavaScript;

namespace Task2;

class Student
{
    private string _surname;
    private int _groupNumber;
    private int[] _grades;

    public Student(string surname, int groupNumber, int[] grades)
    {
        _surname = surname;
        _groupNumber = groupNumber;
        _grades = grades;
    }
    
    public string Surname
    {
        get { return _surname; }
        //set { _surname = value; }
    }

    public int GroupNumber
    {
        get { return _groupNumber; }
        //set { _groupNumber = value; }
    }

    public int[] Grades
    {
        get { return _grades; }
        //set { _grades = value; }
    }
    
    public bool IsFailing()
    {
        return _grades.Any(grade => grade == 2); // If one us 2
    }
    public bool IsExcellent()
    {
        return _grades.All(grade => grade >= 4); // All grades are above 4
    }
    
    public int this[int index]
    {
        get => _grades[index];
        //set => _grades[index] = value;
    }
}

public class Run
{
    static Student[] sortedStudents(Student[] students)
    {
        return students.OrderBy(s => s.Surname).ToArray();
    }

    static int failingCount(Student[] students)
    {
        return students.Count(s => s.IsFailing());
    }

    static void excellentByGroups(Student[] students)
    {
        var groups = students.GroupBy(s => s.GroupNumber);
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(s => s.IsExcellent()).ToList();
            Console.WriteLine($"Отличники в группе {group.Key}:");
            if (excellentStudents.Any())
            {
                foreach (var excellentStudent in excellentStudents)
                {
                    Console.WriteLine($"{excellentStudent.Surname} | {excellentStudent.GroupNumber} | {String.Join(", ",excellentStudent.Grades)}");
                }
            }
            else
            {
                Console.WriteLine("Нет отличников в этой группе.");
            }
        }
    }

    static Student[] chooseGroup(Student[] students)
    {
        Console.Write("Choose a group of students: ");
        int group = Convert.ToInt32(Console.ReadLine());
        List<Student> tempStudents =  new List<Student>();
        foreach (var temp in students)
        {
            if (temp.GroupNumber == group)
            {
                tempStudents.Add(temp);
            }
        }
        return tempStudents.ToArray();
    }

    static void excellentByGroups2(Student[] students)
    {
        var groups = students.GroupBy(s => s.GroupNumber);
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(s => s.IsExcellent()).ToList();
            Console.WriteLine($"Отличников в группе {group.Key}: {excellentStudents.Count}");
        }
    }

    static void allFailing(Student[] students)
    {
        foreach (var student in students)
        {
            if (student.IsFailing() == true)
            {
                Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {String.Join(", ",student.Grades)}");
            }
        }
    }
    
    static void Main(string[] args)
    {
        Student st = new Student("Michael", 1, new int[]{5,4,3});
        Student st2 = new Student("Abobavich", 2, new int[]{2,5,5});
        Student st3 = new Student("Haboba", 1, new int[]{5,5,5});
        Student[] students = new Student[] { st, st2, st3 };
        
        Console.Write("Choose variant (1/2): ");
        string variant = Console.ReadLine();
        if (variant == "1")
        {
            //SortedStudents
            foreach (var temp in sortedStudents(students))
            {
                Console.WriteLine($"{temp.Surname} | {temp.GroupNumber} | {String.Join(", ",temp.Grades)}");
            }
            //FailingCount
            Console.WriteLine(failingCount(students));
            //BestStudentsByGroups
            excellentByGroups(students);
        }
        else
        {
            //Add code for 2 variant
            Student[] selectedStudentsGroup = chooseGroup(students);
            //SortedStudents
            foreach (var temp in sortedStudents(selectedStudentsGroup))
            {
                Console.WriteLine($"{temp.Surname} | {temp.GroupNumber} | {String.Join(", ",temp.Grades)}");
            }
            //ExcellentCountByGroup
            excellentByGroups2(students);
            //AllFailing
            allFailing(students);
        }
    }
}