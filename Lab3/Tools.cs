//1 variant
namespace Lab3;
using Task1;
class Tools
{
    /// <summary>
    /// Start program
    /// </summary>
    static void Main()
    {
        //Init animals
        Animal lion = new Lion();
        Animal elephant = new Elephant();
        Animal bird = new Bird();
        while (true)
        {
            //Input name of animal
            string name = Input("Write the name of animal (Lion/Elephant/Bird): ");
            if (name == "Lion") lion.MakeSound();
            else if (name == "Elephant") elephant.MakeSound();
            else if (name == "Bird") bird.MakeSound();
            else Console.WriteLine("Error: Invalid input!");
        }
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    public static string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) throw new Exception("Error: Invalid input!");
        return input;
    }
}