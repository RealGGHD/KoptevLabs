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
    private const string partPath = "..\\..\\..\\";
    
    static void Main(string[] args)
    {
        string[] lines = getInput("input.txt");
        
        List<Polygon> polygons = new List<Polygon>();
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            int numOfParts = parts.Count();
            
            if (numOfParts == rectangleSign)
            {
                int[] lengths = new int[rectangleNumSides];
                partsToLengths(lengths, parts, rectangleNumSides);
                Rectangle rectangle = new Rectangle(lengths, parts[rectangleColorPosition]);
                polygons.Add(rectangle);
            }
            else if (numOfParts == triangleSign)
            {
                int[] lengths = new int[triangleNumSides];
                partsToLengths(lengths, parts, triangleNumSides);
                Triangle triangle = new Triangle(lengths, parts[triangleColorPosition]);
                polygons.Add(triangle);
            }
        }
        calcSquare(polygons);
        
        sortPolygons(polygons);

        printPolygons(polygons);
    }
    /// <summary>
    /// Get path of input.txt in direstory with Tools.cs
    /// </summary>
    static string getPath(string fileName)
    {
        string basePath = AppContext.BaseDirectory;
        string newPath = $@"{partPath}{fileName}";
        string fullPath = Path.Combine(basePath, newPath);
        string path = Path.GetFullPath(fullPath);
        return path;
    }
    /// <summary>
    /// Txt to array
    /// </summary>
    static string[] getInput(string fileName)
    {
        string pathToInput = getPath(fileName);
        string[] lines = File.ReadAllLines(pathToInput);
        return lines;
    }
    /// <summary>
    /// Calculate square for all polygons
    /// </summary>
    static void calcSquare(List<Polygon> polygons)
    {
        foreach (var polygon in polygons)
        {
            polygon.squareCalc();
        }
    }
    /// <summary>
    /// Sort all polygons by square from low to high
    /// </summary>
    static void sortPolygons(List<Polygon> polygons)
    {
        polygons.Sort((p1, p2) => p1.Square.CompareTo(p2.Square));
    }
    /// <summary>
    /// Print polygons one by one
    /// </summary>
    static void printPolygons(List<Polygon> polygons)
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
    static void partsToLengths(int[] lengths, string[] parts, int corner)
    {
        for (int i = 0; i < corner; i++)
        {
            lengths[i] = int.Parse(parts[i]);
        }
    }
}