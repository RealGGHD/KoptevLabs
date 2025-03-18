namespace Lab1;
public class Program
{
    static void Main()
    {
        List<int> aArray = new List<int>();
        List<int> bArray = new List<int>();
        List<int> cArray = new List<int>();
        Console.WriteLine("Write in array a:");
        aArray = InsertInList(aArray);
        Console.WriteLine("Write in array b:");
        bArray = InsertInList(bArray);
        Console.WriteLine("Write in array c:");
        cArray = InsertInList(cArray);
        double a = GroupList(aArray);
        double b = GroupList(bArray) * 2.0;   
        double c = GroupList(cArray) / 2.0;
        double functionUp = (2 * Math.Sin(a)) + (3 * b * Math.Pow(Math.Cos(c), 3));
        double functionDown = a + b;
        double function = functionUp / functionDown;
        Console.WriteLine(function);
    }

    static List<int> InsertInList(List<int> inputList)
    {
        while (true)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            if (input != -111)
            {
                inputList.Add(input);
            }
            else
            {
                break;
            }
        }
        return inputList;
    }

    static int GroupList(List<int> inputList)
    {
        int firstMax = inputList.Max();
        List<int> temp = inputList.ToList();
        temp.Remove(firstMax);
        int secondMax = temp.Max();
        int indexSecondMax = temp.IndexOf(secondMax);
        inputList.RemoveRange(0, indexSecondMax + 1);
        List<int> sumList = new List<int>();
        foreach (int i in inputList)
        {
            if (i > 0)
            {
                sumList.Add(i);
            }
        }
        return sumList.Sum();
    }
}