namespace Lab7.Task1;

public class MenuAction
{
    //Private fields
    private const string StartMsg = "This program allows you to view the surnames of athletes by their type of sport.";
    private const string SportNameMsg = "\nAbove you see all available sports. Select index: ";
    private const string ErrorInputMsg = "Error: Invalid input!";
    /// <summary>
    /// Print menu for choose athletes 
    /// </summary>
    public void Print(List<Athletes> athletesArray)
    {
        Console.WriteLine(StartMsg);
        Type sportTypes = typeof(SportType);
        var sportArray = Enum.GetValues(sportTypes);
        int count = 1;
        foreach (SportType sport in sportArray)
        {
            Console.Write($"{sport} ({count}) | ");
            count++;
        }

        Array sports = Enum.GetValues(sportTypes);
        string specificSport = Input(SportNameMsg);
        int sportInput = int.Parse(specificSport);
        int sportIndex = sportInput - 1;
        SportType selectedSport = (SportType)sports.GetValue(sportIndex);
            
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(selectedSport + ":");
        Console.ResetColor();
            
        for (int i = 0; i < athletesArray.Count; i++)
        {
            if (athletesArray[i].Sport == selectedSport)
            {
                Console.WriteLine(athletesArray[i].LastName);
            }
        }
        Console.Write("\n");
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        bool isNull = string.IsNullOrWhiteSpace(input);
        if (isNull)
        {
            throw new Exception(ErrorInputMsg);
        }
        return input;
    }
}