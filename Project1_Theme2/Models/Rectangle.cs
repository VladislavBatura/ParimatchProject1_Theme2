namespace Project1_Theme2.Models;

public class Rectangle : Figure
{
    public int Width { get; }
    public int Height { get; }
    public Dictionary<string, int[]> Location { get; set; }
    public bool IsFill { get; set; }

    public Rectangle(int width, int height, bool isFill)
    {
        Width = width;
        Height = height;
        IsFill = isFill;
        Location = new()
        {
            ["A"] = new int[2],
            ["B"] = new int[2],
            ["C"] = new int[2],
            ["D"] = new int[2]
        };
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
