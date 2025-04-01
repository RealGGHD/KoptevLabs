//1 variant
namespace Homework;
class Program
{
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        while (true)
        {
            Console.Write("Choose task (1/2): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("Error: Invalid input!");
            }

            int task = int.Parse(input);
            if (task == 1)
            {
                TaskOne();
            }
            else if (task == 2)
            {
                TaskTwo();
            }
        }
    }
    /// <summary>
    /// Start Task1
    /// </summary>
    static void TaskOne()
    {
        //Init MyObject
        Array myObject = new Array();
        //Init A, B and C
        myObject.A = myObject.GroupList(myObject.ArrayA);
        myObject.B = myObject.GroupList(myObject.ArrayB) * 2.0;
        myObject.C = myObject.GroupList(myObject.ArrayC) / 2.0;
        //Calculate function
        double result = myObject.Calculate(myObject.A, myObject.B, myObject.C);
        //Print Result
        Console.WriteLine($"Result: {result}");
    }
    /// <summary>
    /// Start Task2
    /// </summary>
    static void TaskTwo()
    {
        //Initialize students collection
        var students = new StudentCollection();
        //Read students data from console
        students.ReadStudents();
        //Sorted students by alphabet
        students.SortedStudents();
        //Amount of failing students
        students.FailingStudents();
        //Excellent students in each group
        students.ExcellentByGroups(); 
    }
}

class Array
{
    //Init private fields
    private double[] _arrayA;
    private double[] _arrayB;
    private double[] _arrayC;
    private double _a;
    private double _b;
    private double _c;
    //Get private double[] fields
    public double[] ArrayA => _arrayA;
    public double[] ArrayB => _arrayB;
    public double[] ArrayC => _arrayC;
    //Get and set private double fields
    public double A
    {
        get { return _a; }
        set { _a = value; }
    }
    public double B
    {
        get { return _b; }
        set { _b = value; }
    }
    public double C
    {
        get { return _c; } 
        set { _c = value; }
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public Array()
    {
        _arrayA = InitArray("A");
        _arrayB = InitArray("B");
        _arrayC = InitArrayC(_arrayA, _arrayB);
    }
    /// <summary>
    /// Initialize Array A or B
    /// </summary>
    double[] InitArray(string name)
    {
        Console.Write($"Write array {name} (Like: 10.2 3 52): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        string[] values = input.Split(' ');
        double[] array = System.Array.ConvertAll(values, double.Parse);
        return array;
    }
    /// <summary>
    /// Initialize Array C
    /// </summary>
    double[] InitArrayC(double[] arrayA, double[] arrayB)
    {
        List<double> listB = arrayB.ToList();
        int minBIndex = System.Array.IndexOf(arrayB, arrayB.Min()); //Left minimum index of B
        listB.RemoveRange(0, minBIndex + 1); //Prepared B, +1 because remove everything right from min include it 
        
        Console.Write("Write index for array C: ");
        string? input = Console.ReadLine(); //InputIndex
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        int inputIndex = int.Parse(input);
        
        List<double> listA = arrayA.ToList();
        int minAIndex = System.Array.LastIndexOf(arrayA, arrayA.Min()); //Right minimum index of A
        if (inputIndex > minAIndex)
        {
            listA = listA.GetRange(minAIndex + 1, inputIndex - 1); //Range from Min to Input 
        } else if (inputIndex < minAIndex)
        {
            listA = listA.GetRange(inputIndex + 1, minAIndex - 1); //Range from Input to Min
        }
        else
        {
            return listB.ToArray(); //Return range without A
        }
        return listB.Concat(listA).ToArray(); //Return range with B + A
    }
    /// <summary>
    /// The sum of positive elements after the second maximum
    /// </summary>
    public double GroupList(double[] array)
    {
        List<double> temp = array.ToList();
        double fMax = temp.Max(); //First Max
        temp.Remove(fMax);
        double sMax = temp.Max(); //Second Max
        int sMaxIndex = temp.IndexOf(sMax); //Second Max Index
        
        List<double> list = array.ToList();
        list.RemoveRange(0, sMaxIndex + 1); //Delete all left from second max
        List<double> sumList = new List<double>();
        foreach (double element in list)
        {
            if (element > 0) //Sum of all positive
            {
                sumList.Add(element);
            }
        }
        return sumList.Sum();
    }
    /// <summary>
    /// Calculate function
    /// </summary>
    public double Calculate(double a, double b, double c)
    {
        return (2.0 * Math.Sin(a)) + (3.0 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
    }
}

class Student
{
    //Init private fields
    private string _surname;
    private int _groupNumber;
    private int[] _grades;
    //Get private fields
    public string Surname => _surname;
    public int GroupNumber => _groupNumber;
    public int[] Grades => _grades;
    //Get and set for grades.
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
    /// <summary>
    /// Is student failing? Any one grade is 2.
    /// </summary>
    public bool IsFailing() => _grades.Any(grade => grade == 2);
    /// <summary>
    /// Is student excellent? All grades are 5.
    /// </summary>
    public bool IsExcellent() => _grades.All(grade => grade == 5);
}

class StudentCollection
{
    //Init private fields
    private List<Student> _students = new List<Student>();
    /// <summary>
    /// Constructor to initialize an empty student collection
    /// </summary>
    public StudentCollection()
    {
    }
    /// <summary>
    /// Initialize and insert all students in array
    /// </summary>
    public void ReadStudents()
    {
        //Create collection
        var collection = new StudentCollection();
        //Input number of students
        Console.Write("How many students: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        int count = int.Parse(input);
        //Number of students
        for (int i = 0; i < count; i++)
        {
            //Input surname
            Console.Write("Write surname: ");
            string? surname = Console.ReadLine();
            if (string.IsNullOrEmpty(surname)) throw new Exception("Error: Invalid surname!");
            //Input group number
            Console.Write("Write group number: ");
            string? groupNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(groupNumber)) throw new Exception("Error: Invalid group number!");
            int group = int.Parse(groupNumber);
            //Input grades
            Console.Write("Write grades (Like: 1 2 3 4 5): ");
            string? gradesInput = Console.ReadLine(); 
            if (string.IsNullOrEmpty(gradesInput)) throw new Exception("Error: Invalid grades!");
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
        foreach (var student in _students.OrderBy(s => s.Surname))
        {
            Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {string.Join(", ", student.Grades)}");
        }
    }
    /// <summary>
    /// Print number of failing students
    /// </summary>
    public void FailingStudents()
    {
        int count = _students.Count(std => std.IsFailing());
        Console.WriteLine($"\nFailing students: {count}");
    }
    /// <summary>
    /// Excellent students in each group
    /// </summary>
    public void ExcellentByGroups()
    {
        var groups = _students.GroupBy(s => s.GroupNumber);
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(s => s.IsExcellent()).ToList();
            Console.WriteLine($"Excellent in group {group.Key}:");
            if (excellentStudents.Any())
            {
                foreach (var excellentStudent in excellentStudents)
                {
                    Console.WriteLine($"{excellentStudent.Surname} | {excellentStudent.GroupNumber} | {String.Join(", ",excellentStudent.Grades)}");
                }
            }
            else
            {
                Console.WriteLine("No excellent in group.");
            }
        }
    }
}