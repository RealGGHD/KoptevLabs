using Lab8.Task1;

namespace Lab8;

class Tools
{
    //Private fields
    private const string FacultyFile = "faculties";
    private const string StudentsFile = "students";
    private const string ErrorInputMsg = "Error: Invalid input!";
    private const string MenuMsg = "Rename Faculty Name (1) or Award Excellent Student (2)\nWhat would you like to do: ";
    private const string InfoOptionMsg = "Print updated info (1) or skip(2): ";
    private const string InfoMsg = "\nAfter updates:\n";
    private const string FacultyRenameMsg = "Enter faculty name to rename: ";
    private const string FacultyNewMsg = "Enter new faculty name:";
    private const string AwardFacultyMsg = "Enter faculty name to award excellent students: ";
    private const string BonusMsg = "Enter bonus amount: ";
    private const string InfoStudentMsg = "№ | LastName | Average_Score | Scholarship";
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    static void Main()
    {
        var faculties = ReadFaculties(FacultyFile);
        var students = ReadStudents(StudentsFile); 
        
        foreach (var faculty in faculties)
        {
            var sortedStudents = students.Where(s => s.FacultyName == faculty.Name);
            foreach (var student in sortedStudents)
            {
                faculty.RegisterStudent(student);
            }
        }
        
        PrintInfo(faculties, students);
        while (true)
        {
            Menu(faculties, students);
        }
    }
    /// <summary>
    /// Menu to rename faculty or award excellent students
    /// </summary>
    static void Menu(List<Faculty> faculties, List<Student> students)
    {
        string optionStr = Input(MenuMsg);
        int optionInt = Convert.ToInt32(optionStr); 
        if (optionInt == 1)
        {
            RenameFaculty(faculties);
        }
        else if (optionInt == 2)
        {
            AwardStudent(faculties);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
        }
            
        string infoStr = Input(InfoOptionMsg);
        int infoInt = Convert.ToInt32(infoStr);
        if (infoInt == 1)
        {
            Console.WriteLine(InfoMsg);
            PrintInfo(faculties, students);
        }
    }
    /// <summary>
    /// Rename faculty for all students
    /// </summary>
    static void RenameFaculty(List<Faculty> faculties)
    {
        string oldFacultyName = Input(FacultyRenameMsg);
        var facultyToRename = faculties.FirstOrDefault(f => f.Name == oldFacultyName);
        if (facultyToRename != null)
        {
            string newFacultyName = Input(FacultyNewMsg);
            facultyToRename.ChangeFacultyName(newFacultyName);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
        }
    }
    /// <summary>
    /// Award excellent students
    /// </summary>
    static void AwardStudent(List<Faculty> faculties)
    {
        string facultyForAward = Input(AwardFacultyMsg);
        var facultyToAward = faculties.FirstOrDefault(f => f.Name == facultyForAward);
        if (facultyToAward != null)
        {
            string bonusStr = Input(BonusMsg);
            decimal bonusDec = decimal.Parse(bonusStr);
            facultyToAward.AwardExcellentStudents(bonusDec);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
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
            Console.WriteLine($"{faculty.Name} {faculty.DeanLastName} {faculty.DeanPhone}\n{InfoStudentMsg}");
            var sorted = students.Where(s => s.FacultyName == faculty.Name);
            List<Student> studentsInFaculty = sorted.ToList();
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
        string filePath = $"{fileName}.txt";
        return Path.Combine(projectDir, filePath);
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    static string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        bool isNull = string.IsNullOrWhiteSpace(input);
        if (isNull)
        {
            throw new Exception(ErrorInputMsg);
        }
        return input;
    }
}