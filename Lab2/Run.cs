namespace Lab2;

class Run
{
    static void Main()
    {
        Console.Write("Enter your name for new bank account: ");
        string name = Input();
        BankAccount bankAccount = new BankAccount(name);
        Console.WriteLine("Congratulations, you have a new bank account!");
        
        while (true)
        {
            Console.WriteLine("\nAvailable actions: Deposit (1), Withdraw (2), Information about account (3).");
            Console.Write("Choose action (1/2/3): ");
            int action = int.Parse(Input());
            if (action == 1)
            {
                Console.Write("Enter amount for deposit: ");
                bankAccount.Deposit(decimal.Parse(Input()));
            } 
            else if (action == 2)
            {
                Console.Write("Enter amount for withdraw: ");
                bankAccount.Withdraw(decimal.Parse(Input()));
            }
            else if (action == 3)
            {
                bankAccount.GetAccountInfo();
            }
        }
    }
    static string Input()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Input cannot be empty!");
        }
        return input;
    }
}