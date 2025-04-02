namespace Lab2;

public class BankAccount
{
    //Init private fields
    private int accountNumber;
    private string ownerName;
    private decimal balance;
    Random _rnd = new Random();
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
        accountNumber = _rnd.Next(0, int.MaxValue);
        OwnerName = input;
    }
    /// <summary>
    /// Deposit money to account
    /// </summary>
    public void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Deposit {amount} to {OwnerName}.");
    }
    /// <summary>
    /// Withdraw money from account
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (balance - amount < 0)
        {
            Console.WriteLine("Error: Not enough money to deposit.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"{ownerName} deposited {amount}.");
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