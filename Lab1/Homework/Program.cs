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
        var array = new Array();
        var arrayAction = new ArrayAction();
        // Input Array C
        Console.Write("Array C: ");
        array.PrintArray(array.ArrayC);
        // Calculate A, B and C
        double a = arrayAction.SumPositiveAfterSecondMax(array.ArrayA);
        double b = arrayAction.SumPositiveAfterSecondMax(array.ArrayB) * 2.0;
        double c = arrayAction.SumPositiveAfterSecondMax(array.ArrayC) / 2.0;
        Console.WriteLine($"\nA: {a}, B: {b}, C: {c}");
        // Calculate result
        double result = arrayAction.Calculate(a, b, c);
        Console.WriteLine($"Result: {result}");
    }
    /// <summary>
    /// Start Task2
    /// </summary>
    static void TaskTwo()
    {
        //Initialize students collection
        var students = new StudentAction();
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