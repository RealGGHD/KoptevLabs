namespace Lab2;


public class Task1
{
    public static void Run()
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

public class BankAccount
{
    //Init private fields
    private int accountNumber;
    private string ownerName;
    private decimal balance;
    //Add random
    Random random = new Random();
    //Get and set properties
    public string OwnerName
    {
        get => ownerName;
        set => ownerName = string.IsNullOrWhiteSpace(value) ? throw new Exception("Input cannot be empty!") : value;
    }
    public decimal Balance
    {
        get => balance;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public BankAccount(string input)
    {
        accountNumber = random.Next(0, int.MaxValue);
        OwnerName = input;
    }
    /// <summary>
    /// Deposit money to account
    /// </summary>
    public void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"{ownerName} deposited {amount} to {accountNumber}.");
    }
    /// <summary>
    /// Withdraw money from account
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (balance - amount < 0)
        {
            Console.WriteLine("Error: Not enough money to withdraw.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"{ownerName} withdrawn {amount} from {accountNumber}.");
        }
    }
    /// <summary>
    /// Information about bank account 
    /// </summary>
    public void GetAccountInfo()
    {
        Console.WriteLine($"Account {accountNumber} belongs to {ownerName}.");
        Console.WriteLine($"Balance: {balance}.");
    }
}
