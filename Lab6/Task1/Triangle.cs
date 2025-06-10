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
        int firstSide = LengthsOfSides[0];
        int secondSide = LengthsOfSides[1];
        int thirdSide = LengthsOfSides[2];
        int perimeter = firstSide + secondSide + thirdSide;
        double halfPerimeter = perimeter / 2.0;
        double square = Math.Sqrt(halfPerimeter * (halfPerimeter - firstSide) * (halfPerimeter - secondSide) * (halfPerimeter - thirdSide));
        Square = Math.Round(square, 2);
        return Square;
    }
}