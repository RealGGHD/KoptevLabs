//1 variant
namespace Lab2;

class Run
{
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        while (true)
        {
            Console.Write("Choose task (1): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) throw new Exception("Error: Invalid input!");
            int task = int.Parse(input);
            if (task == 1) BankAccount.Run();
        }
    }
}