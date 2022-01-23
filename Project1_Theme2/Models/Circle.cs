namespace Project1_Theme2.Models;

public class Circle : Figure
{
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public double Radius { get; set; }
    public bool Fill { get; set; }

    public Circle(double radius, bool whole)
    {
        Radius = radius;
        Fill = whole;
    }

    public Circle(double radius, bool whole, int locX, int locY)
    {
        Radius = radius;
        Fill = whole;
        LocationX = locX;
        LocationY = locY;
    }

    public override double GetPerimeter()
    {
        return Radius * 2 * Math.PI;
    }

    public override double GetSquare()
    {
        return Math.Pow(Radius, 2) * Math.PI;
    }
}
