//1 variant
namespace Lab1;
class Run
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
                Task1.Run();
            }
            else if (task == 2)
            {
                Task2.Run();
            }
        }
    }
}