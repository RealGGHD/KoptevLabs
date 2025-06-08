using Lab9.Task1;

namespace Lab9;

class Tools
{
    static StudentEvent updater = new StudentEvent();
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    static void Main()
    {
        var students = ReadStudents("students.txt"); 
        
        updater.DataChanged += () =>
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nData changed. Stats update:");
            Console.ResetColor();
            
            int studentsNum = updater.GetStudentCount(students);
            Console.WriteLine($"Number of students: {studentsNum}.");
            
            students = updater.GetStudentsSortedByLastName(students);
            Console.WriteLine($"\nSorted students by alphabet (from A to Z):");
            PrintInfo(students);
            
            decimal totalScholarship = updater.GetTotalScholarship(students);
            Console.WriteLine($"\nTotal scholarship: {totalScholarship}.");
            
            Console.WriteLine($"\nStudents with average score above 5: ");
            updater.GetStudentsWithAverageGradeAbove(students,5.0);
        };
        
        PrintInfo(students);
        
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nMenu");
            Console.ResetColor();
            
            Console.WriteLine("Add student (1), Remove student (2), Add award to student (3)");
            Console.Write("What would you like to do: ");
            string input = Console.ReadLine();
            int choose = Convert.ToInt32(input); 
            if (choose == 1)
            {
                AddStudent(students);
            }
            else if (choose == 2)
            {
                RemoveStudent(students);
            }
            else if (choose == 3)
            {
                AddAward(students);
            }
            else
            {
                Console.WriteLine("Invalid input");
                break;
            }
        }
    }
    /// <summary>
    /// Read students from txt file
    /// </summary>
    static List<Student> ReadStudents(string filename)
    {
        var students = new List<Student>();
        string path = GetPath(filename);
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length >= 3)
            {
                string lastName = parts[0].Trim();
                var grades = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var gradesInt = grades.Select(int.Parse);
                List<int> gradesList = gradesInt.ToList();
                decimal scholarship = decimal.Parse(parts[2].Trim());
                students.Add(new Student(lastName, gradesList, scholarship));
            }
        }
        return students;
    }
    /// <summary>
    /// Print information about students
    /// </summary>
    static void PrintInfo(List<Student> students)
    {
        int count = 1;
        Console.WriteLine("№ | LastName | Average_Score | Scholarship");
        foreach (var student in students)
        {
            string LastName = student.LastName;
            double AverageScore = student.AverageGrade();
            decimal Scholarship = student.Scholarship;
            Console.WriteLine($"{count} | {LastName} | {AverageScore} | {Scholarship}");
            count++;
        }
    }
    /// <summary>
    /// Get path of input file located relative to Tools.cs directory
    /// </summary>
    static string GetPath(string fileName)
    {
        string basePath = AppContext.BaseDirectory;
        string projectDir = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
        return Path.Combine(projectDir, fileName);
    }

    public static void AddStudent(List<Student> students)
    {
        Console.Write("Write last name: ");
        string lastName = Console.ReadLine();
        
        Console.WriteLine("Write grade (like 5 4 10): ");
        string grade = Console.ReadLine();
        List<int> gradesList = grade.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        
        Console.WriteLine("Write scholarship: ");
        string scholarship = Console.ReadLine();
        decimal scholarshipConverted = decimal.Parse(scholarship);
        
        Student newStudent = new Student(lastName, gradesList, scholarshipConverted);
        
        updater.AddStudent(newStudent);
    }
    static void RemoveStudent(List<Student> students)
    {
        Console.Write("Write number of student: ");
        string str = Console.ReadLine();
        int number = Int32.Parse(str);

        updater.RemoveStudent(students[--number]);
    }

    static void AddAward(List<Student> students)
    {
        Console.Write("Write number of student: ");
        string str = Console.ReadLine();
        int number = Int32.Parse(str);
        
        Console.Write("Add award to student: ");
        string award = Console.ReadLine();
        int awardD = Int32.Parse(award);
        
        updater.AddAward(students[--number], awardD);
    }
}