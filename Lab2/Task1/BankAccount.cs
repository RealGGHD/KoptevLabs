//1 variant
namespace Lab2.Task1;
public class BankAccount
{
    //Init private fields
    private int _accountNumber;
    private string _ownerName;
    private decimal _balance;
    const int Zero = 0;
    //Add random
    Random random = new Random();
    //Get and set properties
    public string OwnerName
    {
        get => _ownerName;
        set => _ownerName = string.IsNullOrWhiteSpace(value) ? throw new Exception("Input cannot be empty!") : value;
    }
    public decimal Balance
    {
        get => _balance;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public BankAccount(string input)
    {
        _accountNumber = random.Next(Zero, int.MaxValue); //From zero to int.MaxValue
        OwnerName = input;
    }
    /// <summary>
    /// Deposit money to account
    /// </summary>
    public void Deposit(decimal amount)
    {
        _balance += amount;
        Console.WriteLine($"{_ownerName} deposited {amount} to {_accountNumber}.");
    }
    /// <summary>
    /// Withdraw money from account
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (_balance - amount < Zero) //if withdraw more than actual balance
        {
            Console.WriteLine("Error: Not enough money to withdraw.");
        }
        else
        {
            _balance -= amount;
            Console.WriteLine($"{_ownerName} withdrawn {amount} from {_accountNumber}.");
        }
    }
    /// <summary>
    /// Information about bank account 
    /// </summary>
    public void GetAccountInfo()
    {
        Console.WriteLine($"Account {_accountNumber} belongs to {_ownerName}.");
        Console.WriteLine($"Balance: {_balance}.");
    }
}