namespace Lab5.Task1;

abstract class Animal
{
    //Private fields
    private string name = "Default";
    private int age = 0;
    private int energy = 0;
    //Get and set for Name
    public string NameGS
    {
        get { return name; }
        set { name = value; }
    }
    //Get and set for Age
    public int AgeGS
    {
        get { return age; }
        set { age = value; }
    }
    //Constructor
    public Animal(string name)
    {
        this.name = name;
    }
    //Change number of energy 
    public void IncreaseEnergy(int amount)
    {
        energy += amount;
        Console.WriteLine($"{NameGS} has {energy} energy.");
    }

    public abstract void Eat();
}