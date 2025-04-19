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
        //string input = "Сегодня будет дождь 19.04.2025. Завтра будет снег 20/04/25. Потом будет солнечно 01.01.20 20/04/24.";
        string input = Input("Введите предложение: ");
        Text text = new Text(input);
        string[] result = text.GetResult();
        foreach (string sentence in result)
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