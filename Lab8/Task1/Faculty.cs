namespace Lab8.Task1;
delegate void FacultyNameChangedHandler(string newFacultyName);
delegate void ScholarshipBonusHandler(decimal bonusAmount);
public class Faculty
{
    //Fields
    public string DeanLastName { get; set; }
    public string Name { get; set; }
    public string DeanPhone { get; set; }
    private List<Student> registeredStudents = new List<Student>();
    private FacultyNameChangedHandler NameChanged;
    private ScholarshipBonusHandler ScholarshipBonusAnnounced;
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
            NameChanged += student.OnFacultyNameChanged; //Subscribe to delegate
            ScholarshipBonusAnnounced += student.OnScholarshipBonus; //Subscribe to delegate
        }
    }
    /// <summary>
    /// Change faculty name with update for all students
    /// </summary>
    public void ChangeFacultyName(string newName)
    {
        bool isNull = string.IsNullOrWhiteSpace(newName);
        bool sameName = newName == Name;
        if (isNull || sameName)
        {
            return;
        }
        Name = newName;
        NameChanged?.Invoke(newName);
    }
    /// <summary>
    /// Bonus to scholarship for excellent student
    /// </summary>
    public void AwardExcellentStudents(decimal bonusAmount)
    {
        if (bonusAmount <= 0)
        {
            return;
        }
        ScholarshipBonusAnnounced?.Invoke(bonusAmount);
    }
}