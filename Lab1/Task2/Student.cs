//1 variant
namespace Lab1.Task2;
public class Student
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