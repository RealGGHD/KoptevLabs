//1 variant
namespace Lab3.Task1;
abstract class Animal
{
    /// <summary>
    /// Inherited should initialize MakeSound()
    /// </summary>
    public abstract void MakeSound();
    /// <summary>
    /// Possible type of animal
    /// </summary>
    public enum AnimalType
    {
        Lion,
        Elephant,
        Bird
    }
    /// <summary>
    /// Creates an instance with the required animal   
    /// </summary>
    public static Animal Create(AnimalType type)
    {
        switch (type)
        {
            case AnimalType.Lion: return new Lion();
            case AnimalType.Elephant: return new Elephant();
            case AnimalType.Bird: return new Bird();
            default: return null;
        }
    }
}