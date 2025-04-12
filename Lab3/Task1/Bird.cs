//1 variant
namespace Lab3.Task1;
class Bird : Animal
{
    /// <summary>
    /// Override abstract class
    /// </summary>
    public override void MakeSound()
    {
        //Make specific noise
        Console.WriteLine("Cheep-cheep!");
    }
}