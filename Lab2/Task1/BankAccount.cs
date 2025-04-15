//1 variant
namespace Lab2.Task1;
public class BankAccount
{
    private int _accountNumber;
    private string _ownerName;
    private decimal _balance;
    const int Zero = 0;
    Random random = new Random();
    /// <summary>
    /// Get and set properties
    /// </summary>
    public string OwnerName
    {
        get => _ownerName;
        set => _ownerName = string.IsNullOrWhiteSpace(value) ? throw new Exception("Input cannot be empty!") : value;
    }
    public decimal Balance
    {
        get => _balance;
        set => _balance = value < Zero ? Zero : value;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public BankAccount(string input)
    {
        _accountNumber = random.Next(Zero, int.MaxValue);
        OwnerName = input;
    }
    /// <summary>
    /// Deposit money to account
    /// </summary>
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"{OwnerName} deposited {amount} to {_accountNumber}.");
    }
    /// <summary>
    /// Withdraw money from account
    /// Check for low balance
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (Balance - amount < Zero)
        {
            Console.WriteLine("Error: Not enough money to withdraw.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"{OwnerName} withdrawn {amount} from {_accountNumber}.");
        }
    }
    /// <summary>
    /// Information about bank account 
    /// </summary>
    public void GetAccountInfo()
    {
        Console.WriteLine($"Account {_accountNumber} belongs to {OwnerName}.");
        Console.WriteLine($"Balance: {Balance}.");
    }
}