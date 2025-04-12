//1 variant
namespace Lab3.Task1;
class Elephant : Animal
{
    /// <summary>
    /// Override abstract class
    /// </summary>
    public override void MakeSound()
    {
        //Make specific noise
        Console.WriteLine("Phrrooo!");
    }
}