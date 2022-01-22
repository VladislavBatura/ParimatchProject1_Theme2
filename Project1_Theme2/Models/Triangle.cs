namespace Project1_Theme2.Models;

public class Triangle : Figure
{
    public int Height { get; }
    public int Foundation { get; set; }
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public bool IsFill { get; set; }

    public Triangle(int height, bool isFill)
    {
        Height = height;
        IsFill = isFill;
    }

    public override double GetPerimeter()
    {
        return (Height * 2) + Foundation;
    }

    public override double GetSquare()
    {
        return 0.5d * Height * Foundation;
    }
}
