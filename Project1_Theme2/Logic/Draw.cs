using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public class Draw
{
    public static Line DrawLine()
    {
        Console.WriteLine("Now type a lenght:");
        var lenght = int.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
        var line = new Line(lenght);
        Console.Clear();
        Background.DrawBackground();
        Console.SetCursorPosition(10, 10);
        line.LocationX = 10;
        line.LocationY = 10;
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

    internal static void DrawRectangle()
    {
        throw new NotImplementedException();
    }

    internal static void DrawTriangle()
    {
        throw new NotImplementedException();
    }

    internal static void DrawCircle()
    {
        throw new NotImplementedException();
    }
}
