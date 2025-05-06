namespace Lab5.Task1;

class Bird : Animal
{
    public Bird(string name) : base(name)
    {
    }
    public override void Eat()
    {
        Console.WriteLine("Bird eats seeds!");
        IncreaseEnergy(1);
    }
}