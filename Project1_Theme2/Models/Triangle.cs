namespace Project1_Theme2.Models;

public class Triangle : Figure
{
    public int Height { get; }
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
        return 0;
    }

    public override double GetArea()
    {
        return 0;
    }
}
