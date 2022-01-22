namespace Project1_Theme2.Models;

public class Line : Figure
{
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public int Length { get; }

    public Line(int length)
    {
        Length = length;
    }

    public override double GetSquare()
    {
        return 0;
    }

    public override double GetPerimeter()
    {
        return Length;
    }
}
