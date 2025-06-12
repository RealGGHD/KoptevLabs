using System.Text;
namespace Lab7;
using Task1;

class Tools
{
    //Fields
    private const string AthletesFile = "input";
    private const string SportNameMsg = "\nAbove you see all available sports. Select index: ";
    private const string ErrorAthleteMsg = "Athletes not found";
    private const string MenuMsg = "№ | Surname | Age";
    private const string ErrorInputMsg = "Error: Invalid input!";
    private const string StartMsg = "This program allows you to view the surnames of athletes by their type of sport.";
    /// <summary>
    /// Main method
    /// </summary>
    static void Main()
    {
        string[] lines = GetFileData(AthletesFile);
        
        List<Athletes> athletesArray = new List<Athletes>();
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            string lastName = parts[0];
            string dateOfBirth = parts[1];
            string sportName = parts[2];
            string rankName = parts[3];
            DateTime birthDate = DateTime.Parse(dateOfBirth);
            SportType sport = Enum.Parse<SportType>(sportName);
            Category rank = Enum.Parse<Category>(rankName);
            
            Athletes athlete = new Athletes(lastName, birthDate, sport, rank);
            athletesArray.Add(athlete);
        }
        
        WriteAthletesByCategory(athletesArray);
        while (true)
        {
            Menu(athletesArray);
        }
    }
    /// <summary>
    /// Menu to choose specific sport type
    /// </summary>
    static void Menu(List<Athletes> athletesArray)
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
    /// Write files with athletes by their category 
    /// </summary>
    static void WriteAthletesByCategory(List<Athletes> athletes)
    {
        Type categoryTypes = typeof(Category);
        var categoryArray = Enum.GetValues(categoryTypes);
        foreach (Category category in categoryArray)
        {
            string fileName = $"{category}";

            var athletesInCategory = athletes
                .Where(a => a.Rank == category)
                .GroupBy(a => a.Sport)
                .OrderBy(g => g.Key);

            var buildString = new StringBuilder();
            buildString.AppendLine($"{category}:\n");
            
            bool areAthletes = athletesInCategory.Any();
            if (!areAthletes)
            {
                buildString.AppendLine(ErrorAthleteMsg);
            }
            else
            {
                foreach (var sportGroup in athletesInCategory)
                {
                    string sportType = sportGroup.Key.ToString();
                    buildString.AppendLine(sportType);
                    buildString.AppendLine(MenuMsg);
                    int index = 1;
                    var sortedAthletes = sportGroup.OrderBy(a => a.LastName);
                    foreach (var athlete in sortedAthletes)
                    {
                        string LastName = athlete.LastName;
                        int Age = athlete.GetAge();
                        buildString.AppendLine($"{index} | {LastName} | {Age}");
                        index++;
                    }
                    buildString.AppendLine();
                }
            }

            string pathToOutputFolder = GetPath(fileName, true);
            string information = buildString.ToString();
            File.WriteAllText(pathToOutputFolder, information);
        }
    }
    /// <summary>
    /// Get path of input.txt in direstory with Tools.cs
    /// </summary>
    static string GetPath(string fileName, bool inOutputFolder = false)
    {
        string basePath = AppContext.BaseDirectory;
        string folderPath;
        if (inOutputFolder)
        {
            folderPath = Path.Combine(basePath, @"..\..\..\Output");
        }
        else
        {
            folderPath = Path.Combine(basePath, @"..\..\..");
        }

        if (inOutputFolder)
            Directory.CreateDirectory(folderPath);

        string filePath = $"{fileName}.txt";
        string fullPath = Path.Combine(folderPath, filePath);
        string path = Path.GetFullPath(fullPath);
        return path;
    }
    /// <summary>
    /// Txt to array
    /// </summary>
    static string[] GetFileData(string fileName)
    {
        string pathToInput = GetPath(fileName);
        string[] lines = File.ReadAllLines(pathToInput);
        return lines;
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    static string Input(string message)
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