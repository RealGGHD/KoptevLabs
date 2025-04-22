//1 variant
namespace Lab3.Task1;
abstract class Animal
{
    /// <summary>
    /// Inherited should initialize MakeSound()
    /// </summary>
    public abstract void MakeSound();
    /// <summary>
    /// Possible types of animal
    /// </summary>
    public enum AnimalType
    {
        Lion,
        Elephant,
        Bird
    }
    /// <summary>
    /// Creates object with type: Animal
    /// </summary>
    public static Animal CreateObject(AnimalType type)
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