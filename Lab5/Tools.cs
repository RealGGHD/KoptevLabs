namespace Lab5;
using Lab5.Task1;

class Tools
{
    static void Main(string[] args)
    {
        Bird bird = new Bird("Bullfinch");
        bird.Eat();
        
        Lion lion = new Lion("Red-maned");
        lion.Eat();
        
        Elephant elephant = new Elephant("Big African");
        elephant.Eat();
    }
}