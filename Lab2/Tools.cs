//1 variant
namespace Lab2;
using Task1;
class Tools
{
    /// <summary>
    /// Run program 
    /// </summary>
    static void Main()
    {
        BankAccount bankAccount = new BankAccount(Input("Enter your name for new bank account: "));
        Console.WriteLine("Congratulations, you have a new bank account!");
        while (true)
        { 
            string action = Input("Choose action (Deposit/Withdraw/Information): ");
            if (action == "Deposit")
            {
                decimal amount = decimal.Parse(Input("Enter amount for deposit: "));
                bankAccount.Deposit(amount);
            }
            else if (action == "Withdraw")
            {
                decimal amount = decimal.Parse(Input("Enter amount for withdraw: "));
                bankAccount.Withdraw(amount);
            }
            else if (action == "Information")
            {
                bankAccount.GetAccountInfo();
            }
            else
            {
                Console.WriteLine("Invalid input!");
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
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        return input;
    }
}