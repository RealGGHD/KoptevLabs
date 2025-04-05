namespace Lab2;

class Run
{
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        Console.Write("Enter your name for new bank account: ");
        string name = Input();
        BankAccount task1 = new BankAccount(name);
        Console.WriteLine("Congratulations, you have a new bank account!");
        
        while (true)
        {
            Console.WriteLine("\nAvailable actions: Deposit (1), Withdraw (2), Information about account (3).");
            Console.Write("Choose action (1/2/3): ");
            int action = int.Parse(Input());
            if (action == 1)
            {
                Console.Write("Enter amount for deposit: ");
                task1.Deposit(decimal.Parse(Input()));
            } 
            else if (action == 2)
            {
                Console.Write("Enter amount for withdraw: ");
                task1.Withdraw(decimal.Parse(Input()));
            }
            else if (action == 3)
            {
                task1.GetAccountInfo();
            }
        }
    }
    /// <summary>
    /// Input check
    /// </summary>
    public static string Input()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Input cannot be empty!");
        }
        return input;
    }
}