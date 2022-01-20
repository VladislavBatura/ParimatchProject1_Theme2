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

        Console.CursorVisible = false;
        var end = Console.GetCursorPosition().Left + lenght;
        for (var i = Console.GetCursorPosition().Left; i < end; i++)
        {
            Console.Write(line.Layer);
        }
        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return line;
    }

    public static void DrawLine(Line line)
    {

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

        rectangle.Location.Add("A",
            (Console.GetCursorPosition().Left - (width / 2),
            Console.GetCursorPosition().Top - (height / 2)));
        rectangle.Location.Add("B",
            (Console.GetCursorPosition().Left + (width / 2),
            Console.GetCursorPosition().Top - (height / 2)));
        rectangle.Location.Add("C",
            (Console.GetCursorPosition().Left - (width / 2),
            Console.GetCursorPosition().Top + (height / 2)));
        rectangle.Location.Add("D",
            (Console.GetCursorPosition().Left + (width / 2),
            Console.GetCursorPosition().Top + (height / 2)));

        Console.SetCursorPosition(rectangle.Location["A"].Item1, rectangle.Location["A"].Item2);

        rectangle.Layer = Menu.GetLayer();
        Menu.AddLayer();
        Console.CursorVisible = false;

        for (var i = Console.GetCursorPosition().Top; i <= rectangle.Location["D"].Item2; i++)
        {
            for (var j = Console.GetCursorPosition().Left; j <= rectangle.Location["D"].Item1; j++)
            {
                if (Console.GetCursorPosition().Top == rectangle.Location["A"].Item2 ||
                    Console.GetCursorPosition().Left == rectangle.Location["A"].Item1 ||
                    Console.GetCursorPosition().Top == rectangle.Location["D"].Item2 ||
                    Console.GetCursorPosition().Left == rectangle.Location["D"].Item1)
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
            Console.SetCursorPosition(rectangle.Location["A"].Item1, Console.GetCursorPosition().Top + 1);
        }

        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return rectangle;
    }

    internal static void DrawNewTriangle()
    {
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

        Console.SetCursorPosition((Background.GetRightSideBorder() / 2) - (int)radius + 1,
            (Background.GetDownSideBorder() / 2) - (int)radius);

        circle.Layer = Menu.GetLayer();
        Menu.AddLayer();
        Console.CursorVisible = false;

        var radiusIn = radius - 0.4;
        var radiusOut = radius + 0.4;

        for (var y = radius; y >= -radius; --y)
        {
            for (var x = -radius; x < radiusOut; x += 0.5)
            {
                var value = (x * x) + (y * y);
                if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                {
                    Console.Write(circle.Layer);
                }
                else if (isFill && value < radiusIn * radiusIn && value < radiusOut * radiusOut)
                {
                    Console.Write(circle.Layer);
                }
                else
                {
                    Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                }
            }
            Console.SetCursorPosition((Background.GetRightSideBorder() / 2) - (int)radius + 1,
                (Background.GetDownSideBorder() / 2) - (int)y + 1);
        }
        Console.SetCursorPosition(Background.GetLeftSideBorder() - 1, Background.GetDownSideBorder() + 1);
        return circle;
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
        var figures = Menu.GetFigures();

    }
}
