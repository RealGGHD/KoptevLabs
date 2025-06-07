namespace Lab8.Task1;

public class Faculty
{
    //Fields
    public string DeanLastName { get; set; }
    public string Name { get; set; }
    public string DeanPhone { get; set; }
    private List<Student> registeredStudents = new List<Student>();
    /// <summary>
    /// Constructor for this class
    /// </summary>
    public Faculty(string name, string deanLastName, string deanPhone)
    {
        Name = name;
        DeanLastName = deanLastName;
        DeanPhone = deanPhone;
    }
    /// <summary>
    /// Register specific student to specific faculty
    /// </summary>
    public void RegisterStudent(Student student)
    {
        bool isStudentRegistered = registeredStudents.Contains(student);
        if (!isStudentRegistered)
        {
            registeredStudents.Add(student);
        }
    }
    /// <summary>
    /// Change faculty name with update for all students
    /// </summary>
    public void ChangeFacultyName(string newName)
    {
        Name = newName;
        foreach (var student in registeredStudents)
        {
            student.UpdateFacultyName(newName);
        }
    }
    /// <summary>
    /// Bonus to scholarship for excellent student
    /// </summary>
    public void AwardExcellentStudents(decimal bonusAmount)
    {
        foreach (var student in registeredStudents)
        {
            bool isStudentExcellent = student.IsExcellent();
            if (isStudentExcellent)
            {
                student.AddBonus(bonusAmount);
                Console.WriteLine(student.LastName + " excellent student.");
            }
        }
    }
}