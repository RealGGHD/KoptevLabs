namespace Lab6.Task1;

interface IComparable
{
    void Print(int index);
}

public abstract class Polygon : IComparable
{
    //Private firlds
    private const int maxSides = 4;
    private int[] _lengthsOfSides = new int[maxSides];
    private string _color;
    private double _square;
    /// <summary>
    /// Abstract method for realization in subclasses
    /// </summary>
    public abstract double squareCalc();
    /// <summary>
    /// Get and set for array of int
    /// </summary>
    public int[] LengthsOfSides
    {
        get{return _lengthsOfSides;}
        set{_lengthsOfSides = value;}
    }
    /// <summary>
    /// Get and set for color string
    /// </summary>
    public string Color
    {
        get{return _color;}
        set{_color = value;}
    }
    /// <summary>
    /// Get and set for square int
    /// </summary>
    public double Square
    {
        get{return _square;}
        set{_square = value;}
    }
    /// <summary>
    /// Print all information about specific polygon
    /// </summary>
    public void Print(int index)
    {
        if (Enum.TryParse<ConsoleColor>(_color, true, out ConsoleColor consoleColor)) //Try to parse color
        {
            Console.ForegroundColor = consoleColor;
            if (GetType().Name == "Triangle" && Color == "Red" && isRectangular())
            {
                int first = LengthsOfSides[0];
                int second = LengthsOfSides[1];
                int third = LengthsOfSides[2];
                int perimeter = first + second + third;
                Console.WriteLine($"{index} | {GetType().Name} | {_square}, Perimeter: {perimeter} | {_color}");
            }
            else
            {
                Console.WriteLine($"{index} | {GetType().Name} | {_square} | {_color}");
            }
            Console.ResetColor();
        }
    }
    /// <summary>
    /// Is triangle rectangular?
    /// </summary>
    bool isRectangular()
    {
        int max = LengthsOfSides.Max();
        int min = LengthsOfSides.Min();
        int mid = LengthsOfSides.Sum() - max - min;
        int maxSquared = max * max;
        int minSquared = min * min;
        int midSquared = mid * mid;
        if ((minSquared + midSquared) == maxSquared)
        {
            return true;
        }
        return false;
    }
}