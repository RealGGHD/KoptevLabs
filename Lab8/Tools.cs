using Lab8.Task1;

namespace Lab8;

class Tools
{
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    static void Main()
    {
        var faculties = ReadFaculties("faculties.txt");
        var students = ReadStudents("students.txt"); 
        foreach (var faculty in faculties) 
        {
            foreach (var student in students.Where(s => s.FacultyName == faculty.Name))
            {
                faculty.RegisterStudent(student);
            }
        }
        PrintInfo(faculties, students);
        while (true)
        {
            Console.WriteLine("Rename Faculty Name (1) or Award Excellent Student (2)");
            Console.Write("What would you like to do: ");
            string input = Console.ReadLine();
            int choose = Convert.ToInt32(input); 
            if (choose == 1)
            {
                RenameFaculty(faculties);
            }
            else if (choose == 2)
            {
                AwardStudent(faculties);
            }
            else
            {
                Console.WriteLine("Invalid input");
                break;
            }
            Console.WriteLine("\nAfter updates:\n");
            PrintInfo(faculties, students);
        }
    }
    /// <summary>
    /// Rename faculty for all students
    /// </summary>
    static void RenameFaculty(List<Faculty> faculties)
    {
        Console.WriteLine("Enter faculty name to rename:");
        string oldFacultyName = Console.ReadLine();
        var facultyToRename = faculties.FirstOrDefault(f => f.Name == oldFacultyName);
        if (facultyToRename != null)
        {
            Console.WriteLine("Enter new faculty name:");
            string newFacultyName = Console.ReadLine();
            facultyToRename.ChangeFacultyName(newFacultyName);
        }
        else
        {
            throw new Exception("Invalid faculty name");
        }
    }
    /// <summary>
    /// Award excellent students
    /// </summary>
    static void AwardStudent(List<Faculty> faculties)
    {
        Console.WriteLine("Enter faculty name to award excellent students:");
        string facultyForAward = Console.ReadLine();
        var facultyToAward = faculties.FirstOrDefault(f => f.Name == facultyForAward);
        if (facultyToAward != null)
        {
            Console.WriteLine("Enter bonus amount:");
            decimal bonus = decimal.Parse(Console.ReadLine());
            facultyToAward.AwardExcellentStudents(bonus);
        }
        else
        {
            throw new Exception("Invalid faculty name");
        }
    }
    /// <summary>
    /// Read faculties from txt file
    /// </summary>
    static List<Faculty> ReadFaculties(string filename)
    {
        var faculties = new List<Faculty>();
        string path = GetPath(filename);
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length >= 3)
            {
                string name = parts[0].Trim();
                string deanLastName = parts[1].Trim();
                string deanPhone = parts[2].Trim();
                Faculty newFaculty = new Faculty(name, deanLastName, deanPhone);
                faculties.Add(newFaculty);
            }
        }
        return faculties;
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
            if (parts.Length >= 4)
            {
                string lastName = parts[0].Trim();
                string facultyName = parts[1].Trim();
                var grades = parts[2].Split(' ');
                var gradesInt = grades.Select(int.Parse);
                List<int> gradesList = gradesInt.ToList();
                decimal scholarship = decimal.Parse(parts[3].Trim());
                students.Add(new Student(lastName, facultyName, gradesList, scholarship));
            }
        }
        return students;
    }
    /// <summary>
    /// Print information about students
    /// </summary>
    static void PrintInfo(List<Faculty> faculties, List<Student> students)
    {
        foreach (var faculty in faculties)
        {
            Console.WriteLine($"{faculty.Name} {faculty.DeanLastName} {faculty.DeanPhone}");
            Console.WriteLine("№ | LastName | Average_Score | Scholarship");
            var studentsInFaculty = students.Where(s => s.FacultyName == faculty.Name).ToList();
            int count = 1;
            foreach (var student in studentsInFaculty)
            {
                string LastName = student.LastName;
                double AverageScore = student.AverageGrade();
                decimal Scholarship = student.Scholarship;
                Console.WriteLine($"{count} | {LastName} | {AverageScore} | {Scholarship}");
                count++;
            }
            Console.WriteLine();
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
}