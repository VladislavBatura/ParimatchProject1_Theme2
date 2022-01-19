namespace Project1_Theme2.Logic;

/// <summary>
/// This class represents a scene for drawing figures
/// </summary>
public static class Background
{
    /// <summary>
    /// This field represents a border angles of scene, which used in drawing checks
    /// </summary>
    public static Dictionary<string, (int, int)> Angles => new()
    {
        { "LeftTop", (2, 1) },
        { "RightTop", (80, 1) },
        { "LeftDown", (2, 40) },
        { "RightDown", (80, 40) }
    };

    /// <summary>
    /// This function draws background in green, based on scene angles
    /// </summary>
    public static void DrawBackground()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(Angles["LeftTop"].Item1, Angles["LeftTop"].Item2);
        for (var i = 2; i < Angles["RightTop"].Item1; i++)
        {
            Console.Write("*");
        }

        Console.SetCursorPosition(Angles["LeftDown"].Item1, Angles["LeftDown"].Item2);

        for (var i = 2; i < Angles["RightDown"].Item1; i++)
        {
            Console.Write("*");
        }

        Console.SetCursorPosition(Angles["LeftTop"].Item1, Angles["LeftTop"].Item2 + 1);

        for (var i = 1; i < Angles["LeftDown"].Item2; i++)
        {
            Console.Write("*");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
        }

        Console.SetCursorPosition(Angles["RightTop"].Item1, Angles["RightTop"].Item2 + 1);

        for (var i = 1; i < Angles["RightDown"].Item2; i++)
        {
            Console.Write("*");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Methods below return scene angles for border check
    /// </summary>
    /// <returns>scene angle</returns>
    public static int GetTopSideBorder()
    {
        return Angles["LeftTop"].Item2;
    }

    public static int GetDownSideBorder()
    {
        return Angles["LeftDown"].Item2;
    }

    public static int GetLeftSideBorder()
    {
        return Angles["LeftTop"].Item1;
    }

    public static int GetRightSideBorder()
    {
        return Angles["RightTop"].Item1;
    }
}
