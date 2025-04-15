//1 variant
namespace Lab3.Task1;
class Bird : Animal
{
    /// <summary>
    /// Make specific sound noise for Bird
    /// </summary>
    public override void MakeSound()
    {
        Console.WriteLine("Cheep-cheep!");
    }
}