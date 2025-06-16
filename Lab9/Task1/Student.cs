namespace Lab9.Task1;

public class Student
{
    //Private Fields
    public string LastName { get; set; }
    public decimal Scholarship { get; set; }
    public List<int> Grades { get; set; }
    private const int NoGrades = 0;
    /// <summary>
    /// Constructor for this class
    /// </summary>
    public Student(string lastName, List<int> grades, decimal scholarship)
    {
        LastName = lastName;
        Grades = grades;
        Scholarship = scholarship;
    }
    /// <summary>
    /// Average score
    /// </summary>
    public double AverageGrade()
    { 
        int NumberOfGrades = Grades.Count;
        if (NumberOfGrades == NoGrades)
        {
            return 0;
        }
        else
        {
            double averageGrades = Grades.Average();
            return averageGrades;
        }
    }
    /// <summary>
    /// Add bonus to scholarship for excellent students
    /// </summary>
    public void AddBonus(decimal bonus)
    {
        Scholarship += bonus;
    }
    /// <summary>
    /// Print information about that student
    /// </summary>
    public void Print()
    {
        double averageGrade = AverageGrade();
        Console.WriteLine($"Last Name: {LastName}, Average grade: {averageGrade}, Scholarship: {Scholarship}.");
    }
}