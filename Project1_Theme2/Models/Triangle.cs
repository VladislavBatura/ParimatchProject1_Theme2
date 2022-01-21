namespace Project1_Theme2.Models;

public class Triangle : Figure
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public int Height { get; }
    public Dictionary<string, (int, int)> Location { get; set; }
    public bool IsFill { get; set; }

    public Triangle(double a, double b, double c, int height, bool isFill)
    {
        A = a;
        B = b;
        C = c;
        Height = height;
        IsFill = isFill;
    }

    public override double GetPerimeter()
    {
        return A + B + C;
    }

    public override double GetArea()
    {
        var p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
}
