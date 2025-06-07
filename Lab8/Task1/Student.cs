namespace Lab8.Task1;

public class Student
{
    //Fields
    public string LastName { get; set; }
    public string FacultyName { get; set; }
    public int Scholarship { get; set; }
    public int[] Grades { get; set; }

    bool isStudentExcellent()
    {
        return Grades.All(x => x == 10);
    }
    
    //events
}