namespace Lab5.Task1;

class Lion : Animal
{
    //Private fields
    private const int LivingCost = 3;
    /// <summary>
    /// Use animal constructor
    /// </summary>
    public Lion(string name, int age) : base(name, age)
    {
    }
    /// <summary>
    /// Eating method
    /// </summary>
    public override void Eat()
    {
        Console.WriteLine("Lion eats meat!");
        IncreaseEnergy(LivingCost);
    }
}