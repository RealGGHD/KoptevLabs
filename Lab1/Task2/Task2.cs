namespace Task2;

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
    //Get and set for grades.
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
    /// <summary>
    /// Is student failing? Any one grade is 2.
    /// </summary>
    public bool IsFailing() => _grades.Any(grade => grade == 2);
    /// <summary>
    /// Is student excellent? All grades are 5.
    /// </summary>
    public bool IsExcellent() => _grades.All(grade => grade == 5);
}

class StudentCollection
{
    //Init private fields
    private List<Student> _students = new List<Student>();
    /// <summary>
    /// Add student to collection
    /// </summary>
    public void AddStudent(Student student) => _students.Add(student);
    /// <summary>
    /// Is student failing? Any one grade is 2.
    /// </summary>
    public IEnumerable<Student> Students => _students;
    /// <summary>
    /// Initialize and insert all students in array
    /// </summary>
    public static StudentCollection CreateFromConsoleInput()
    {
        //Create collection
        var collection = new StudentCollection();
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
            if (string.IsNullOrEmpty(surname)) throw new Exception("Error: Invalid surname!");
            //Input group number
            Console.Write("Write group number: ");
            string? groupNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(groupNumber)) throw new Exception("Error: Invalid group number!");
            int group = int.Parse(groupNumber);
            //Input grades
            Console.Write("Write grades (Like: 1 2 3 4 5): ");
            string? gradesInput = Console.ReadLine(); 
            if (string.IsNullOrEmpty(gradesInput)) throw new Exception("Error: Invalid grades!");
            int[] grades = gradesInput.Split(' ').Select(int.Parse).ToArray();
            //Add student to collection
            collection.AddStudent(new Student(surname, group, grades));
        }
        //Return collection
        return collection;
    }
    /// <summary>
    /// Print students sorted by surname
    /// </summary>
    public void SortedStudents()
    {
        Console.WriteLine("\nSorted students:");
        foreach (var student in _students.OrderBy(s => s.Surname))
        {
            Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {string.Join(", ", student.Grades)}");
        }
    }
    /// <summary>
    /// Print number of failing students
    /// </summary>
    public void FailingStudents()
    {
        int count = _students.Count(std => std.IsFailing());
        Console.WriteLine($"\nFailing students: {count}");
    }
    /// <summary>
    /// Excellent students in each group
    /// </summary>
    public void ExcellentByGroups()
    {
        var groups = _students.GroupBy(s => s.GroupNumber);
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(s => s.IsExcellent()).ToList();
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

class Task2
{
    static void Main()
    {
        //Initialize of students
        var students = StudentCollection.CreateFromConsoleInput();
        //SortedStudents by Alphabet
        students.SortedStudents();
        //Amount of failing students
        students.FailingStudents();
        ////Excellent students in each group
        students.ExcellentByGroups(); 
    }
}