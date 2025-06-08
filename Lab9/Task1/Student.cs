namespace Lab9.Task1;

public class Student
{
    //Fields
    public string LastName { get; set; }
    public decimal Scholarship { get; set; }
    public List<int> Grades { get; set; }
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
    /// All grades are 10 for specific student?
    /// </summary>
    public bool IsExcellent()
    {
        return Grades.All(x => x == 10);
    }
    /// <summary>
    /// Average score
    /// </summary>
    public double AverageGrade()
    { 
        return Grades.Count == 0 ? 0 : Grades.Average();
    }
    /// <summary>
    /// Add bonus to scholarship for excellent students
    /// </summary>
    public void AddBonus(decimal bonus)
    {
        Scholarship += bonus;
    }
    
    // LAB 9
    public void Print()
    {
        Console.WriteLine($"Last Name: {LastName}, Average grade: {AverageGrade()}, Scholarship: {Scholarship}.");
    }
}