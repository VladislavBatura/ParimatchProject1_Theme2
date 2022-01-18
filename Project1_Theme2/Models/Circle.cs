using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Theme2.Models;

public class Circle : Figure
{
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetPerimeter()
    {
        return Radius * 2 * Math.PI;
    }

    public override double GetArea()
    {
        return Math.Pow(Radius, 2) * Math.PI;
    }
}
