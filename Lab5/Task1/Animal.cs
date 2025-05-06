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
    public string NameGS
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// Get and set method for Age
    /// </summary>
    public int AgeGS
    {
        get { return age; }
        set { age = value; }
    }
    /// <summary>
    /// Animal constructor
    /// </summary>
    public Animal(string name, int age)
    {
        NameGS = name;
        AgeGS = age;
    }
    /// <summary>
    /// Increase number of energy method
    /// </summary>
    public void IncreaseEnergy(int amount)
    {
        energy += amount;
        Console.WriteLine($"{AgeGS} years old, {NameGS} has {energy} energy.");
    }
    /// <summary>
    /// Abstract method for overriding
    /// </summary>
    public abstract void Eat();
}