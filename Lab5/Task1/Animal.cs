namespace Lab5.Task1;

abstract class Animal
{
    //Private fields
    private string name = "Default";
    private int age = 0;
    private int energy = 0;
    /// <summary>
    /// Get and set method for Name
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// Get and set method for Age
    /// </summary>
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    /// <summary>
    /// Animal constructor
    /// </summary>
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    /// <summary>
    /// Increase number of energy method
    /// </summary>
    public void IncreaseEnergy(int amount)
    {
        energy += amount;
        Console.WriteLine($"{Age} years old, {Name} has {energy} energy.");
    }
    /// <summary>
    /// Abstract method for overriding
    /// </summary>
    public abstract void Eat();
}