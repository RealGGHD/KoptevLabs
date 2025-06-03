namespace Lab6;
using Task1;

class Tools
{
    //Private const fields
    private const int triangleSign = 4;
    private const int rectangleSign = 5;
    private const int triangleNumSides = 3;
    private const int rectangleNumSides = 4;
    private const int triangleColorPosition = 3;
    private const int rectangleColorPosition = 4;
    
    static void Main(string[] args)
    {
        string fileName = Input("Write file name (input): ");
        
        string[] lines = GetFileData($"{fileName}.txt");
        
        List<Polygon> polygons = new List<Polygon>();
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            int numOfParts = parts.Count();
            
            if (numOfParts == rectangleSign)
            {
                int[] lengths = new int[rectangleNumSides];
                PartsToLengths(lengths, parts, rectangleNumSides);
                string color = parts[rectangleColorPosition];
                Rectangle rectangle = new Rectangle(lengths, color);
                polygons.Add(rectangle);
            }
            else if (numOfParts == triangleSign)
            {
                int[] lengths = new int[triangleNumSides];
                PartsToLengths(lengths, parts, triangleNumSides);
                string color = parts[triangleColorPosition];
                Triangle triangle = new Triangle(lengths, color);
                polygons.Add(triangle);
            }
        }
        CalcSquare(polygons);
        
        SortPolygons(polygons);

        PrintPolygons(polygons);
    }
    /// <summary>
    /// Get path of input.txt in direstory with Tools.cs
    /// </summary>
    static string GetPath(string fileName)
    {
        string basePath = AppContext.BaseDirectory;
        string newPath = $@"..\..\..\{fileName}";
        string fullPath = Path.Combine(basePath, newPath);
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
    /// Calculate square for all polygons
    /// </summary>
    static void CalcSquare(List<Polygon> polygons)
    {
        foreach (var polygon in polygons)
        {
            polygon.SquareCalc();
        }
    }
    /// <summary>
    /// Sort all polygons by square from low to high
    /// </summary>
    static void SortPolygons(List<Polygon> polygons)
    {
        polygons.Sort((p1, p2) => p1.Square.CompareTo(p2.Square));
    }
    /// <summary>
    /// Print polygons one by one
    /// </summary>
    static void PrintPolygons(List<Polygon> polygons)
    {
        int positionOfPolygon  = 1;
        Console.WriteLine("№ | Type of figure | Square | Color");
        foreach (var polygon in polygons)
        {
            polygon.Print(positionOfPolygon);
            positionOfPolygon++;
        }
    }
    /// <summary>
    /// Convert parts (str) to lengths (int)
    /// </summary>
    static void PartsToLengths(int[] lengths, string[] parts, int corner)
    {
        for (int i = 0; i < corner; i++)
        {
            lengths[i] = int.Parse(parts[i]);
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
        Console.Write("\n");
        return input;
    }
}