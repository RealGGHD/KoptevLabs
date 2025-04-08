namespace Lab1;
class StudentCollection
{
    //SubClass of one Student
    private class Student
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
    ////Init private field
    private List<Student> _students = new List<Student>();
    private const int HighestGrade = 5;
    private const int LowestGrade = 2;
    /// <summary>
    /// Run program
    /// </summary>
    public static void Run()
    {
        //Initialize students collection
        var task = new StudentCollection();
        //Read students data from console
        task.ReadStudents();
        //Sorted students by alphabet
        task.SortedStudents();
        //Amount of failing students
        task.FailingStudents();
        //Excellent students in each group
        task.ExcellentByGroups();
    }
    /// <summary>
    /// Initialize and insert all students in array
    /// </summary>
    private void ReadStudents()
    {
        //Input number of students
        Console.Write("How many students: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) throw new Exception("Error: Invalid input!");
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
            _students.Add(new Student(surname, group, grades));
        }
    }
    /// <summary>
    /// Print students sorted by surname
    /// </summary>
    private void SortedStudents()
    {
        Console.WriteLine("\nSorted students:");
        var sortedStudents = _students.OrderBy(student => student.Surname);
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {string.Join(", ", student.Grades)}");
        }
    }
    /// <summary>
    /// Print number of failing students
    /// </summary>
    private void FailingStudents()
    {
        int count = _students.Count(student => student.Grades.Any(grade => grade == LowestGrade));
        Console.WriteLine($"\nFailing students: {count}");
    }
    /// <summary>
    /// Excellent students in each group
    /// </summary>
    private void ExcellentByGroups()
    {
        var groups = _students.GroupBy(student => student.GroupNumber);
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(student => student.Grades.All(grade => grade == HighestGrade)).ToList();
            Console.WriteLine($"Excellent in group {group.Key}:");
            if (excellentStudents.Count == 0)
            {
                Console.WriteLine("No excellent in group.");
            }
            else
            {
                foreach (var student in excellentStudents)
                {
                    Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {string.Join(", ", student.Grades)}");
                }
            }
        }
    }
}