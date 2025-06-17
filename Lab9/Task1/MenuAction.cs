namespace Lab9.Task1;

public class MenuAction
{
    //Private fields
    private const string ErrorInputMsg = "Error: Invalid input!";
    private const string MenuLogo = "\nMenu:";
    private const string MenuInfo = "Add student (1), Remove student (2), Add award to student (3)\nWhat would you like to do: ";
    private const string AddStdLastName = "Write last name: ";
    private const string AddStdGrades = "Write grade (like 5 4 10): ";
    private const string AddStdScholarship = "Write scholarship: ";
    private const string AskStdNumber = "Write number of student: ";
    private const string AddAwardMsg = "Add award to student: ";
    private const int FirstOption = 1;
    private const int SecondOption = 2;
    private const int ThirdOption = 3;
    private StudentEvent _updater;
    /// <summary>
    /// Constructor
    /// </summary>
    public MenuAction(StudentEvent updater)
    {
        _updater = updater;
    }
    /// <summary>
    /// Menu for our program
    /// </summary>
    public void Print(List<Student> students)
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
    /// Add student
    /// </summary>
    void AddStudent()
    {
        string lastName = Input(AddStdLastName);
        
        string grade = Input(AddStdGrades);
        var grades = grade.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var gradesInt = grades.Select(int.Parse);
        List<int> gradesList = gradesInt.ToList();
        
        string scholarship = Input(AddStdScholarship);
        decimal scholarshipConverted = decimal.Parse(scholarship);
        
        Student newStudent = new Student(lastName, gradesList, scholarshipConverted);
        
        _updater.AddStudent(newStudent);
    }
    /// <summary>
    /// Remove specific student
    /// </summary>
    void RemoveStudent(List<Student> students)
    {
        string str = Input(AskStdNumber);
        int number = Int32.Parse(str);
        int index = number - 1;
        _updater.RemoveStudent(students, index); 
    }
    /// <summary>
    /// Add award bonus for specific student
    /// </summary>
    void AddAward(List<Student> students)
    {
        string str = Input(AskStdNumber);
        int number = Int32.Parse(str);
        int index = number - 1;
        
        string award = Input(AddAwardMsg);
        int awardD = Int32.Parse(award);
        
        _updater.AddAward(students[index], awardD);
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    string Input(string message)
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