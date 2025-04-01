namespace Homework;

class Student
{
    //Init private fields
    private string _surname;
    private int _groupNumber;
    private int[] _grades;
    //Get private fields
    public string Surname => _surname;
    public int GroupNumber => _groupNumber;
    public int[] Grades => _grades;
    /// <summary>
    /// Indexer to get grades 
    /// </summary>
    public int this[int index]
    {
        get => _grades[index];
        set => _grades[index] = value;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public Student(string surname, int groupNumber, int[] grades)
    {
        _surname = surname;
        _groupNumber = groupNumber;
        _grades = grades;
    }
}
class StudentAction
{
    //Init private fields
    private List<Student> _students = new List<Student>();
    /// <summary>
    /// Constructor to initialize an empty student collection
    /// </summary>
    public StudentAction()
    {
    }
    /// <summary>
    /// Initialize and insert all students in array
    /// </summary>
    public void ReadStudents()
    {
        //Input number of students
        Console.Write("How many students: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        int count = int.Parse(input);
        //Number of students
        for (int i = 0; i < count; i++)
        {
            //Input surname
            Console.Write("Write surname: ");
            string? surname = Console.ReadLine();
            if (string.IsNullOrEmpty(surname))
            {
                throw new Exception("Error: Invalid surname!");
            }
            //Input group number
            Console.Write("Write group number: ");
            string? groupNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(groupNumber))
            {
                throw new Exception("Error: Invalid group number!");
            }
            int group = int.Parse(groupNumber);
            //Input grades
            Console.Write("Write grades (Like: 1 2 3 4 5): ");
            string? gradesInput = Console.ReadLine();
            if (string.IsNullOrEmpty(gradesInput))
            {
                throw new Exception("Error: Invalid grades!");
            }
            int[] grades = gradesInput.Split(' ').Select(int.Parse).ToArray();
            //Add student to collection
            _students.Add(new Student(surname, group, grades));
        }
    }
    /// <summary>
    /// Print students sorted by surname
    /// </summary>
    public void SortedStudents()
    {
        Console.WriteLine("\nSorted students:");
        var sortedStudents = _students.OrderBy(student => student.Surname);
        foreach (var student in sortedStudents)
        {
            string grades = string.Join(", ", student.Grades);
            Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {grades}");
        }
    }
    /// <summary>
    /// Print number of failing students
    /// </summary>
    public void FailingStudents()
    {
        int count = 0;
        foreach (var student in _students)
        {
            foreach (var grade in student.Grades)
            {
                if (grade == 2)
                {
                    count++;
                    break;
                }
            }
        }
        Console.WriteLine($"\nFailing students: {count}");
    }
    /// <summary>
    /// Excellent students in each group
    /// </summary>
    public void ExcellentByGroups()
    {
        var groups = _students.GroupBy(student => student.GroupNumber); //Sort by groups
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(student => student.Grades.All(grade => grade == 5)).ToList();
            Console.WriteLine($"Excellent in group {group.Key}:");
            if (excellentStudents.Any())
            {
                foreach (var excellentStudent in excellentStudents)
                {
                    Console.WriteLine($"{excellentStudent.Surname} | {excellentStudent.GroupNumber} | {String.Join(", ",excellentStudent.Grades)}");
                }
            }
            else
            {
                Console.WriteLine("No excellent in group.");
            }
        }
    }
}