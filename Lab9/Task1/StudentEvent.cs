namespace Lab9.Task1;

public class StudentEvent
{
    private List<Student> students = new List<Student>();

    public event Action? DataChanged;

    public void AddStudent(Student student)
    {
        students.Add(student);
        DataChanged?.Invoke();
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
        DataChanged?.Invoke();
    }
    
    public void AddAward(Student student, int bonus)
    {
        student.AddBonus(bonus);
        DataChanged?.Invoke();
    }

    /// <summary>
    /// Number of students from files
    /// </summary>
    public int GetStudentCount(List<Student> students)
    {
        return students.Count;
    }
    /// <summary>
    /// Sort students by last name. Ascending (A to Z) or Descending (Z to A).
    /// </summary>
    public List<Student> GetStudentsSortedByLastName(List<Student> students)
    {
        students = students.OrderBy(s => s.LastName).ToList(); // A to Z
        return students;
    }
    /// <summary>
    /// Get total scholarship around all students
    /// </summary>
    public decimal GetTotalScholarship(List<Student> students)
    {
        return students.Sum(s => s.Scholarship);
    }
    /// <summary>
    /// Get students with average score above than specific
    /// </summary>
    public void GetStudentsWithAverageGradeAbove(List<Student> students, double threshold)
    {
        students = students.Where(s => s.AverageGrade() > threshold).ToList();

        List<string> lastNames = students.Select(s => s.LastName).ToList();

        string result = string.Join(", ", lastNames);
        Console.WriteLine($"{result}.");
    }
}