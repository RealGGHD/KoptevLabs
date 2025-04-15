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
        string name = Input("Enter your name for new bank account: ");
        BankAccount bankAccount = new BankAccount(name);
        Console.WriteLine("Congratulations, you have a new bank account!");
        while (true)
        { 
            string action = Input("\nChoose action (Deposit/Withdraw/Information): ");
            if (action == "Deposit")
            {
                string input = Input("Enter your amount for deposit: ");
                decimal amount = decimal.Parse(input);
                bankAccount.Deposit(amount);
            }
            else if (action == "Withdraw")
            {
                string input = Input("Enter your amount for withdraw: ");
                decimal amount = decimal.Parse(input);
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