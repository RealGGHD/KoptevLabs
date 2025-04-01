namespace Homework;

class Array
{
    //Init private fields
    private double[] _arrayA;
    private double[] _arrayB;
    private double[] _arrayC;
    private double _a;
    private double _b;
    private double _c;
    //Get private double[] fields
    public double[] ArrayA => _arrayA;
    public double[] ArrayB => _arrayB;
    public double[] ArrayC => _arrayC;
    //Get and set private double fields
    public double A
    {
        get => _a;
        set => _a = value;
    }
    public double B
    {
        get => _b;
        set => _b = value;
    }
    public double C
    {
        get =>  _c;
        set => _c = value;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public Array()
    {
        var action = new ArrayAction();
        _arrayA = action.InitArray("A");
        _arrayB = action.InitArray("B");
        _arrayC = action.InitArrayC(_arrayA, _arrayB);
    }
    /// <summary>
    /// Print Array
    /// </summary>
    public void PrintArray(double[] array)
    {
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
    }
}

class ArrayAction
{
    /// <summary>
    /// Initialize array
    /// </summary>
    public double[] InitArray(string name)
    {
        Console.Write($"Write array {name} (Like: 10.2 3 52): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Error: Invalid input!");
        }
        string[] values = input.Split(' ');
        return System.Array.ConvertAll(values, double.Parse);
    }
    /// <summary>
    /// Initialize Array C
    /// </summary>
    public double[] InitArrayC(double[] arrayA, double[] arrayB)
    {
        int minBIndex = System.Array.IndexOf(arrayB, arrayB.Min()); //Index of Min in Array B
        double[] subArrayB = arrayB.Skip(minBIndex + 1).ToArray(); //All elements after min Array B
        
        int minAIndex = System.Array.LastIndexOf(arrayA, arrayA.Min()); //Right minimum index of A
        Console.Write("Write index for array C: ");
        string? input = Console.ReadLine(); //InputIndex
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        int inputIndex = int.Parse(input);
        double[] subArrayA = arrayA;
        if (inputIndex > minAIndex)
        {
            int count = inputIndex - (minAIndex + 1);
            if (count < 0)
            {
                subArrayA = arrayA.Skip(minAIndex + 1).Take(count).ToArray();
            }
        }
        else if (inputIndex < minAIndex)
        {
            int count = minAIndex - (inputIndex + 1);
            if (count > 0)
            {
                subArrayA  = arrayA.Skip(inputIndex + 1).Take(count).ToArray();
            }
        }
        else
        {
            return subArrayB;
        }
        return subArrayB.Concat(subArrayA).ToArray();
    }
    /// <summary>
    /// The sum of positive elements after the second maximum
    ///  </summary>
    public double SumPositiveAfterSecondMax(double[] array)
    {
        var uniqueValues = array.Distinct().OrderByDescending(x => x).ToList(); //Unique sort from max to min
        if (uniqueValues.Count < 2)
        {
            throw new InvalidOperationException("Not enough elements in array!");
        }
        double secondMax = uniqueValues[1]; //Second Max
        int secondMaxIndex = System.Array.IndexOf(array, secondMax);
        return array.Skip(secondMaxIndex + 1).Where(x => x > 0).Sum();
    }
    /// <summary>
    /// Calculate function
    /// </summary>
    public double Calculate(double a, double b, double c)
    {
        return (2.0 * Math.Sin(a)) + (3.0 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
    }
}
