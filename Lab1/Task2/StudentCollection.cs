//1 variant
namespace Lab1.Task2;
class StudentCollection
{
    ////Init private field
    private List<Student> _students = new List<Student>();
    private const int HighestGrade = 5;
    private const int LowestGrade = 2;
    /// <summary>
    /// Initialize and insert all students in array
    /// </summary>
    public void ReadStudents()
    {
        //Input number of students
        int count = int.Parse(Tools.Input("How many students: "));
        //Number of students
        for (int i = 0; i < count; i++)
        {
            //Input surname
            string surname = Tools.Input("Write surname: ");
            //Input group number
            int group = int.Parse(Tools.Input("Write group number: "));
            //Input grades
            string gradesInput = Tools.Input("Write grades (Like: 1 2 3 4 5): ");
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
            Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {string.Join(", ", student.Grades)}");
        }
    }
    /// <summary>
    /// Print number of failing students
    /// </summary>
    public void FailingStudents()
    {
        int count = _students.Count(student => student.Grades.Any(grade => grade == LowestGrade));
        Console.WriteLine($"\nFailing students: {count}");
    }
    /// <summary>
    /// Excellent students in each group
    /// </summary>
    public void ExcellentByGroups()
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