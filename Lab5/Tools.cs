namespace Lab5;
using Task1;

class Tools
{
    /// <summary>
    /// Start Program
    /// </summary>
    static void Main(string[] args)
    {
        Bird bird = new Bird("Bullfinch", 2);
        bird.Eat();
        
        Lion lion = new Lion("Red-maned", 7);
        lion.Eat();
        
        Elephant elephant = new Elephant("Big African", 20);
        elephant.Eat();
    }
}