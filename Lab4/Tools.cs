//1 variant
namespace Lab4;
using Task1;
class Tools
{
    /// <summary>
    /// Run program
    /// </summary>
    static void Main()
    {
        string input = Input("Введите предложение: ");
        Text text = new Text(input);
        string[] arraySentence = text.GetResult();
        foreach (string sentence in arraySentence)
        {
            Console.WriteLine(sentence);
        }
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    static string Input(string message)
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