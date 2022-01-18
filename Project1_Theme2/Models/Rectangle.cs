using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Theme2.Models;

public class Rectangle : Figure
{
    public double Width { get; }
    public double Height { get; }
    public Dictionary<string, (int, int)> Location { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
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
