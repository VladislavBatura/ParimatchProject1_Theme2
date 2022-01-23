namespace Project1_Theme2.Models;

public abstract class Figure
{
    public int Layer { get; set; }
    public abstract double GetPerimeter();
    public abstract double GetSquare();
}
