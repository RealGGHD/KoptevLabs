using Lab8.Task1;
namespace Lab8;

class Tools
{
    //Private fields
    private const string FacultyFile = "faculties";
    private const string StudentsFile = "students";
    private const string InfoStudentMsg = "№ | LastName | Average_Score | Scholarship";
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    static void Main()
    {
        FileAction file = new FileAction();
        MenuAction menu = new MenuAction();
        
        var faculties = file.ReadFaculties(FacultyFile);
        var students = file.ReadStudents(StudentsFile); 
        
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
            menu.Print(faculties, students);
            PrintInfo(faculties, students);
        }
    }
    /// <summary>
    /// Print information about students
    /// </summary>
    static void PrintInfo(List<Faculty> faculties, List<Student> students)
    {
        Console.Write("\n");
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
}