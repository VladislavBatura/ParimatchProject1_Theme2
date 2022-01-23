using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public class Draw
{
    public static Line DrawNewLine()
    {
        Console.WriteLine("Now type a lenght:");
        var lenght = IntTryParse();
        var line = new Line(lenght);

        Console.Clear();
        Background.DrawBackground();
        Console.SetCursorPosition(Background.GetRightSideBorder() / 2,
            Background.GetDownSideBorder() / 2);

        line.LocationX = Console.GetCursorPosition().Left;
        line.LocationY = Console.GetCursorPosition().Top;
        line.Layer = Menu.GetLayer();
        Menu.AddLayer();

        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return line;
    }

    public static void DrawLine(Line line)
    {
        Console.SetCursorPosition(line.LocationX, line.LocationY);

        var end = Console.GetCursorPosition().Left + line.Length;

        if (end >= Background.GetRightSideBorder())
        {
            end = Background.GetRightSideBorder() - 1;
        }

        for (var i = Console.GetCursorPosition().Left; i < end; i++)
        {
            Console.Write(line.Layer);
        }
    }

    public static Rectangle DrawNewRectangle()
    {
        Console.WriteLine("Type a width:");
        var width = IntTryParse();
        Console.WriteLine("Now type a height:");
        var height = IntTryParse();
        var isFill = IsFill();

        var rectangle = new Rectangle(width, height, isFill);

        Console.Clear();
        Background.DrawBackground();
        Console.SetCursorPosition(Background.GetRightSideBorder() / 2,
            Background.GetDownSideBorder() / 2);

        var array = new int[] { Console.GetCursorPosition().Left - (width / 2),
            Console.GetCursorPosition().Top - (height / 2) };
        Array.Copy(array, rectangle.Location["A"], array.Length);

        array = new int[] { Console.GetCursorPosition().Left + (width / 2),
            Console.GetCursorPosition().Top - (height / 2) };
        Array.Copy(array, rectangle.Location["B"], array.Length);

        array = new int[] { Console.GetCursorPosition().Left - (width / 2),
            Console.GetCursorPosition().Top + (height / 2) };
        Array.Copy(array, rectangle.Location["C"], array.Length);

        array = new int[] { Console.GetCursorPosition().Left + (width / 2),
            Console.GetCursorPosition().Top + (height / 2) };
        Array.Copy(array, rectangle.Location["D"], array.Length);

        rectangle.Layer = Menu.GetLayer();
        Menu.AddLayer();

        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return rectangle;
    }

    public static void DrawRectangle(Rectangle rectangle)
    {
        if (rectangle.Width >= Background.GetRightSideBorder() - Background.GetLeftSideBorder())
        {
            foreach (var item in rectangle.Location)
            {
                if (item.Value[0] <= Background.GetRightSideBorder() / 2)
                {
                    item.Value[0] = Background.GetLeftSideBorder() + 1;
                }
                else
                {
                    item.Value[0] = Background.GetRightSideBorder() - 1;
                }
            }
        }
        else if (rectangle.Height >= Background.GetTopSideBorder() - Background.GetDownSideBorder())
        {
            foreach (var item in rectangle.Location)
            {
                if (item.Value[1] <= Background.GetDownSideBorder() / 2)
                {
                    item.Value[1] = Background.GetTopSideBorder() + 1;
                }
                else
                {
                    item.Value[1] = Background.GetDownSideBorder() - 1;
                }
            }
        }

        Console.SetCursorPosition(rectangle.Location["A"][0], rectangle.Location["A"][1]);

        for (var i = Console.GetCursorPosition().Top; i <= rectangle.Location["D"][1]; i++)
        {
            for (var j = Console.GetCursorPosition().Left; j <= rectangle.Location["D"][0]; j++)
            {
                if (Console.GetCursorPosition().Top == rectangle.Location["A"][1] ||
                    Console.GetCursorPosition().Left == rectangle.Location["A"][0] ||
                    Console.GetCursorPosition().Top == rectangle.Location["D"][1] ||
                    Console.GetCursorPosition().Left == rectangle.Location["D"][0])
                {
                    Console.Write(rectangle.Layer);
                }
                else if (rectangle.IsFill)
                {
                    Console.Write(rectangle.Layer);
                }
                else
                {
                    Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                }
            }
            Console.SetCursorPosition(rectangle.Location["A"][0], Console.GetCursorPosition().Top + 1);
        }
    }

    public static Triangle DrawNewTriangle()
    {
        Console.WriteLine("Now type a height:");
        var height = IntTryParse();
        var isFill = IsFill();

        var triangle = new Triangle(height, isFill)
        {
            Layer = Menu.GetLayer(),
            Foundation = (height * 2) - 1
        };
        Menu.AddLayer();

        Console.Clear();
        Background.DrawBackground();
        Console.SetCursorPosition(Background.GetRightSideBorder() / 2,
            Background.GetDownSideBorder() / 2);

        triangle.LocationX = Console.GetCursorPosition().Left;
        triangle.LocationY = Console.GetCursorPosition().Top;

        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return triangle;
    }

    public static void DrawTriangle(Triangle triangle)
    {
        Console.SetCursorPosition(triangle.LocationX, triangle.LocationY);

        for (var i = 1; i <= triangle.Height; i++)
        {
            for (var j = (i * 2) - 1; j > 0; j--)
            {
                if (Console.GetCursorPosition().Left <= Background.GetLeftSideBorder())
                {
                    Console.SetCursorPosition(Background.GetLeftSideBorder() + 1, Console.GetCursorPosition().Top);
                }
                else if (Console.GetCursorPosition().Left >= Background.GetRightSideBorder())
                {
                    Console.SetCursorPosition(Background.GetRightSideBorder() - 1, Console.GetCursorPosition().Top);
                }

                if (Console.GetCursorPosition().Top >= Background.GetDownSideBorder())
                {
                    return;
                }

                if (triangle.IsFill)
                {
                    Console.Write(triangle.Layer);
                }
                else if (j == (i * 2) - 1 || j == 1 || i == triangle.Height)
                {
                    Console.Write(triangle.Layer);
                }
                else
                {
                    Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                }
            }
            Console.SetCursorPosition(triangle.LocationX - i, Console.GetCursorPosition().Top + 1);
        }
    }

    public static Figure DrawNewCircle()
    {
        Console.WriteLine("Now type a radius:");
        var radius = DoubleTryParse();
        var isFill = IsFill();

        var circle = new Circle(radius, isFill);

        Console.Clear();
        Background.DrawBackground();
        Console.SetCursorPosition(Background.GetRightSideBorder() / 2,
            Background.GetDownSideBorder() / 2);

        circle.LocationX = Console.GetCursorPosition().Left;
        circle.LocationY = Console.GetCursorPosition().Top;

        circle.Layer = Menu.GetLayer();
        Menu.AddLayer();

        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return circle;

    }

    public static void DrawCircle(Circle circle)
    {
        if (circle.LocationX - (int)circle.Radius + 1 <= Background.GetLeftSideBorder())
        {
            if (circle.LocationY - (int)circle.Radius <= Background.GetTopSideBorder())
            {
                if (circle.LocationX - Background.GetLeftSideBorder() < circle.LocationY - Background.GetTopSideBorder())
                {
                    circle.Radius = circle.LocationX - Background.GetLeftSideBorder() + 1;
                }
                else
                {
                    circle.Radius = circle.LocationY - Background.GetTopSideBorder() + 1;
                }
            }
        }
        Console.SetCursorPosition(circle.LocationX - (int)circle.Radius + 1, circle.LocationY - (int)circle.Radius);

        var radiusIn = circle.Radius - 0.4;
        var radiusOut = circle.Radius + 0.4;

        for (var y = circle.Radius; y >= -circle.Radius; --y)
        {
            for (var x = -circle.Radius; x < radiusOut; x += 0.5)
            {

                if (Console.GetCursorPosition().Left <= Background.GetLeftSideBorder())
                {
                    Console.SetCursorPosition(Background.GetLeftSideBorder() + 1, Console.GetCursorPosition().Top);
                }
                else if (Console.GetCursorPosition().Left >= Background.GetRightSideBorder())
                {
                    Console.SetCursorPosition(Background.GetRightSideBorder() - 1, Console.GetCursorPosition().Top);
                }

                if (Console.GetCursorPosition().Top >= Background.GetDownSideBorder())
                {
                    return;
                }
                else if (Console.GetCursorPosition().Top <= Background.GetTopSideBorder())
                {
                    Console.SetCursorPosition(Console.GetCursorPosition().Left, Background.GetTopSideBorder() + 1);
                }

                var value = (x * x) + (y * y);
                if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                {
                    Console.Write(circle.Layer);
                }
                else if (circle.Fill && value < radiusIn * radiusIn && value < radiusOut * radiusOut)
                {
                    Console.Write(circle.Layer);
                }
                else
                {
                    Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                }
            }
            Console.SetCursorPosition(circle.LocationX - (int)circle.Radius + 1,
                circle.LocationY - (int)y + 1);
        }
    }

    private static int IntTryParse()
    {
        int i;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out i) || i <= 0)
            {
                Console.WriteLine("Invalid argument, try again");
            }
        }
        while (i <= 0);
        return i;
    }

    private static double DoubleTryParse()
    {
        double i;
        do
        {
            if (!double.TryParse(Console.ReadLine(), out i) || i <= 0)
            {
                Console.WriteLine("Invalid argument, try again");
            }
        }
        while (i <= 0);
        return i;
    }
    private static bool IsFill()
    {
        while (true)
        {
            Console.WriteLine("Do you want to fill figure? y/n");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
                default:
                    break;
            }
        }
    }

    public static void DrawFigures()
    {
        Console.Clear();
        Background.DrawBackground();
        var figures = Menu.GetFigures();

        if (figures.Values.Count == 0)
        {
            return;
        }

        var listOrderedFigures = new List<Figure>();

        foreach (var f in figures)
        {
            listOrderedFigures = listOrderedFigures.Union(f.Value).ToList();
        }

        listOrderedFigures = listOrderedFigures.OrderBy(x => x.Layer).ToList();
        foreach (var figure in listOrderedFigures)
        {
            switch (figure.GetType().Name)
            {
                case "Line":
                    DrawLine(figure as Line);
                    break;
                case "Rectangle":
                    DrawRectangle(figure as Rectangle);
                    break;
                case "Triangle":
                    DrawTriangle(figure as Triangle);
                    break;
                case "Circle":
                    DrawCircle(figure as Circle);
                    break;
                default:
                    break;
            }
        }
        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
    }
}
