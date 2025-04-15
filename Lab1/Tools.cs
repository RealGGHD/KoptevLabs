//1 variant
namespace Lab1;
using Lab1.Task1;
using Lab1.Task2;
class Tools
{
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        while (true)
        {
            int task = int.Parse(Input("Choose task (1/2): "));
            if (task == 1) FirstRun();
            else if (task == 2) SecondRun();
        }
    }
    /// <summary>
    /// Run first program
    /// </summary>
    public static void FirstRun()
    {
        //Initialize array
        Arrayy arrayA = new();
        Arrayy arrayB = new();
        Arrayy arrayC = new();
        //Insert data in Arrays
        arrayA.InitArray("A");
        arrayB.InitArray("B");
        arrayC.InitArrayC(arrayA.GsArray, arrayB.GsArray);
        //Print Array C
        arrayC.PrintArray("Array C: ");
        // Calculate A, B and C
        double a = arrayA.CalcLetter();
        double b = arrayB.CalcLetter();
        double c = arrayC.CalcLetter();
        //Print A, B and C
        Console.WriteLine($"\nA: {a}, B: {b}, C: {c}");
        // Calculate result
        Arrayy.CalcFunction(a, b, c);
    }
    /// <summary>
    /// Run second program
    /// </summary>
    public static void SecondRun()
    {
        //Initialize students collection
        var task = new StudentCollection();
        //Read students data from console
        task.ReadStudents();
        //Sorted students by alphabet
        task.SortedStudents();
        //Amount of failing students
        task.FailingStudents();
        //Excellent students in each group
        task.ExcellentByGroups();
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    public static string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        return input;
    }
}