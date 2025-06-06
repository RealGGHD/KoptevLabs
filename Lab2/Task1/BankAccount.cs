﻿//1 variant
namespace Lab2.Task1;
public class BankAccount
{
    private int _accountNumber;
    private string _ownerName;
    private decimal _balance;
    private const int Zero = 0;
    private const int MaxValue = int.MaxValue;
    Random random = new Random();
    /// <summary>
    /// OwnerName cannot be a space or null
    /// </summary>
    public string OwnerName
    {
        get => _ownerName;
        set => _ownerName = string.IsNullOrWhiteSpace(value) ? throw new Exception("Input cannot be empty!") : value;
    }
    /// <summary>
    /// Balance cannot be less than 0
    /// </summary>
    public decimal Balance
    {
        get => _balance;
        set => _balance = value < Zero ? Zero : value;
    }
    /// <summary>
    /// AccountNumber cannot be larger than MaxValue
    /// </summary>
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
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"{OwnerName} deposited {amount} to {AccountNumber}.");
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
            Console.WriteLine($"{OwnerName} withdrawn {amount} from {AccountNumber}.");
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