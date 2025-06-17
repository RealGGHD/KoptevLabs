namespace Lab9.Task1;

public class StudentEvent
{
    //Private fields
    private List<Student> students = new List<Student>();
    public event Action? DataChanged;
    /// <summary>
    /// Add student to list
    /// </summary>
    public void AddStudent(Student student)
    {
        students.Add(student);
        DataChanged?.Invoke();
    }
    /// <summary>
    /// Remove student from list
    /// </summary>
    public void RemoveStudent(List<Student> students, int index)
    {
        students.Remove(students[index]);
        DataChanged?.Invoke();
    }
    /// <summary>
    /// Add bonus to student
    /// </summary>
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
        var count = students.Count;
        return count;
    }
    /// <summary>
    /// Sort students by last name. Ascending (A to Z) or Descending (Z to A).
    /// </summary>
    public List<Student> GetStudentsSortedByLastName(List<Student> students)
    {
        var sorted = students.OrderBy(s => s.LastName); // A to Z
        var sortedList = sorted.ToList();
        return sortedList;
    }
    /// <summary>
    /// Get total scholarship around all students
    /// </summary>
    public decimal GetTotalScholarship(List<Student> students)
    {
        var total = students.Sum(s => s.Scholarship);
        return total;
    }
    /// <summary>
    /// Get students with average score above than specific
    /// </summary>
    public void GetStudentsWithAverageGradeAbove(List<Student> students, double threshold)
    {
        var sorted = students.Where(s => s.AverageGrade() > threshold);
        students = sorted.ToList();

        var selected = students.Select(s => s.LastName);
        List<string> lastNames = selected.ToList();

        string result = string.Join(", ", lastNames);
        Console.Write($"{result}.\n");
    }
}