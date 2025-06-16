using System.Text;

namespace Lab7.Task1;

public class FileAction
{
    //Fields
    private const string ErrorAthleteMsg = "Athletes not found";
    private const string MenuMsg = "№ | Surname | Age";
    /// <summary> 
    /// Write files with athletes by their category 
    /// </summary>
    public void WriteAthletesByCategory(List<Athletes> athletes)
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
    public string GetPath(string fileName, bool inOutputFolder = false)
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
    public string[] GetData(string fileName)
    {
        string pathToInput = GetPath(fileName);
        string[] lines = File.ReadAllLines(pathToInput);
        return lines;
    }
}