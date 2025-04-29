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
            string input = Input("Write the name of animal (Lion/Elephant/Bird): ");
            string preparedInput = input.Trim();
            
            Animal.AnimalType type;
            bool isParsed = Enum.TryParse(preparedInput, IgnoreRegister, out type);
            
            if (isParsed)
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