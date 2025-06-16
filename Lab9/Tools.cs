using Lab9.Task1;
namespace Lab9;

class Tools
{
    //Private fields
    private const string FileStudentsName = "students";
    private const string DataChanged = "\nData changed. Stats update:";
    private const string SortedStudent = "\nSorted students by alphabet (from A to Z):";
    private const string NumStudents = "Number of students: ";
    private const string Scholarship = "\nTotal scholarship: : ";
    private const string SortedAverageScore = "\nStudents with average score above 5: ";
    private const double Threshold = 5.0;
    private const string InfoMsg = "№ | LastName | Average_Score | Scholarship";
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    static void Main()
    {
        FileAction file = new FileAction();
        StudentEvent updater = new StudentEvent();
        MenuAction menu = new MenuAction(updater);
        
        var students = file.ReadStudents(FileStudentsName); 
        
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
            menu.Print(students);
        }
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
            string lastName = student.LastName;
            double averageScore = student.AverageGrade();
            decimal scholarship = student.Scholarship;
            string msg = $"{count} | {lastName} | {averageScore} | {scholarship}";
            Console.WriteLine(msg);
            count++;
        }
    }
}