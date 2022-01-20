namespace Project1_Theme2.Models;

public class Rectangle : Figure
{
    public double Width { get; }
    public double Height { get; }
    public Dictionary<string, (int, int)> Location { get; set; }
    public bool IsFill { get; set; }

    public Rectangle(double width, double height, bool isFill)
    {
        Width = width;
        Height = height;
        IsFill = isFill;
        Location = new();
    }

    public override double GetPerimeter()
    {
        return (Width * 2) + (Height * 2);
    }

    public override double GetArea()
    {
        return Width * Height;
    }
}
