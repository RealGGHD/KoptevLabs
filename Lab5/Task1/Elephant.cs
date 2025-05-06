namespace Lab5.Task1;

class Elephant : Animal
{
    public Elephant(string name) : base(name)
    {
    }
    public override void Eat()
    {
        Console.WriteLine("Elephant eats grass!");
        IncreaseEnergy(5);
    }
}