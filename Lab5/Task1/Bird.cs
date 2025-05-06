namespace Lab5.Task1;

class Bird : Animal
{
    /// <summary>
    /// Use animal constructor
    /// </summary>
    public Bird(string name, int age) : base(name, age)
    {
    }
    /// <summary>
    /// Message and increase energy
    /// </summary>
    public override void Eat()
    {
        Console.WriteLine("Bird eats seeds!");
        IncreaseEnergy(1);
    }
}