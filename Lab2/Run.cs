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
            if (task == 1) FirstRun();
        }
    }
    /// <summary>
    /// Run first program 
    /// </summary>
    public static void FirstRun()
    {
        Console.Write("Enter your name for new bank account: ");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name)) throw new Exception("Input cannot be empty!");
        BankAccount task1 = new BankAccount(name);
        Console.WriteLine("Congratulations, you have a new bank account!");

        while (true)
        {
            Console.WriteLine("\nAvailable actions: Deposit (1), Withdraw (2), Information about account (3).");
            Console.Write("Choose action (1/2/3): ");
            string actionStr = Console.ReadLine();
            if (string.IsNullOrEmpty(actionStr)) throw new Exception("Input cannot be empty!");
            int action = int.Parse(actionStr);
            if (action == 1)
            {
                Console.Write("Enter amount for deposit: ");
                string depositStr = Console.ReadLine();
                if (string.IsNullOrEmpty(depositStr)) throw new Exception("Input cannot be empty!");
                task1.Deposit(decimal.Parse(depositStr));
            }
            else if (action == 2)
            {
                Console.Write("Enter amount for withdraw: ");
                string withdrawStr = Console.ReadLine();
                if (string.IsNullOrEmpty(withdrawStr)) throw new Exception("Input cannot be empty!");
                task1.Withdraw(decimal.Parse(withdrawStr));
            }
            else if (action == 3)
            {
                task1.GetAccountInfo();
            }
        }
    }
}