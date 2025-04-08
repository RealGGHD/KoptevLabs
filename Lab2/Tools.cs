//1 variant
namespace Lab2;
using Lab2.Task1;
class Tools
{
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        while (true)
        {
            int task = int.Parse(Input("Choose task (1): "));
            if (task == 1) FirstRun();
        }
    }
    /// <summary>
    /// Run first program 
    /// </summary>
    public static void FirstRun()
    {
        BankAccount bankAccount = new BankAccount(Input("Enter your name for new bank account: "));
        Console.WriteLine("Congratulations, you have a new bank account!");
        while (true)
        {
            Console.WriteLine("\nAvailable actions: Deposit (1), Withdraw (2), Information about account (3).");
            int action = int.Parse(Input("Choose action (1/2/3): "));
            if (action == 1)
            {
                decimal amount = decimal.Parse(Input("Enter amount for deposit: "));
                bankAccount.Deposit(amount);
            }
            else if (action == 2)
            {
                decimal amount = decimal.Parse(Input("Enter amount for withdraw: "));
                bankAccount.Withdraw(amount);
            }
            else if (action == 3)
            {
                bankAccount.GetAccountInfo();
            }
        }
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    public static string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) throw new Exception("Error: Invalid input!");
        return input;
    }
}