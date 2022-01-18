using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Theme2.Models;

public class Line : Figure
{
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public double Length { get; }

    public Line(double length)
    {
        Length = length;
    }

    public override double GetArea()
    {
        return 0;
    }

    public override double GetPerimeter()
    {
        return Length;
    }
}
