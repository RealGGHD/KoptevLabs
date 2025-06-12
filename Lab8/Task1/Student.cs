namespace Lab8.Task1;

public class Student
{
    //Fields
    public string LastName { get; set; }
    public string FacultyName { get; set; }
    public decimal Scholarship { get; set; }
    public List<int> Grades { get; set; }

    private const int MaxGrade = 10;
    private const int NoGrades = 0;
    /// <summary>
    /// Constructor for this class
    /// </summary>
    public Student(string lastName, string facultyName, List<int> grades, decimal scholarship)
    {
        LastName = lastName;
        FacultyName = facultyName;
        Grades = grades;
        Scholarship = scholarship;
    }
    /// <summary>
    /// All grades are 10 for specific student?
    /// </summary>
    public bool IsExcellent()
    {
        return Grades.All(x => x == MaxGrade);
    }
    /// <summary>
    /// Average score
    /// </summary>
    public double AverageGrade()
    {
        if (Grades.Count == NoGrades)
        {
            return 0;
        }
        else
        {
            return Grades.Average();
        }
    }
    /// <summary>
    /// Update of name for faculty 
    /// </summary>
    public void UpdateFacultyName(string newFacultyName)
    {
        FacultyName = newFacultyName;
    }
    /// <summary>
    /// Add bonus to scholarship for excellent students
    /// </summary>
    public void AddBonus(decimal bonus)
    {
        Scholarship += bonus;
    }
}