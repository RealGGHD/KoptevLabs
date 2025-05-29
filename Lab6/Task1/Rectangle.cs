namespace Lab6.Task1;

public class Rectangle : Polygon
{
    /// <summary>
    /// Use rectangle constructor
    /// </summary>
    public Rectangle(int[] lengthsofsides, string color)
    {
        LengthsOfSides = lengthsofsides;
        Color = color;
    }
    /// <summary>
    /// Calculate square of triangle via multiplication of near sides
    /// </summary>
    public override double squareCalc()
    {
        int width = LengthsOfSides[0];
        int height = LengthsOfSides[1];
        Square = width * height;
        return Square;
    }
}