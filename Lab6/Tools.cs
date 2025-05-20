namespace Lab6;

class Tools
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var data = File.ReadAllLines("../../somefile.txt");
        foreach (var line in data)
        {
            var elements = line.Split(' ');
            var someObject = new
            {
                length1 = int.Parse(elements[0]),
                length2 = int.Parse(elements[1]),
            }
        }
    }
}