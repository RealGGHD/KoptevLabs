using Lab9.Task1;

namespace Lab9;

class Tools
{
    static StudentEvent updater = new StudentEvent();
    //Private fields
    private const string FileStudentsName = "students";
    private const string ErrorInputMsg = "Error: Invalid input!";
    private const string MenuLogo = "\nMenu:";
    private const string MenuInfo = "Add student (1), Remove student (2), Add award to student (3)\nWhat would you like to do: ";
    private const string DataChanged = "\nData changed. Stats update:";
    private const string SortedStudent = "\nSorted students by alphabet (from A to Z):";
    private const string NumStudents = "Number of students: ";
    private const string Scholarship = "\nTotal scholarship: : ";
    private const string SortedAverageScore = "\nStudents with average score above 5: ";
    private const double Threshold = 5.0;
    private const string InfoMsg = "№ | LastName | Average_Score | Scholarship";
    private const string AddStdLastName = "Write last name: ";
    private const string AddStdGrades = "Write grade (like 5 4 10): ";
    private const string AddStdScholarship = "Write scholarship: ";
    private const string AskStdNumber = "Write number of student: ";
    private const string AddAwardMsg = "Add award to student: ";
    private const int FirstOption = 1;
    private const int SecondOption = 2;
    private const int ThirdOption = 3;
    private const int MinimalParts = 3;
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    static void Main()
    {
        var students = ReadStudents(FileStudentsName); 
        
        updater.DataChanged += () =>
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DataChanged);
            Console.ResetColor();
            
            int studentsNum = updater.GetStudentCount(students);
            Console.WriteLine(NumStudents + studentsNum);
            
            students = updater.GetStudentsSortedByLastName(students);
            Console.WriteLine(SortedStudent);
            PrintInfo(students);
            
            decimal totalScholarship = updater.GetTotalScholarship(students);
            Console.WriteLine(Scholarship + totalScholarship);
            
            Console.Write(SortedAverageScore);
            updater.GetStudentsWithAverageGradeAbove(students,Threshold);
        };
        
        PrintInfo(students);
        
        while (true)
        {
            Menu(students);
        }
    }
    /// <summary>
    /// Menu for our program
    /// </summary>
    static void Menu(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(MenuLogo);
        Console.ResetColor();
            
        string input = Input(MenuInfo);
        int choose = Convert.ToInt32(input); 
        if (choose == FirstOption)
        {
            AddStudent();
        }
        else if (choose == SecondOption)
        {
            RemoveStudent(students);
        }
        else if (choose == ThirdOption)
        {
            AddAward(students);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
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
            if (parts.Length >= MinimalParts)
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
        Console.WriteLine(InfoMsg);
        foreach (var student in students)
        {
            string LastName = student.LastName;
            double AverageScore = student.AverageGrade();
            decimal Scholarship = student.Scholarship;
            string msg = $"{count} | {LastName} | {AverageScore} | {Scholarship}";
            Console.WriteLine(msg);
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
        string filePath = $"{fileName}.txt";
        return Path.Combine(projectDir, filePath);
    }
    /// <summary>
    /// Add student
    /// </summary>
    static void AddStudent()
    {
        string lastName = Input(AddStdLastName);
        
        string grade = Input(AddStdGrades);
        var grades = grade.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var gradesInt = grades.Select(int.Parse);
        List<int> gradesList = gradesInt.ToList();
        
        string scholarship = Input(AddStdScholarship);
        decimal scholarshipConverted = decimal.Parse(scholarship);
        
        Student newStudent = new Student(lastName, gradesList, scholarshipConverted);
        
        updater.AddStudent(newStudent);
    }
    /// <summary>
    /// Remove specific student
    /// </summary>
    static void RemoveStudent(List<Student> students)
    {
        string str = Input(AskStdNumber);
        int number = Int32.Parse(str);
        int index = number - 1;
        
        updater.RemoveStudent(students[index]);
    }
    /// <summary>
    /// Add award bonus for specific student
    /// </summary>
    static void AddAward(List<Student> students)
    {
        string str = Input(AskStdNumber);
        int number = Int32.Parse(str);
        int index = number - 1;
        
        string award = Input(AddAwardMsg);
        int awardD = Int32.Parse(award);
        
        updater.AddAward(students[index], awardD);
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