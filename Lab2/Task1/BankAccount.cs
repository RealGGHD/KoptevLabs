//1 variant
namespace Lab2.Task1;
public class BankAccount
{
    private int _accountNumber;
    private string _ownerName;
    private decimal _balance;
    const int Zero = 0;
    const int MaxValue = int.MaxValue;
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

    public int AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value < MaxValue ? MaxValue : value;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public BankAccount(string input)
    {
        AccountNumber = random.Next(Zero, MaxValue);
        OwnerName = input;
    }
    /// <summary>
    /// Deposit money to account
    /// </summary>
    public void Deposit(decimal Amount)
    {
        Balance += Amount;
        Console.WriteLine($"{OwnerName} deposited {Amount} to {AccountNumber}.");
    }
    /// <summary>
    /// Withdraw money from account
    /// Check for low balance
    /// </summary>
    public void Withdraw(decimal Amount)
    {
        if (Balance - Amount < Zero)
        {
            Console.WriteLine("Error: Not enough money to withdraw.");
        }
        else
        {
            Balance -= Amount;
            Console.WriteLine($"{OwnerName} withdrawn {Amount} from {AccountNumber}.");
        }
    }
    /// <summary>
    /// Information about bank account 
    /// </summary>
    public void GetAccountInfo()
    {
        Console.WriteLine($"Account {AccountNumber} belongs to {OwnerName}.");
        Console.WriteLine($"Balance: {Balance}.");
    }
}