namespace Lab6.Task1;

public class Triangle : Polygon
{
    /// <summary>
    /// Use triangle constructor
    /// </summary>
    public Triangle(int[] lengthsofsides, string color)
    {
        LengthsOfSides = lengthsofsides;
        Color = color;
    }
    /// <summary>
    /// Calculate square of triangle via Heron's formula
    /// </summary>
    public override double SquareCalc()
    {
        int first = LengthsOfSides[0];
        int second = LengthsOfSides[1];
        int third = LengthsOfSides[2];
        int perimeter = first + second + third;
        double halfPerimeter = perimeter / 2.0;
        double square = Math.Sqrt(halfPerimeter * (halfPerimeter - first) * (halfPerimeter - second) * (halfPerimeter - third));
        Square = Math.Round(square, 2);
        return Square;
    }
}