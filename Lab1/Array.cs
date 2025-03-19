namespace Lab1;

public class Array
{
    private int[] _arrayA;
    private int[] _arrayB;
    private int[] _arrayC;
    private double _a;
    private double _b;
    private double _c;
    
    public int[] ArrayA
    {
        get { return _arrayA; }
    }
    public int[] ArrayB
    {
        get { return _arrayB; }
    }
    public int[] ArrayC
    {
        get { return _arrayC; }
    }
    
    public double A
    {
        get { return _a; }
        set { _a = value; }
    }
    public double B
    {
        get { return _b; }
        set { _b = value; }
    }
    public double C
    {
        get { return _c; } 
        set { _c = value; }
    }

    public Array(string valuesA, string valuesB)
    {
        string[] arrayAStrings = valuesA.Split(' ');
        string[] arrayBStrings = valuesB.Split(' ');
        _arrayA = System.Array.ConvertAll(arrayAStrings, int.Parse);
        _arrayB = System.Array.ConvertAll(arrayBStrings, int.Parse);
        _arrayC = InitArrayC(_arrayA, _arrayB);
    }
    
    static int[] InitArrayC(int[] arrayA, int[] arrayB)
    {
        List<int> tempArrayB = arrayA.ToList();
        int minArrayBIndex = System.Array.IndexOf(arrayB, arrayB.Min());
        tempArrayB.RemoveRange(0, minArrayBIndex + 1);
        
        Console.Write("Write index for array C: ");
        string input = Console.ReadLine();
        int index = int.Parse(input);
        List<int> tempArrayA = arrayA.ToList();
        int minArrayAIndex = System.Array.LastIndexOf(arrayB, arrayB.Min());
        if (index > minArrayAIndex)
        {
            tempArrayA = tempArrayA.GetRange(minArrayAIndex + 1, index - 1);
        } else if (index < minArrayAIndex)
        {
            tempArrayA = tempArrayA.GetRange(index + 1, minArrayAIndex - 1);
        }
        else
        {
            return tempArrayB.ToArray();
        }
        return tempArrayB.Concat(tempArrayA).ToArray();
    }
    public static double GroupListFirst(int[] array)
    {
        List<int> temp = array.ToList();
        int firstMax = temp.Max();
        temp.Remove(firstMax);
        int secondMax = temp.Max();
        int secondMaxIndex = temp.IndexOf(secondMax);
        temp.RemoveRange(0, secondMaxIndex + 1);
        List<int> sumList = new List<int>();
        foreach (int i in temp)
        {
            if (i > 0)
            {
                sumList.Add(i);
            }
        }
        return sumList.Sum();
    }
    
    public static double GroupListSecond(int[] array)
    {
        List<int> temp = array.ToList();
        temp.Remove(0);
        int secondZeroIndex = temp.IndexOf(0);
        temp.RemoveRange(0, secondZeroIndex + 1);
        List<int> sumList = new List<int>();
        foreach (int i in temp)
        {
            if (i < 0)
            {
                sumList.Add(i);
            }
        }
        return sumList.Sum();
    }

    public static double Calc(double a, double b, double c)
    {
        return (2 * Math.Sin(a)) + (3 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
    }
}

public class Aboba
{
    static void Main()
    {
        Console.Write("Write array A: ");
        string arrayA = Console.ReadLine();
        Console.Write("Write array B: ");
        string arrayB = Console.ReadLine();
        Array myObject = new Array(arrayA, arrayB);
        
        Console.Write("Choose variant (1/2): ");
        string variant = Console.ReadLine();
        if (variant == "1")
        {
            myObject.A = Array.GroupListFirst(myObject.ArrayA);
            myObject.B = Array.GroupListFirst(myObject.ArrayB) * 2.0;
            myObject.C = Array.GroupListFirst(myObject.ArrayC) / 2.0;
        }
        else if (variant == "2")
        {
            myObject.A = Array.GroupListSecond(myObject.ArrayA);
            myObject.B = Array.GroupListSecond(myObject.ArrayB) * 2.0;
            myObject.C = Array.GroupListSecond(myObject.ArrayC) / 2.0;
        }
        double result = Array.Calc(myObject.A, myObject.B, myObject.C);
        Console.WriteLine($"Result: {result}");
    }
}