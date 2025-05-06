namespace Lab5.Task1;

class Lion : Animal
{
    public Lion(string name) : base(name)
    {
    }
    public override void Eat()
    {
        Console.WriteLine("Lion eats meat!");
        IncreaseEnergy(3);
    }
}