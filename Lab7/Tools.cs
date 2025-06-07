using System.Text;

namespace Lab7;
using Task1;

class Tools
{
    /// <summary>
    /// Main method
    /// </summary>
    static void Main(string[] args)
    {
        string fileName = Input("Write file name (input): ");
        
        string[] lines = GetFileData($"{fileName}.txt");
        
        List<Athletes> athletesArray = new List<Athletes>();
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            string LastName = parts[0];
            DateTime BirthDate = DateTime.Parse(parts[1]);
            SportType Sport = Enum.Parse<SportType>(parts[2]);
            Category Rank = Enum.Parse<Category>(parts[3]);
            
            Athletes athlete = new Athletes(LastName, BirthDate, Sport, Rank);
            
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
        int count = 1;
        foreach (SportType sport in Enum.GetValues(typeof(SportType)))
        {
            Console.Write($"{sport} ({count++}) | ");
        }

        Array sports = Enum.GetValues(typeof(SportType));
        string necessarySport = Input("\nWrite name of sport you need (index): ");
        int sportIndex = int.Parse(necessarySport);
        SportType selectedSport = (SportType)sports.GetValue(--sportIndex);
            
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{selectedSport}:");
        Console.ResetColor();
            
        for (int i = 0; i < athletesArray.Count; i++)
        {
            if (athletesArray[i].Sport == selectedSport)
            {
                Console.WriteLine(athletesArray[i].LastName);
                break;
            }
        }
        Console.Write("\n");
    }
    /// <summary>
    /// Write files with athletes by their category 
    /// </summary>
    static void WriteAthletesByCategory(List<Athletes> athletes)
    {
        foreach (Category category in Enum.GetValues(typeof(Category)))
        {
            string fileName = $"{category}.txt";

            var athletesInCategory = athletes
                .Where(a => a.Rank == category)
                .GroupBy(a => a.Sport)
                .OrderBy(g => g.Key);

            var sb = new StringBuilder();
            sb.AppendLine($"{category}:\n");
            
            bool areAthletes = athletesInCategory.Any();
            if (!areAthletes)
            {
                sb.AppendLine("Athletes not found");
            }
            else
            {
                foreach (var sportGroup in athletesInCategory)
                {
                    string sportType = sportGroup.Key.ToString();
                    sb.AppendLine(sportType);
                    sb.AppendLine("№ | Surname | Age");
                    int index = 1;
                    foreach (var athlete in sportGroup.OrderBy(a => a.LastName))
                    {
                        string LastName = athlete.LastName;
                        int Age = athlete.GetAge();
                        sb.AppendLine($"{index} | {LastName} | {Age}");
                        index++;
                    }
                    sb.AppendLine();
                }
            }

            string pathToOutputFolder = GetPath(fileName, true);
            string information = sb.ToString();
            File.WriteAllText(pathToOutputFolder, information);
        }
    }
    /// <summary>
    /// Get path of input.txt in direstory with Tools.cs
    /// </summary>
    static string GetPath(string fileName, bool inOutputFolder = false)
    {
        string basePath = AppContext.BaseDirectory;
        string folderPath = inOutputFolder 
            ? Path.Combine(basePath, @"..\..\..\Output")
            : Path.Combine(basePath, @"..\..\..");

        if (inOutputFolder)
            Directory.CreateDirectory(folderPath);

        string fullPath = Path.Combine(folderPath, fileName);
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
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        return input;
    }
}