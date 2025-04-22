//1 variant
namespace Lab3;
using Task1;
class Tools
{
    //Private field
    private const bool IgnoreRegister = true;
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        while (true)
        {
            string input = Input("Write the name of animal (Lion/Elephant/Bird): ").Trim();
            if (Enum.TryParse(input, IgnoreRegister, out Animal.AnimalType type))
            {
                Animal ourAnimal = Animal.CreateObject(type);
                ourAnimal.MakeSound();
            }
            else
            {
                Console.WriteLine("Error: Invalid input!");
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