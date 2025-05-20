namespace Lab5;
using Task1;

class Tools
{
    /// <summary>
    /// Start Program
    /// </summary>
    static void Main(string[] args)
    {
        Bird bird = new Bird("Owl", 2);
        bird.Eat();
        
        Lion lion = new Lion("Azandica", 7);
        lion.Eat();
        
        Elephant elephant = new Elephant("Falconeri", 20);
        elephant.Eat();
    }
}