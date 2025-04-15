//1 variant
namespace Lab1.Task1;
class Arrayy
{
    //Init private fields
    private int[] array;
    private const int MinimumUniqueNumbers = 2;
    //GsArray = Get and set array
    public int[] GsArray
    {
        get => array;
        set => array = value;
    }
    /// <summary>
    /// Initialize array A or B
    /// </summary>
    public void InitArray(string name)
    {
        string[] values = Tools.Input($"Write array {name}: ").Split(' ');
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
        int minAIndex = Array.LastIndexOf(arrayA, arrayA.Min()); //Index of min in array a from right
        int inputIndex = int.Parse(Tools.Input("Write index for array C: "));
    
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
        if (uniqueValues.Count < MinimumUniqueNumbers) throw new Exception("Not enough elements in array!");
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
}