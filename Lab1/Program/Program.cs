namespace Program;

class Program
{
    static void Main()
    {
        Console.Write("Choose exercise (1/2): ");
        string variant = Console.ReadLine();
        if (variant == "1")
        {
            EX1();
        }
        else if (variant == "2")
        {
            EX2();
        }
        else
        {
            throw new Exception("Error: Invalid exercise!");
        }
    }

    static void EX1()
    {
        Console.Write("Choose variant (1/2): ");
        string variant = Console.ReadLine();
        
        Console.Write("Write array A (Like: 10.2 3 52): ");
        string arrayA = Console.ReadLine();
        Console.Write("Write array B (Like: 73 5 93.1): ");
        string arrayB = Console.ReadLine();
        Array myObject = new Array(arrayA, arrayB);
        
        if (variant == "1")
        {
            myObject.A = myObject.GroupList1(myObject.ArrayA);
            myObject.B = myObject.GroupList1(myObject.ArrayB) * 2.0;
            myObject.C = myObject.GroupList1(myObject.ArrayC) / 2.0;
        }
        else if (variant == "2")
        {
            myObject.A = myObject.GroupList2(myObject.ArrayA);
            myObject.B = myObject.GroupList2(myObject.ArrayB) * 2.0;
            myObject.C = myObject.GroupList2(myObject.ArrayC) / 2.0;
        }
        else
        {
            throw new Exception("Error: Invalid variant!");
        }
        double result = myObject.Calculate(myObject.A, myObject.B, myObject.C);
        Console.WriteLine($"Result: {result}");
    }
    
    static void EX2()
    {
        Console.Write("How many students?");
        string amountStudents = Console.ReadLine();
        int amountStudentsInt = int.Parse(amountStudents);
        Student[] myStudents = Student.InsertStudents(amountStudentsInt);
        
        Console.Write("Choose variant (1/2): ");
        string variant = Console.ReadLine();
        if (variant == "1")
        {
            Student.sortedStudents(myStudents); //SortedStudents
            
            Console.WriteLine(Student.failingCount(myStudents)); //FailingCount
            
            Student.excellentByGroups1(myStudents); //BestStudentsByGroups
        }
        else if (variant == "2")
        {
            Student[] selectedStudentsGroup = Student.chooseGroup(myStudents); //Select group
            
            Student.sortedStudents(selectedStudentsGroup); //SortedStudents in selected Group
            
            Student.excellentByGroups2(myStudents); //ExcellentCountByGroup
            
            Student.allFailing(myStudents); //AllFailing
        }
        else
        {
            throw new Exception("Error: Invalid variant!");
        }
    }
}

class Array
{
    private double[] _arrayA;
    private double[] _arrayB;
    private double[] _arrayC;
    private double _a;
    private double _b;
    private double _c;
    
    public double[] ArrayA => _arrayA;
    public double[] ArrayB => _arrayB;
    public double[] ArrayC => _arrayC;

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
    
    public Array(string valuesA, string valuesB)
    {
        string[] arrayAStrings = valuesA.Split(' ');
        string[] arrayBStrings = valuesB.Split(' ');
        _arrayA = System.Array.ConvertAll(arrayAStrings, double.Parse);
        _arrayB = System.Array.ConvertAll(arrayBStrings, double.Parse);
        _arrayC = InitArrayC(_arrayA, _arrayB);
    }
    
    double[] InitArrayC(double[] arrayA, double[] arrayB)
    {
        List<double> listB = arrayA.ToList();
        int minBIndex = System.Array.IndexOf(arrayB, arrayB.Min()); //Left minimum index of B
        listB.RemoveRange(0, minBIndex + 1);
        
        Console.Write("Write index for array C: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int index)) //Input index for C
        {
            throw new Exception("Error: Invalid index!");
        }
        
        List<double> listA = arrayA.ToList();
        int minAIndex = System.Array.LastIndexOf(arrayA, arrayA.Min()); //Right minimum index of A
        if (index > minAIndex)
        {
            listA = listA.GetRange(minAIndex + 1, index - 1);
        } else if (index < minAIndex)
        {
            listA = listA.GetRange(index + 1, minAIndex - 1);
        }
        else
        {
            return listB.ToArray();
        }
        return listB.Concat(listA).ToArray();
    }
    
    public double GroupList1(double[] array) //The sum of positive elements after the second maximum
    {
        List<double> temp = array.ToList();
        double fMax = temp.Max();
        temp.Remove(fMax);
        double sMax = temp.Max();
        int sMaxIndex = temp.IndexOf(sMax);
        
        List<double> list = array.ToList();
        list.RemoveRange(0, sMaxIndex + 1);
        List<double> sumList = new List<double>();
        foreach (double element in list)
        {
            if (element > 0)
            {
                sumList.Add(element);
            }
        }
        return sumList.Sum();
    }
    
    public double GroupList2(double[] array) //Sum of negative elements after the 2nd zero
    {
        List<double> temp = array.ToList();
        temp.Remove(0); //Remove first 0
        int sZeroIndex = temp.IndexOf(0); //Index second 0
        
        List<double> list = array.ToList();
        list.RemoveRange(0, sZeroIndex + 1);
        List<double> sumList = new List<double>();
        foreach (double element in list)
        {
            if (element < 0)
            {
                sumList.Add(element);
            }
        }
        return sumList.Sum();
    }

    public double Calculate(double a, double b, double c)
    {
        return (2.0 * Math.Sin(a)) + (3.0 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
    }
}

class Student
{
    private string _surname;
    private int _groupNumber;
    private int[] _grades;
    
    public string Surname => _surname;
    public int GroupNumber => _groupNumber;
    public int[] Grades => _grades;

    public bool IsFailing()
    {
        return _grades.Any(grade => grade == 2); // If one is 2
    }
    public bool IsExcellent()
    {
        return _grades.All(grade => grade >= 4); // All grades are above 4
    }
    
    public int this[int index]
    {
        get => _grades[index];
    }
    public Student(string surname, int groupNumber, int[] grades)
    {
        _surname = surname;
        _groupNumber = groupNumber;
        _grades = grades;
    }

    public static Student[] InsertStudents(int input)
    {
        List<Student> myStudents = new List<Student>();
        for (int i = 0; i < input; i++)
        {
            Console.Write("Write surname: ");
            string surname = Console.ReadLine();
            Console.Write("Write group number: ");
            int groupNumber = int.Parse(Console.ReadLine());
            Console.Write("Write grades (Like: 1 2 3 4 5): ");
            int[] grades = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Student student = new Student(surname, groupNumber, grades);
            myStudents.Add(student);
        }
        Student[] result = myStudents.ToArray();
        return result;
    }
    
    public static void sortedStudents(Student[] students)
    {
        foreach (var element in students.OrderBy(s => s.Surname))
        {
            Console.WriteLine($"{element.Surname} | {element.GroupNumber} | {String.Join(", ", element.Grades)}");
        }
    }
    
    public static int failingCount(Student[] students)
    {
        return students.Count(s => s.IsFailing());
    }
    
    public static void excellentByGroups1(Student[] students)
    {
        var groups = students.GroupBy(s => s.GroupNumber);
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
    public static void excellentByGroups2(Student[] students)
    {
        var groups = students.GroupBy(s => s.GroupNumber);
        foreach (var group in groups)
        {
            var excellentStudents = group.Where(s => s.IsExcellent()).ToList();
            Console.WriteLine($"Excellent in group {group.Key}: {excellentStudents.Count}");
        }
    }
    
    public static Student[] chooseGroup(Student[] students)
    {
        Console.Write("Choose a group of students: ");
        int group = Convert.ToInt32(Console.ReadLine());
        List<Student> tempStudents =  new List<Student>();
        foreach (var temp in students)
        {
            if (temp.GroupNumber == group)
            {
                tempStudents.Add(temp);
            }
        }
        return tempStudents.ToArray();
    }
    

    public static void allFailing(Student[] students)
    {
        foreach (var student in students)
        {
            if (student.IsFailing() == true)
            {
                Console.WriteLine($"{student.Surname} | {student.GroupNumber} | {String.Join(", ",student.Grades)}");
            }
        }
    }
}
