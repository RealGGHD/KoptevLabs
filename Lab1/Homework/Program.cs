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
        //Print array C
        Console.Write("Array C: ");
        myObject.PrintArray(myObject.ArrayC);
        //Init A, B and C
        myObject.A = myObject.GroupList(myObject.ArrayA);
        myObject.B = myObject.GroupList(myObject.ArrayB) * 2.0;
        myObject.C = myObject.GroupList(myObject.ArrayC) / 2.0;
        //Calculate function
        double result = myObject.Calculate(myObject.A, myObject.B, myObject.C);
        //Print Result
        Console.WriteLine($"\nResult: {result}");
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