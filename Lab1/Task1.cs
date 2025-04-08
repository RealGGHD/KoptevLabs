namespace Lab1;
class Arrays
{
    //Init private fields
    private int[] _array;
    private const int MinimumUniqueNumbers = 2;
    //GsArray = Get and set array
    public int[] GsArray
    {
        get => _array;
        set => _array = value;
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    public static string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) throw new Exception("Error: Invalid input!");
        return input;
    }
    /// <summary>
    /// Initialize array A or B
    /// </summary>
    public void InitArray(string name)
    {
        string[] values = Input($"Write array {name}: ").Split(' ');
        GsArray = Array.ConvertAll(values, int.Parse);
    }
    /// <summary>
    /// Initialize array C
    /// </summary>
    public void InitArrayC(int[] arrayA, int[] arrayB)
    {
        //All elements of Array B after left Max
        int minBIndex = Array.IndexOf(arrayB, arrayB.Min()); //Index of min in array b
        int afterMinBIndex = minBIndex + 1;
        int[] subArrayB = arrayB[(afterMinBIndex)..]; //All elements after minimun
        //All elements of Array A between right min element and input element
        int minAIndex = Array.LastIndexOf(arrayA, arrayA.Min()); //Index of min in array a
        int inputIndex = int.Parse(Input("Write index for array C: "));

        if (inputIndex == minAIndex) //If minIndex == InputIndex -> ArrayC = ArrayB;
        {
            GsArray = subArrayB; //Only Array B
            return;
        }
        
        int startIndex = Math.Min(inputIndex, minAIndex) + 1; //find start index in subArrayA
        int endIndex = Math.Max(inputIndex, minAIndex); //find end index in subArrayA

        int[] subArrayA;
        if (startIndex < endIndex)
        {
            subArrayA = arrayA[startIndex..endIndex];
        }
        else
        {
            subArrayA = [];
        }
        
        GsArray = subArrayB.Concat(subArrayA).ToArray();
    }
    /// <summary>
    /// Print Array
    /// </summary>
    public void PrintArray(string message)
    {
        Console.Write(message);
        foreach (var item in GsArray)
        {
            Console.Write($"{item} ");
        }
    }
    /// <summary>
    /// The sum of positive elements after the second maximum
    ///  </summary>
    public double CalcLetter()
    {
        var uniqueValues = GsArray.Distinct().OrderByDescending(x => x).ToList(); //Unique sort from max to min
        if (uniqueValues.Count < MinimumUniqueNumbers) throw new InvalidOperationException("Not enough elements in array!");
        int secondMax = uniqueValues[1]; //Take Second Max
        int secondMaxIndex = Array.IndexOf(GsArray, secondMax); //Find Second Max Index
        int amountForSkip = secondMaxIndex + 1; //Amount for skip
        double letter = GsArray.Skip(amountForSkip).Where(x => x > 0).Sum(); //Sum of positive elements after second max
        return letter;
    }
    /// <summary>
    /// Calculate function
    /// </summary>
    public static void CalcFunction(double a, double b, double c)
    {
        double result = (2.0 * Math.Sin(a)) + (3.0 * b * Math.Pow(Math.Cos(c), 3)) / (a + b); //Calc function
        Console.WriteLine($"Result: {result}");
    }
    /// <summary>
    /// Run program
    /// </summary>
    public static void Run()
    {
        //Initialize array
        Arrays arrayA = new();
        Arrays arrayB = new();
        Arrays arrayC = new();
        //Insert data in Arrays
        arrayA.InitArray("A");
        arrayB.InitArray("B");
        arrayC.InitArrayC(arrayA.GsArray, arrayB.GsArray);
        //Print Array C
        arrayC.PrintArray("Array C: ");
        // Calculate A, B and C
        double a = arrayA.CalcLetter();
        double b = arrayB.CalcLetter();
        double c = arrayC.CalcLetter();
        //Print A, B and C
        Console.WriteLine($"\nA: {a}, B: {b}, C: {c}");
        // Calculate result
        Arrays.CalcFunction(a, b, c);
    }
}